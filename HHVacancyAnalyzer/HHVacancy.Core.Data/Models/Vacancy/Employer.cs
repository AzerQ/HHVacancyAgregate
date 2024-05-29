using System.Text.Json.Serialization;

namespace HHVacancy.Core.Data.Models.Vacancy
{
    public class EmployerEntity
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("trusted")]
        public bool Trusted { get; set; }

        [JsonPropertyName("accredited_it_employer")]
        public bool AccreditedItEmployer { get; set; }

        [JsonPropertyName("alternate_url")]
        public string AlternateUrl { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("logo_urls")]
        public LogoUrls LogoUrls { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("vacancies_url")]
        public string VacanciesUrl { get; set; }

        [JsonPropertyName("blacklisted")]
        public bool Blacklisted { get; set; }

        [JsonPropertyName("applicant_services")]
        public ApplicantServices ApplicantServices { get; set; }
    }
}