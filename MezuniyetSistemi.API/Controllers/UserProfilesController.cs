using MezuniyetSistemi.Business.Abstract;
using MezuniyetSistemi.Entities.Concrete;
using MezuniyetSistemi.Entities.DTOs;
using MezuniyetSistemi.Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace MezuniyetSistemi.API.Controllers
{
    [Route("api/userProfiles")]
    [ApiController]
    [Authorize]
    public class UserProfilesController : ControllerBase
    {
        private readonly IUserProfileService _profileService;

        public UserProfilesController(IUserProfileService profileService)
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
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(profiles.MetaData));

            return Ok(profiles);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get([FromRoute] int id)
        {
            var profile = _profileService.FindById(id, false);

            return Ok(profile);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var profile = _profileService.FindById(id, true);
            if (profile == null)
                return BadRequest();
            _profileService.Delete(profile);
            return NoContent();
        }

        [HttpGet("GlobalHandler")]
        public IActionResult GlobalHandlerTest()
        {
            throw new Exception("Global Hata Yonetimi Testi");
        }

    }
}
