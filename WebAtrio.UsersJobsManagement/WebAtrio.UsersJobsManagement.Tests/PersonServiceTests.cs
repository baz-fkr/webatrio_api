using NUnit.Framework;
using Moq;
using WebAtrio.UsersJobsManagement.Business;
using WebAtrio.UsersJobsManagement.Models.DTO;
using WebAtrio.UsersJobsManagement.Infrastructure;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using WebAtrio.UsersJobsManagement.Models.Entities;
using System;

namespace WebAtrio.UsersJobsManagement.Tests
{
    [TestFixture]
    public class PersonServiceTests
    {
        private Mock<IPersonRepository> _mockPersonRepository;
        private Mock<IJobRepository> _mockJobRepository;
        private Mock<ILogger<PersonService>> _mockLogger;
        private PersonService _personService;

        [SetUp]
        public void Setup()
        {
            _mockPersonRepository = new Mock<IPersonRepository>();
            _mockJobRepository = new Mock<IJobRepository>();
            _mockLogger = new Mock<ILogger<PersonService>>();
            _personService = new PersonService(_mockLogger.Object, _mockPersonRepository.Object, _mockJobRepository.Object);
        }

        [Test]
        public async Task AddPerson_ValidPerson_AddsPersonToRepository()
        {
            // Arrange
            PersonDto personDto = new PersonDto
            {
                FirstName = "Test",
                LastName = "Person",
                BirthDate = new DateTime(1990, 1, 1)
            };

            _mockPersonRepository.Setup(x => x.Add(It.IsAny<PersonEntity>())).ReturnsAsync(new PersonEntity());

            // Act
            await _personService.AddPerson(personDto);

            // Assert
            _mockPersonRepository.Verify(x => x.Add(It.IsAny<PersonEntity>()), Times.Once);
            _mockLogger.Verify(x => x.Log(LogLevel.Information, It.IsAny<EventId>(), It.IsAny<object>(), It.IsAny<Exception>(), (Func<object, Exception, string>)It.IsAny<object>()), Times.Once);
        }

        [Test]
        public async Task GetPersonsWhoWorkedForCompany_ValidCompanyName_ReturnsCorrectPersons()
        {
            // Arrange
            string companyName = "Test Company";

            List<PersonEntity> persons = new List<PersonEntity>
            {
                new PersonEntity
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Test1",
                    LastName = "Person1",
                    BirthDate = new DateTime(1990, 1, 1)
                },
                new PersonEntity
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Test2",
                    LastName = "Person2",
                    BirthDate = new DateTime(1980, 1, 1)
                }
            };

            _mockPersonRepository.Setup(x => x.GetPersonsWhoWorkedForCompany(companyName)).ReturnsAsync(persons);

            // Act
            List<PersonDto> personDtos = await _personService.GetPersonsWhoWorkedForCompany(companyName);

            // Assert
            Assert.AreEqual(2, personDtos.Count);
            Assert.AreEqual(persons[0].Id, personDtos[0].Id);
            Assert.AreEqual(persons[0].FirstName, personDtos[0].FirstName);
            Assert.AreEqual(persons[0].LastName, personDtos[0].LastName);

            Assert.AreEqual(persons[1].Id, personDtos[1].Id);
            Assert.AreEqual(persons[1].FirstName, personDtos[1].FirstName);
            Assert.AreEqual(persons[1].LastName, personDtos[1].LastName);
        }
    }
}
