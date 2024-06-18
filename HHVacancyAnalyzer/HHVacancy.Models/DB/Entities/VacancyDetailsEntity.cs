using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HHVacancy.Models.DB.Entities
{
    [Table("VacancyDetail")]
    public class VacancyDetailsEntity
    {
        [Key]
        [JsonPropertyName("id")]
        public string VacancyId { get; set; }

        [ForeignKey(nameof(VacancyId))]
        public virtual VacancyEntity Vacancy { get; set; }

        public string Description { get; set; }


    }

}
