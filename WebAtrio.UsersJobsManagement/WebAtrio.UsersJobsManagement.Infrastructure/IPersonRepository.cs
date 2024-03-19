using WebAtrio.UsersJobsManagement.Common;
using WebAtrio.UsersJobsManagement.Models.Entities;

namespace WebAtrio.UsersJobsManagement.Infrastructure
{
    public interface IPersonRepository : IBaseRepository<PersonEntity>
    {
        Task<List<PersonEntity>> GetPersonsWhoWorkedForCompany(string companyName);
    }
}
