using Microsoft.AspNetCore.Mvc;
using PersonMicroservice.Model;
using PersonMicroservice.Services;

namespace PersonMicroservice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private IPersonService _personService;
    private readonly ILogger<PersonController> _logger;

    public PersonController(ILogger<PersonController> logger, IPersonService personService)
    {
        _logger = logger;
        _personService = personService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_personService.FindAll());
        
    }

    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        var person = _personService.FindById(id);

        if (person == null) return NotFound();

        return Ok(person);

    }

    [HttpPost]
    public IActionResult Post([FromBody]Person person)
    {
        if (person == null) return BadRequest();
        return Ok(_personService.Create(person));

    }

    [HttpPut("{id}")]
    public IActionResult Put([FromBody] Person person, long id)
    {
        if (person == null) return BadRequest();

        var personSearch = _personService.FindById(id);
        if (personSearch == null) return NotFound();

        return Ok(_personService.Update(person));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        var personSearch = _personService.FindById(id);
        if (personSearch == null) return NotFound();

        _personService.Delete(id);
        return NoContent();

    }
}

