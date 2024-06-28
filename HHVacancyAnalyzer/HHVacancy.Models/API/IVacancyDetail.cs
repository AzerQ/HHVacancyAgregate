using HHVacancy.Models.API.Vacancy;
using System.Text.Json.Serialization;

namespace HHVacancy.Models.API
{
    /// <summary>
    /// Предоставление дополнительных данных о вакансии
    /// </summary>
    public interface IVacancyDetail
    {
        List<KeySkill> KeySkills { get; set; }

        string Description { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        public List<ProfessionalRole> ProfessionalRoles { get; set; }
    }
}
