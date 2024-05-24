using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HHVacancy.Core.Data.Models.Vacancy
{
    public class Contacts
    {
        [JsonPropertyName("call_tracking_enabled")]
        public bool CallTrackingEnabled { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("phones")]
        public List<Phone> Phones { get; set; }
    }
}