using Core.Entities.Concrete;
using Core.Utilities.Security.JWT;
using MezuniyetSistemi.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezuniyetSistemi.Business.Abstract
{
    public interface IAuthService
    {
        User Register(UserForRegisterDto userForRegisterDto);
        User Login(UserForLoginDto loginDto);
        AccessToken CreateAccessToken(User user);
        bool UserExists(string email);
    }
}
