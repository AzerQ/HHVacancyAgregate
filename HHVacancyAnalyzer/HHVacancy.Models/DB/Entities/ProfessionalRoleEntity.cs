using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HHVacancy.Models.DB.Entities;


[Table("ProfessionalRoles")]
public class ProfessionalRoleEntity
{
    [Key]
    [Column("ProfessionalRoleId")]
    public string Id { get; set; }

    public string Name { get; set; }

    public virtual List<VacancyEntity> VacancyEntities { get; set; }
}