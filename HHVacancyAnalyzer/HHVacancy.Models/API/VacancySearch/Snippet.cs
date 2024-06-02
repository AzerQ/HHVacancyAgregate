using System.Text.Json.Serialization;

namespace HHVacancy.Models.API.VacancySearch
{
    public class Snippet
    {
        [JsonPropertyName("requirement")]
        public string Requirement { get; set; }

        [JsonPropertyName("responsibility")]
        public string Responsibility { get; set; }
    }
}