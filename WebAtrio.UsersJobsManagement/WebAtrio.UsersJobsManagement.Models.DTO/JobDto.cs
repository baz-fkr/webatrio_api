using System.ComponentModel.DataAnnotations;

namespace WebAtrio.UsersJobsManagement.Models.DTO
{
    public class JobDto
    {
        public Guid Id { get; set; }

        [Required]
        public Guid PersonId { get; set; }

        [Required]
        [StringLength(50)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(50)]
        public string Position { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime? EndDate { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; }
    }
}
