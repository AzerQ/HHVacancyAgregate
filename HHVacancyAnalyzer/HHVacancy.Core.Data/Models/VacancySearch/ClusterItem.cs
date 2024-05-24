using System.Text.Json.Serialization;

namespace HHVacancy.Core.Data.Models.VacancySearch
{
    public class ClusterItem
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("metro_line")]
        public object MetroLine { get; set; }

        [JsonPropertyName("metro_station")]
        public object MetroStation { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}