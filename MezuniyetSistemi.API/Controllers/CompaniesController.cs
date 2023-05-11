using MezuniyetSistemi.Business.Abstract;
using MezuniyetSistemi.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MezuniyetSistemi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompaniesController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var companies = _companyService.FindAll(false);
        if (companies.Count > 0)
        {
            return Ok(companies);

        }
        return BadRequest();
    }

    [HttpGet("{id:Int}")]
    public IActionResult Get([FromRoute] int id)
    {
        var companies = _companyService.FindById(id, false);
        if (!(companies is null))
        {
            return Ok(companies);

        }
        return BadRequest();
    }

    [HttpPost]
    public IActionResult Add([FromBody] Company companies)
    {
        _companyService.Add(companies);
        return Ok();
    }

    [HttpPut("{id:Int}")]
    public IActionResult Update([FromRoute] int id, [FromBody] Company companies)
    {
        _companyService.Update(id, companies, true);
        return Ok();
    }

    [HttpDelete("{id:Int}")]
    public IActionResult Delete([FromRoute] int id)
    {
        _companyService.Delete(id);
        return Ok();
    }
}