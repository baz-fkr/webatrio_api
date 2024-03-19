using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAtrio.UsersJobsManagement.Common;

namespace WebAtrio.UsersJobsManagement.Models.Entities
{
    [Table("t_jobs")]
    public class JobEntity : IBaseEntity
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("person_id")]
        public PersonEntity Person { get; set; }

        [Required]
        [Column("company_name")]
        [StringLength(50)]
        public string CompanyName { get; set; }

        [Required]
        [Column("position")]
        [StringLength(50)]
        public string Position { get; set; }

        [Required]
        [Column("start_date")]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Column("end_date")]
        [DataType(DataType.DateTime)]
        public DateTime? EndDate { get; set; }

        [Column("created_at")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; }
    }
}
