using System.Text.Json.Serialization;

namespace HHVacancy.Models.API.Vacancy
{
    public class InsiderInterview
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}