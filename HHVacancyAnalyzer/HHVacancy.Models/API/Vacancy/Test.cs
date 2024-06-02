using System.Text.Json.Serialization;

namespace HHVacancy.Models.API.Vacancy
{
    public class Test
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("required")]
        public bool Required { get; set; }
    }
}
