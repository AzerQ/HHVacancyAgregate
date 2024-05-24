using System.Text.Json.Serialization;

namespace HHVacancy.Core.Data.Models.Vacancy
{
    public class Language
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

    }
}