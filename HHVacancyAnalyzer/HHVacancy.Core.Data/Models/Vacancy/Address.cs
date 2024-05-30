using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HHVacancy.Core.Data.Models.Vacancy
{
    [ComplexType]
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
