using WebAtrio.UsersJobsManagement.Models.DTO;
using WebAtrio.UsersJobsManagement.Models.Entities;

namespace WebAtrio.UsersJobsManagement.Models.Converters
{
    public static class PersonConverter
    {
        public static PersonEntity ConvertDtoToEntity(PersonDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new PersonEntity
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                BirthDate = dto.BirthDate,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt
            };
        }

        public static PersonDto ConvertEntityToDto(PersonEntity entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new PersonDto
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                BirthDate = entity.BirthDate,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }
    }
}
