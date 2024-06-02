using System.Text.Json.Serialization;

namespace HHVacancy.Models.API.Vacancy
{
    public class ApplicantServices
    {
        [JsonPropertyName("target_employer")]
        public TargetEmployer TargetEmployer { get; set; }
    }
}