using MezuniyetSistemi.Business.Abstract;
using MezuniyetSistemi.Entities.Concrete;
using MezuniyetSistemi.Entities.DTOs;
using MezuniyetSistemi.Entities.RequestFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MezuniyetSistemi.API.Controllers
{
    [Route("api/profiles")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfilesController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpPost]
        public IActionResult AddProfile([FromBody] UserProfileDtoForAdd profileDto)
        {
            _profileService.Add(profileDto);

            return Ok();
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateProfile([FromRoute] int id, [FromBody] UserProfileDtoForUpdate profileDto)
        {
            _profileService.Update(id, profileDto, false);

            return Ok();
        }

        //[HttpGet]
        //public IActionResult GetAll() 
        //{
        //    var profiles = _profileService.FindAll(false);

        //    return Ok(profiles);
        //}

        [HttpGet]
        public IActionResult GetAllWithParams([FromQuery] UserProfileParameters userProfileParameters)
        {
            var profiles = _profileService.FindAllWithPagination(userProfileParameters, false);

            return Ok(profiles);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get([FromRoute] int id)
        {
            var profile = _profileService.FindById(id, false);

            return Ok(profile);
        }

    }
}
