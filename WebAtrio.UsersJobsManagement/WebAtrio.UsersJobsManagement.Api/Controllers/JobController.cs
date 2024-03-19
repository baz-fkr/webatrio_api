using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebAtrio.UsersJobsManagement.Business;
using WebAtrio.UsersJobsManagement.Models.DTO;

namespace WebAtrio.UsersJobsManagement.Api.Controllers
{
    [Route("api/job")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        /// <summary>
        /// Add a new job to the system
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add")]
        [ProducesResponseType(typeof(JobDto), 201)]
        [SwaggerOperation(Summary = "Add a new job", Description = "Adds a new job to the system.")]
        public async Task<IActionResult> AddJob([FromBody] JobDto job)
        {
            JobDto addedJob = await _jobService.AddJob(job);
            return CreatedAtAction(nameof(AddJob), new { id = addedJob.Id }, addedJob);
        }

        /// <summary>
        /// Get all jobs for a person between two dates
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("person/{personId}/dates")]
        [ProducesResponseType(typeof(List<JobDto>), 200)]
        public async Task<IActionResult> GetJobsForPersonBetweenDates(Guid personId, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            List<JobDto> jobs = await _jobService.GetJobsForPersonBetweenDates(personId, startDate, endDate);
            return Ok(jobs);
        }

    }
}
