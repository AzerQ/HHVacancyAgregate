using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HHVacancy.Models.DB.Entities;

[Table("VacancyTypes")]
public class VacancyTypeEntity
{
    [Key]
    [Column("VacancyTypeId")]
    public string Id { get; set; }

    public string Name { get; set; }
}