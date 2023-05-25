using Core.Entities.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using MezuniyetSistemi.Business.Abstract;
using MezuniyetSistemi.DataAccess.Abstract;
using MezuniyetSistemi.Entities.ComplexTypes;
using MezuniyetSistemi.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezuniyetSistemi.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUnitOfWork UnitOfWork { get; }
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(IUnitOfWork unitOfWork, ITokenHelper tokenHelper)
        {
            UnitOfWork = unitOfWork;
            _tokenHelper = tokenHelper;
        }

        public User Login(UserForLoginDto loginDto)
        {
            if (!UserExists(loginDto.Email))
                throw new Exception("Kullanici bulunamadi");

            var user = UnitOfWork.Users.FindByCondition(x => x.Email == loginDto.Email, false).FirstOrDefault();
            var loginResult = HashingHelper.VerifyPasswordHash(loginDto.Password, user.PasswordHash, user.PasswordSalt);
            if (!loginResult)
                throw new Exception("Email veya sifre yanlis!");
            return user;
        }

        public User Register(UserForRegisterDto userForRegisterDto, UserRoles role)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);

            var user = new User
            {
                Email = userForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                IsActive = true
            };
            UnitOfWork.Users.Add(user);
            UnitOfWork.Save();
            UnitOfWork.UserOperationClaims.Add(new()
            {
                UserId = user.Id,
                OperationClaimId = (int)role
            });
            UnitOfWork.Profiles.Add(new()
            {
                UserId = user.Id,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                IsDeleted = false,
                IsActive = true,
                StudentNumber = 191118015,
            });
            UnitOfWork.Save();
            return user;
        }

        public bool UserExists(string email)
        {
            var result = UnitOfWork.Users.FindByCondition(x => x.Email == email,false).FirstOrDefault();
            if (result == null)
                return false;
            return true;
        }

        public AccessToken CreateAccessToken(User user)
        {
            var claims = UnitOfWork.Users.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return accessToken;
        }
    }
}
