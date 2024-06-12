using HHVacancy.Models.API.Vacancy;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HHVacancy.Models.DB.Entities
{
    [Table("VacancyDetails")]
    public class VacancyDetailsEntity
    {
        [Key]
        public string VacancyId { get; set; }

        [ForeignKey(nameof(VacancyId))]
        public VacancyEntity Vacancy { get; set; }

        public string Description { get; set; }

        // JSON Serialized
        public List<KeySkill> KeySkills { get; set; }

    }

}
