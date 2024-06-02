using System.Text.Json.Serialization;

namespace HHVacancy.Models.API.Vacancy
{
    public class Salary
    {
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("from")]
        public int? From { get; set; }

        [JsonPropertyName("gross")]
        public bool? Gross { get; set; }

        [JsonPropertyName("to")]
        public int? To { get; set; }
    }
}
