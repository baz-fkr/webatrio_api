using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebAtrio.UsersJobsManagement.Business;
using WebAtrio.UsersJobsManagement.Models.DTO;

namespace WebAtrio.UsersJobsManagement.Api.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(typeof(PersonDto), 201)]
        [SwaggerOperation(Summary = "Add a new person", Description = "Adds a new person to the system.")]
        public async Task<IActionResult> AddPerson([FromBody] PersonDto person)
        {
            PersonDto addedPerson = await _personService.AddPerson(person);
            return CreatedAtAction(nameof(AddPerson), new { id = addedPerson.Id }, addedPerson);
        }
    }
}
