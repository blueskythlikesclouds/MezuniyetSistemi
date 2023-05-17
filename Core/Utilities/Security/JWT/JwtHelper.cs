using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper
    {
        // Cookie yazma
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _expiration;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            // appsettings.json icindeki belirledigimiz token ozelliklerini token options nesnesine bind ettik
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            // appsettings.json icerisindeki exp suresi eklendi
            _expiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            // appsettings.json icerisindeki belirledigimiz anahtar
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _expiration,
            };
        }

        private JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _expiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }

    }
}
