using HHVacancy.Models.API.Vacancy;
using System.Text.Json.Serialization;

namespace HHVacancy.Models.API.VacancySearch
{
    public class VacancyDetail: IVacancyDetail
    {
        [JsonPropertyName("key_skills")]
        public List<KeySkill> KeySkills { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("professional_roles")]
        public List<ProfessionalRole> ProfessionalRoles { get; set; }
    }
}
