using System.Text.Json.Serialization;

namespace HHVacancy.Models.API.VacancySearch
{
    public class VacancySearchResult
    {
        [JsonPropertyName("found")]
        public int Found { get; set; }

        [JsonPropertyName("items")]
        public List<VacancySearchItem> Items { get; set; }

        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("pages")]
        public int Pages { get; set; }

        [JsonPropertyName("per_page")]
        public int PerPage { get; set; }

        [JsonPropertyName("clusters")]
        public List<Cluster> Clusters { get; set; }

        [JsonPropertyName("arguments")]
        public List<Argument> Arguments { get; set; }

        [JsonPropertyName("alternate_url")]
        public string AlternateUrl { get; set; }

        [JsonPropertyName("fixes")]
        public Fixes Fixes { get; set; }

        [JsonPropertyName("suggests")]
        public Suggests Suggests { get; set; }
    }
}
