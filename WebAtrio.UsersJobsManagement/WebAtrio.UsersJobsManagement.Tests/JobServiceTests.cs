using Microsoft.Extensions.Logging;
using Moq;
using WebAtrio.UsersJobsManagement.Business;
using WebAtrio.UsersJobsManagement.Infrastructure;
using WebAtrio.UsersJobsManagement.Models.DTO;
using WebAtrio.UsersJobsManagement.Models.Entities;

namespace WebAtrio.UsersJobsManagement.Tests
{
    [TestFixture]
    public class JobServiceTests
    {
        private Mock<IJobRepository> _mockJobRepository;
        private Mock<IPersonRepository> _mockPersonRepository;
        private Mock<ILogger<JobService>> _mockLogger;
        private JobService _jobService;

        [SetUp]
        public void Setup()
        {
            _mockJobRepository = new Mock<IJobRepository>();
            _mockPersonRepository = new Mock<IPersonRepository>();
            _mockLogger = new Mock<ILogger<JobService>>();
            _jobService = new JobService(_mockLogger.Object, _mockJobRepository.Object, _mockPersonRepository.Object);
        }

        [Test]
        public async Task AddJob_ValidJob_AddsJobToRepository()
        {
            // Arrange
            JobDto jobDto = new JobDto
            {
                PersonId = Guid.NewGuid(),
                CompanyName = "Test Company",
                Position = "Test Position",
                StartDate = new DateTime(2020, 1, 1),
                EndDate = new DateTime(2021, 1, 1)
            };

            PersonEntity personEntity = new PersonEntity
            {
                Id = jobDto.PersonId,
                FirstName = "Test",
                LastName = "Person"
            };

            _mockPersonRepository.Setup(x => x.Get(jobDto.PersonId)).ReturnsAsync(personEntity);
            _mockJobRepository.Setup(x => x.Add(It.IsAny<JobEntity>())).ReturnsAsync(new JobEntity());

            // Act
            await _jobService.AddJob(jobDto);

            // Assert
            _mockJobRepository.Verify(x => x.Add(It.IsAny<JobEntity>()), Times.Once);
        }

        [Test]
        public async Task GetJobsForPersonBetweenDates_ValidParameters_ReturnsCorrectJobs()
        {
            // Arrange
            Guid personId = Guid.NewGuid();
            PersonEntity personEntity = new PersonEntity
            {
                Id = personId,
                FirstName = "Test",
                LastName = "Person"
            };
            DateTime startDate = new DateTime(2020, 1, 1);
            DateTime endDate = new DateTime(2021, 1, 1);

            List<JobEntity> jobs = new List<JobEntity>
            {
                new JobEntity
                {
                    Id = Guid.NewGuid(),
                    Person = personEntity,
                    CompanyName = "Test Company 1",
                    Position = "Test Position 1",
                    StartDate = new DateTime(2020, 2, 1),
                    EndDate = new DateTime(2020, 3, 1)
                },
                new JobEntity
                {
                    Id = Guid.NewGuid(),
                    Person = personEntity,
                    CompanyName = "Test Company 2",
                    Position = "Test Position 2",
                    StartDate = new DateTime(2020, 5, 1),
                    EndDate = new DateTime(2020, 6, 1)
                }
            };

            _mockJobRepository.Setup(x => x.GetJobsForPersonBetweenDates(personId, startDate, endDate)).ReturnsAsync(jobs);

            // Act
            List<JobDto> jobDtos = await _jobService.GetJobsForPersonBetweenDates(personId, startDate, endDate);

            // Assert
            Assert.AreEqual(2, jobDtos.Count);
            Assert.AreEqual(jobs[0].Id, jobDtos[0].Id);
            Assert.AreEqual(jobs[0].CompanyName, jobDtos[0].CompanyName);
            Assert.AreEqual(jobs[0].Position, jobDtos[0].Position);
            Assert.AreEqual(jobs[0].StartDate, jobDtos[0].StartDate);
            Assert.AreEqual(jobs[0].EndDate, jobDtos[0].EndDate);

            Assert.AreEqual(jobs[1].Id, jobDtos[1].Id);
            Assert.AreEqual(jobs[1].CompanyName, jobDtos[1].CompanyName);
            Assert.AreEqual(jobs[1].Position, jobDtos[1].Position);
            Assert.AreEqual(jobs[1].StartDate, jobDtos[1].StartDate);
            Assert.AreEqual(jobs[1].EndDate, jobDtos[1].EndDate);
        }
    }
}
