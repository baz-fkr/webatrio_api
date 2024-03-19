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

        public async Task<List<JobEntity>> GetAllJobsForAPerson(Guid personId)
        {
            return await context.Jobs.Where(j => j.Person.Id == personId).ToListAsync();
        }
    }
}
