using WebAtrio.UsersJobsManagement.Common;
using WebAtrio.UsersJobsManagement.Models.Entities;

namespace WebAtrio.UsersJobsManagement.Infrastructure
{
    public class JobRepository : BaseRepository<JobEntity, UJDbContext>, IJobRepository
    {
        public JobRepository(UJDbContext context) : base(context)
        {
        }
    }
}
