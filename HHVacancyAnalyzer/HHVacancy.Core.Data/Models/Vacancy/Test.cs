using System.Text.Json.Serialization;

namespace HHVacancy.Core.Data.Models.Vacancy
{
    public class Test
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("required")]
        public bool Required { get; set; }
    }
}
