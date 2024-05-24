using System.Text.Json.Serialization;

namespace HHVacancy.Core.Data.Models.Vacancy
{
    public class ApplicantServices
    {
        [JsonPropertyName("target_employer")]
        public TargetEmployer TargetEmployer { get; set; }
    }
}