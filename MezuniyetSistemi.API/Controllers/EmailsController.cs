using MezuniyetSistemi.Business.Abstract;
using MezuniyetSistemi.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MezuniyetSistemi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly IEmailService emailService;

        public EmailsController(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        [HttpGet]   
        public IActionResult GetAll() {

            var emails = emailService.FindAll(false);
            if (emails.Count>0)
            {
                return Ok(emails);
                
            }
            return BadRequest();
        }

        [HttpGet("{id:Int}")]
        public IActionResult Get([FromRoute]int id) {

            var emails = emailService.FindById(id,false);
            if (!(emails is null))
            {
                return Ok(emails);

            }
            return BadRequest();

        }

        [HttpPost]
        public IActionResult Add([FromBody] Email email)
        {

            emailService.Add(email);
            return Ok();

        }

        [HttpPut("{id:Int}")]
        public IActionResult Update([FromRoute] int id, [FromBody] Email email )
        {

            emailService.Update(id, email, true);
            return Ok();

        }

        [HttpDelete("{id:Int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var emails = emailService.FindById(id, false);
            
            if (!(emails is null))
            {
                emailService.Delete(emails);
                return Ok(emails);

            }
            return BadRequest();

        }
    }
}
