using WebAtrio.UsersJobsManagement.Models.DTO;

namespace WebAtrio.UsersJobsManagement.Business
{
    public interface IPersonService
    {
        Task<PersonDto> AddPerson(PersonDto personDto);

        Task<List<PersonDto>> GetAllPersonsWithAgeAndCurrentJobs();

        Task<List<PersonDto>> GetPersonsWhoWorkedForCompany(string companyName);
    }
}
