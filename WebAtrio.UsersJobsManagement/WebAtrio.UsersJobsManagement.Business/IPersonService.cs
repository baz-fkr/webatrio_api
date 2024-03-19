using WebAtrio.UsersJobsManagement.Models.DTO;

namespace WebAtrio.UsersJobsManagement.Business
{
    public interface IPersonService
    {
        Task<PersonDto> AddPerson(PersonDto personDto);
    }
}
