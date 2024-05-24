using System.Text.Json.Serialization;

namespace HHVacancy.Core.Data.Models.Vacancy
{
    public class MetroStation
    {
        [JsonPropertyName("station_id")]
        public string StationId { get; set; }

        [JsonPropertyName("station_name")]
        public string StationName { get; set; }

        [JsonPropertyName("line_id")]
        public string LineId { get; set; }

        [JsonPropertyName("line_name")]
        public string LineName { get; set; }

        [JsonPropertyName("lat")]
        public double? Lat { get; set; }

        [JsonPropertyName("lng")]
        public double? Lng { get; set; }
    }
}
