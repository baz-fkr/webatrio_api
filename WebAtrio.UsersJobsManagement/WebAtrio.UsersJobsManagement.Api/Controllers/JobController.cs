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

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(typeof(JobDto), 201)]
        [SwaggerOperation(Summary = "Add a new job", Description = "Adds a new job to the system.")]
        public async Task<IActionResult> AddJob([FromBody] JobDto job)
        {
            JobDto addedJob = await _jobService.AddJob(job);
            return CreatedAtAction(nameof(AddJob), new { id = addedJob.Id }, addedJob);
        }
    }
}
