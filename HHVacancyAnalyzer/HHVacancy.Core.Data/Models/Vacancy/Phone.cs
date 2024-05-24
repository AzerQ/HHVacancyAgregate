using System.Text.Json.Serialization;

namespace HHVacancy.Core.Data.Models.Vacancy
{
    public class Phone
    {
        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("comment")]
        public string Comment { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("formatted")]
        public string Formatted { get; set; }

        [JsonPropertyName("number")]
        public string Number { get; set; }
    }
}