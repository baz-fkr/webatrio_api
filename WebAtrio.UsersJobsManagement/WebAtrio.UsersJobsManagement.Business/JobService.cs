using Microsoft.Extensions.Logging;
using WebAtrio.UsersJobsManagement.Infrastructure;
using WebAtrio.UsersJobsManagement.Models.Converters;
using WebAtrio.UsersJobsManagement.Models.DTO;
using WebAtrio.UsersJobsManagement.Models.Entities;

namespace WebAtrio.UsersJobsManagement.Business
{
    public class JobService : IJobService
    {
        private ILogger<JobService> _logger;
        private readonly IJobRepository _jobRepository;
        private readonly IPersonRepository _personRepository;

        public JobService(ILogger<JobService> logger, IJobRepository jobRepository, IPersonRepository personRepository)
        {
            _logger = logger;
            _jobRepository = jobRepository;
            _personRepository = personRepository;
        }

        /// <summary>
        /// Add a new job to the system
        /// </summary>
        /// <param name="jobDto"></param>
        /// <returns></returns>
        public async Task<JobDto> AddJob(JobDto jobDto)
        {
            PersonEntity person = await _personRepository.Get(jobDto.PersonId);
            JobEntity job = JobConverter.ConvertDtoToEntity(jobDto, person);

            job = await _jobRepository.Add(job);
            _logger.LogInformation($"Job {job.Id} has been created in database.");

            return JobConverter.ConvertEntityToDto(job);
        }
    }
}
