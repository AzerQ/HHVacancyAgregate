﻿using System.Text.Json.Serialization;

namespace HHVacancy.Core.Data.Models.Vacancy
{
    public class Level
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
