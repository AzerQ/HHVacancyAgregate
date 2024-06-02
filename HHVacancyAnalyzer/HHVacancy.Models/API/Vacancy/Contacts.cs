using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HHVacancy.Models.API.Vacancy
{
    [ComplexType]
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