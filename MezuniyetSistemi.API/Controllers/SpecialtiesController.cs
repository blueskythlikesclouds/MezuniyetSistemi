using MezuniyetSistemi.Business.Abstract;
using MezuniyetSistemi.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MezuniyetSistemi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialtiesController : ControllerBase
    {
        private readonly ISpecialtyService specialtyService;

        public SpecialtiesController(ISpecialtyService specialtyService)
        {
            this.specialtyService = specialtyService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            var specialties = specialtyService.FindAll(false);
            if (specialties.Count > 0)
            {
                return Ok(specialties);

            }
            return BadRequest();
        }

        [HttpGet("{id:Int}")]
        public IActionResult Get([FromRoute] int id)
        {

            var specialties = specialtyService.FindById(id, false);
            if (!(specialties is null))
            {
                return Ok(specialties);

            }
            return BadRequest();

        }

        [HttpPost]
        public IActionResult Add([FromBody] Specialty specialties)
        {

            specialtyService.Add(specialties);
            return Ok();

        }

        [HttpPut("{id:Int}")]
        public IActionResult Update([FromRoute] int id, [FromBody] Specialty specialties)
        {

            specialtyService.Update(id, specialties, true);
            return Ok();

        }

        [HttpDelete("{id:Int}")]
        public IActionResult Delete([FromRoute] int id)
        {

            specialtyService.Delete(id);
            return Ok();
        }
    }
}
