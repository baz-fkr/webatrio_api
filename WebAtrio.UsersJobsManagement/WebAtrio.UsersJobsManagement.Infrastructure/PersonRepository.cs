using WebAtrio.UsersJobsManagement.Common;
using WebAtrio.UsersJobsManagement.Models.Entities;

namespace WebAtrio.UsersJobsManagement.Infrastructure
{
    public class PersonRepository : BaseRepository<PersonEntity, UJDbContext>, IPersonRepository
    {
        public PersonRepository(UJDbContext context) : base(context)
        {
        }
    }
}
