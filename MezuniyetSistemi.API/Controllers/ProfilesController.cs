using MezuniyetSistemi.Business.Abstract;
using MezuniyetSistemi.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MezuniyetSistemi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfilesController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpPost]
        public IActionResult AddProfile([FromBody] Profile profile)
        {
            _profileService.Add(profile);

            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            var profiles = _profileService.FindAll(false);

            return Ok(profiles);
        }

    }
}
