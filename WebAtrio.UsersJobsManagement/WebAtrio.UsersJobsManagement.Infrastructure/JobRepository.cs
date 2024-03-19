using Microsoft.EntityFrameworkCore;
using WebAtrio.UsersJobsManagement.Common;
using WebAtrio.UsersJobsManagement.Models.Entities;

namespace WebAtrio.UsersJobsManagement.Infrastructure
{
    public class JobRepository : BaseRepository<JobEntity, UJDbContext>, IJobRepository
    {
        public JobRepository(UJDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Get all jobs for a person
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        public async Task<List<JobEntity>> GetAllJobsForAPerson(Guid personId)
        {
            return await context.Jobs.Where(j => j.Person.Id == personId).ToListAsync();
        }

        /// <summary>
        /// Get all jobs for a person between two dates
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<List<JobEntity>> GetJobsForPersonBetweenDates(Guid personId, DateTime startDate, DateTime endDate)
        {
            return await context.Jobs
                .Where(j => j.Person.Id == personId && j.StartDate >= startDate && j.EndDate <= endDate)
                .ToListAsync();
        }

    }
}
