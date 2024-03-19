using WebAtrio.UsersJobsManagement.Models.DTO;

namespace WebAtrio.UsersJobsManagement.Business
{
    public interface IJobService
    {
        Task<JobDto> AddJob(JobDto jobDto);

        Task<List<JobDto>> GetJobsForPersonBetweenDates(Guid personId, DateTime startDate, DateTime endDate);

    }
}
