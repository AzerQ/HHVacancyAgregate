using System.Text.Json.Serialization;

namespace HHVacancy.Models.API.VacancySearch
{
    public class Cluster
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("items")]
        public List<ClusterItem> Items { get; set; }
    }
}