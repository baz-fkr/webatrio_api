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
        private readonly IJobRepository _jobRepository;

        public PersonService(ILogger<PersonService> logger, IPersonRepository personRepository, IJobRepository jobRepository)
        {
            _logger = logger;
            _personRepository = personRepository;
            _jobRepository = jobRepository;
        }

        /// <summary>
        /// Add a new person to the system
        /// </summary>
        /// <param name="personDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
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

        /// <summary>
        /// Get all persons in the system ordered alphabetically and includes their age and current job(s)
        /// </summary>
        /// <returns></returns>
        public async Task<List<PersonDto>> GetAllPersonsWithAgeAndCurrentJobs()
        {
            List<PersonEntity> persons = await _personRepository.GetAll();

            List<PersonDto> personsDto = persons.Select(PersonConverter.ConvertEntityToDto).ToList();

            foreach (PersonDto personDto in personsDto)
            {
                List<JobEntity> personJobs = await _jobRepository.GetAllJobsForAPerson(personDto.Id);
                personDto.Jobs = personJobs.Select(JobConverter.ConvertEntityToDto).ToList();
            }

            return personsDto;
        }

        public async Task<List<PersonDto>> GetPersonsWhoWorkedForCompany(string companyName)
        {
            List<PersonEntity> persons = await _personRepository.GetPersonsWhoWorkedForCompany(companyName);
            List<PersonDto> personDtos = persons.Select(PersonConverter.ConvertEntityToDto).ToList();
            return personDtos;
        }

    }
}
