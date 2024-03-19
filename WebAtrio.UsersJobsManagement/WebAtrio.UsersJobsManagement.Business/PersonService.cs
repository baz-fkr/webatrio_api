using Microsoft.Extensions.Logging;
using WebAtrio.UsersJobsManagement.Infrastructure;
using WebAtrio.UsersJobsManagement.Models.Converters;
using WebAtrio.UsersJobsManagement.Models.DTO;
using WebAtrio.UsersJobsManagement.Models.Entities;

namespace WebAtrio.UsersJobsManagement.Business
{
    public class PersonService : IPersonService
    {
        private ILogger<PersonService> _logger;
        private readonly IPersonRepository _personRepository;

        public PersonService(ILogger<PersonService> logger, IPersonRepository personRepository)
        {
            _logger = logger;
            _personRepository = personRepository;
        }

        public async Task<PersonDto> AddPerson(PersonDto personDto)
        {
            // Check if the person is younger than 150 years
            if (personDto.BirthDate.AddYears(150) < DateTime.Now)
            {
                _logger.LogError($"Person is older than 150 years.");
                throw new ArgumentException("Person is older than 150 years.");
            }

            PersonEntity person = PersonConverter.ConvertDtoToEntity(personDto);

            person = await _personRepository.Add(person);
            _logger.LogInformation($"Person {person.Id} has been created in database.");

            return PersonConverter.ConvertEntityToDto(person);
        }
    }
}
