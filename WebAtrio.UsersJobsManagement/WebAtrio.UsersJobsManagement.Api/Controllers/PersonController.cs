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

        [HttpGet]
        [Route("getall")]
        [ProducesResponseType(typeof(List<PersonDto>), 200)]
        [SwaggerOperation(Summary = "Get all persons", Description = "Gets all persons in the system ordered alphabetically and includes their age and current job(s).")]
        public async Task<IActionResult> GetAllPersons()
        {
            List<PersonDto> persons = await _personService.GetAllPersonsWithAgeAndCurrentJobs();
            return Ok(persons);
        }

        [HttpGet]
        [Route("company/{companyName}")]
        [ProducesResponseType(typeof(List<PersonDto>), 200)]
        public async Task<IActionResult> GetPersonsWhoWorkedForCompany(string companyName)
        {
            List<PersonDto> persons = await _personService.GetPersonsWhoWorkedForCompany(companyName);
            return Ok(persons);
        }


    }
}
