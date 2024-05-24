using System.Text.Json.Serialization;

namespace HHVacancy.Core.Data.Models.VacancySearch
{
    public class Fixes
    {
        [JsonPropertyName("fixed")]
        public string Fixed { get; set; }

        [JsonPropertyName("original")]
        public string Original { get; set; }
    }
}