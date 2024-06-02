using System.Text.Json.Serialization;

namespace HHVacancy.Models.API.VacancySearch
{
    public class Suggests
    {
        [JsonPropertyName("found")]
        public int Found { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}