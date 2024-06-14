using System.ComponentModel.DataAnnotations.Schema;

namespace HHVacancy.Models.DB.Entities.Links
{
    [Table("ProfessionalRoleVacancyLinks")]
    public class ProfessionalRoleVacancyLinkEntity
    {
        public string ProfessionalRoleId { get; set; }

        [ForeignKey(nameof(ProfessionalRoleId))]
        public virtual ProfessionalRoleEntity ProfessionalRole { get; set; }

        public string VacancyId { get; set; }

        [ForeignKey(nameof(VacancyId))]
        public virtual VacancyEntity Vacancy { get; set; }
    }
}
