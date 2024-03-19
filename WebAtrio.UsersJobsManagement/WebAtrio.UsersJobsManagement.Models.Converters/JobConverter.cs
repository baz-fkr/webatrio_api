using System;
using WebAtrio.UsersJobsManagement.Models.DTO;
using WebAtrio.UsersJobsManagement.Models.Entities;

namespace WebAtrio.UsersJobsManagement.Models.Converters
{
    public static class JobConverter
    {
        public static JobEntity ConvertDtoToEntity(JobDto dto, PersonEntity person)
        {
            if (dto == null)
            {
                return null;
            }

            return new JobEntity
            {
                Id = dto.Id,
                Person = person,
                CompanyName = dto.CompanyName,
                Position = dto.Position,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt
            };
        }

        public static JobDto ConvertEntityToDto(JobEntity entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new JobDto
            {
                Id = entity.Id,
                PersonId = entity.Person.Id,
                CompanyName = entity.CompanyName,
                Position = entity.Position,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        } 
    }
}
