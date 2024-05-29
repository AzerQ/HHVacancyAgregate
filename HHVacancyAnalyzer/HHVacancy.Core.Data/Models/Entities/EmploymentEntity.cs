using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HHVacancy.Core.Data.Models.Entities
{
    [Table("Employments")]
    public class EmploymentEntity
    {
        [Key]
        [Column("EmploymentId")]
        public string Id { get; set; }

        public string Name { get; set; }
    }
}