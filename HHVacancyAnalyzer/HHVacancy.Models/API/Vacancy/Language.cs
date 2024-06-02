using System.Text.Json.Serialization;

namespace HHVacancy.Models.API.Vacancy
{
    public class Language
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

    }
}