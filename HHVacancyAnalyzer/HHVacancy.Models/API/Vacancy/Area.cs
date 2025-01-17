﻿using System.Text.Json.Serialization;

namespace HHVacancy.Models.API.Vacancy
{
    public class Area
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

}
