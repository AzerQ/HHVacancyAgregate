using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HHVacancy.Models.DB.Entities;

[Table("Expirences")]
public class ExperienceEntity
{
    [Key]
    [Column("ExperienceId")]
    public string Id { get; set; }

    public string Name { get; set; }
}
