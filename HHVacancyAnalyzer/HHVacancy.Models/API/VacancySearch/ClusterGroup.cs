using System.Text.Json.Serialization;

namespace HHVacancy.Models.API.VacancySearch
{
    public class ClusterGroup
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

}