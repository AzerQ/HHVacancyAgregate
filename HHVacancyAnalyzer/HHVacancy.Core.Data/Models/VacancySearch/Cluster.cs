using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HHVacancy.Core.Data.Models.VacancySearch
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