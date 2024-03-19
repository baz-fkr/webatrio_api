using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAtrio.UsersJobsManagement.Common;

namespace WebAtrio.UsersJobsManagement.Models.Entities
{
    [Table("t_persons")]
    public class PersonEntity : IBaseEntity
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("firstname")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [Column("lastname")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [Column("birthdate")]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }

        [Column("created_at")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; }
    }
}
