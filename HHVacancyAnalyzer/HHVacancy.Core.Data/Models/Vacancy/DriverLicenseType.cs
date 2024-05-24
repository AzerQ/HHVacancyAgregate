using System.Text.Json.Serialization;

namespace HHVacancy.Core.Data.Models.Vacancy
{
    public class DriverLicenseType
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }

}
