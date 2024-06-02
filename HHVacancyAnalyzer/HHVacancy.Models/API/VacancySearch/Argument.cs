using System.Text.Json.Serialization;

namespace HHVacancy.Models.API.VacancySearch
{
    public class Argument
    {
        [JsonPropertyName("argument")]
        public string ArgumentName { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("disable_url")]
        public string DisableUrl { get; set; }

        [JsonPropertyName("cluster_group")]
        public ClusterGroup ClusterGroup { get; set; }

        [JsonPropertyName("hex_color")]
        public string HexColor { get; set; }

        [JsonPropertyName("metro_type")]
        public string MetroType { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("value_description")]
        public string ValueDescription { get; set; }
    }

}