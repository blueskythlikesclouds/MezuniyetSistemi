using AutoMapper;
using MezuniyetSistemi.Entities.Concrete;
using MezuniyetSistemi.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezuniyetSistemi.Business.Utilities.AutoMapper.Profiles
{
    public class UserProfileProfile : Profile
    {
        public UserProfileProfile()
        {
            CreateMap<UserProfileDtoForAdd, UserProfile>().ForMember(dest=> dest.CreatedDate, opt=> opt.MapFrom(x=>DateTime.Now));

            CreateMap<UserProfileDtoForUpdate, UserProfile>().ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
        }
    }
}
