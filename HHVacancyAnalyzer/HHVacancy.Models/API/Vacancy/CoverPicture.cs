﻿using System.Text.Json.Serialization;

namespace HHVacancy.Models.API.Vacancy
{
    public class CoverPicture
    {
        [JsonPropertyName("resized_path")]
        public string ResizedPath { get; set; }

        [JsonPropertyName("resized_width")]
        public int ResizedWidth { get; set; }

        [JsonPropertyName("resized_height")]
        public int ResizedHeight { get; set; }
    }
}
