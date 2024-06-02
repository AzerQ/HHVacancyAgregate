using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HHVacancy.Models.DB.Entities;

[Table("Employments")]
public class EmploymentEntity
{
    [Key]
    [Column("EmploymentId")]
    public string Id { get; set; }

    public string Name { get; set; }
}
