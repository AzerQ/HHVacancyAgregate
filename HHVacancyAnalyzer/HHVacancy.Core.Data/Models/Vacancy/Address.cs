using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HHVacancy.Core.Data.Models.Vacancy
{
    public class Address
    {
        [JsonPropertyName("building")]
        public string Building { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("lat")]
        public double? Lat { get; set; }

        [JsonPropertyName("lng")]
        public double? Lng { get; set; }

        [JsonPropertyName("street")]
        public string Street { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("metro_stations")]
        public List<MetroStation> MetroStations { get; set; }
    }
}
