using System.Text.Json.Serialization;

namespace HHVacancy.Core.Data.Models.VacancySearch
{
    public class Counters
    {
        [JsonPropertyName("responses")]
        public int Responses { get; set; }

        [JsonPropertyName("total_responses")]
        public int TotalResponses { get; set; }
    }
}