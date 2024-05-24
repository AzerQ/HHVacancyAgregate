using System.Text.Json.Serialization;

namespace HHVacancy.Core.Data.Models.Vacancy
{
    public class TargetEmployer
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}