using System.ComponentModel.DataAnnotations.Schema;

namespace HHVacancy.Models.DB.Entities
{
    [Table("KeySkillVacancyLinks")]
    public class KeySkillVacancyLinkEntity
    {
        public string KeySkillId { get; set; }

        [ForeignKey(nameof(KeySkillId))]
        public virtual KeySkillEntity KeySkill { get; set; }

        public string VacancyId { get; set; }

        [ForeignKey(nameof(VacancyId))]
        public virtual VacancyEntity Vacancy { get; set; }
    }
}
