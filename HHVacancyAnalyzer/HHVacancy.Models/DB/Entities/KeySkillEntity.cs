using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HHVacancy.Models.DB.Entities.Links;

namespace HHVacancy.Models.DB.Entities
{

    [Table("KeySkills")]
    public class KeySkillEntity
    {
        [Key]
        [Column("KeySkillId")]
        public string Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<KeySkillVacancyLinkEntity> VacancyKeySkillsLinks { get; set; }
    }
}
