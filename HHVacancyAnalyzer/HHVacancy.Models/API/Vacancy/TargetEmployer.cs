using System.Text.Json.Serialization;

namespace HHVacancy.Models.API.Vacancy
{
    public class TargetEmployer
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}