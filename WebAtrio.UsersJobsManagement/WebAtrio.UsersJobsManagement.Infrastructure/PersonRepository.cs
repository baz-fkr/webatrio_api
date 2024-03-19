using Microsoft.EntityFrameworkCore;
using WebAtrio.UsersJobsManagement.Common;
using WebAtrio.UsersJobsManagement.Models.Entities;

namespace WebAtrio.UsersJobsManagement.Infrastructure
{
    public class PersonRepository : BaseRepository<PersonEntity, UJDbContext>, IPersonRepository
    {
        public PersonRepository(UJDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Get persons who worked for a company (not case sensitive)
        /// </summary>
        /// <param name="companyName"></param>
        /// <returns></returns>
        public async Task<List<PersonEntity>> GetPersonsWhoWorkedForCompany(string companyName)
        {
            // Prevent case sensitive search
            companyName = companyName.ToLower();

            return await context.Persons
                .Where(p => p.Jobs.Any(j => j.CompanyName.ToLower() == companyName))
                .ToListAsync();
        }

    }
}
