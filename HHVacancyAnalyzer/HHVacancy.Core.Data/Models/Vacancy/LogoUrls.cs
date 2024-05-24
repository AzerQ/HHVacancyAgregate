using System.Text.Json.Serialization;

namespace HHVacancy.Core.Data.Models.Vacancy
{
    public class LogoUrls
    {
        [JsonPropertyName("90")]
        public string Size90 { get; set; }

        [JsonPropertyName("240")]
        public string Size240 { get; set; }

        [JsonPropertyName("original")]
        public string Original { get; set; }
    }
}