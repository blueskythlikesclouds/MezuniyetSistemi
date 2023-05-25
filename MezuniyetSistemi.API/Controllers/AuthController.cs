using MezuniyetSistemi.Business.Abstract;
using MezuniyetSistemi.Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MezuniyetSistemi.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] UserForLoginDto userForLoginDto)
        {
            //if (ModelState.IsValid)
            //{

            //}
            var user = _authService.Login(userForLoginDto);
            var accessToken = _authService.CreateAccessToken(user);
            return Ok(accessToken);
        }

        [HttpPost("register")]
        public ActionResult Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            var checkUser = _authService.UserExists(userForRegisterDto.Email);
            if (checkUser)
                return BadRequest("Bu maile ait kullanici bulunmaktadir!");

            var registerResult = _authService.Register(userForRegisterDto, Entities.ComplexTypes.UserRoles.User);
            var result = _authService.CreateAccessToken(registerResult);
            if (result == null)
                return BadRequest("Bir hata olustu");
            return Ok(result);
        }
    }
}
