﻿using System.Text.Json.Serialization;

namespace HHVacancy.Models.API.Vacancy
{
    public class WorkingTimeInterval
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
