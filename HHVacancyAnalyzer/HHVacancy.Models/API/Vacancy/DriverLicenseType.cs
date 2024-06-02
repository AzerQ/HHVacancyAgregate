using System.Text.Json.Serialization;

namespace HHVacancy.Models.API.Vacancy
{
    public class DriverLicenseType
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }

}
