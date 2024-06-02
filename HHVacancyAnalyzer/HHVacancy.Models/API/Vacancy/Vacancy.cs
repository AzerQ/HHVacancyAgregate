using System.Text.Json.Serialization;

namespace HHVacancy.Models.API.Vacancy
{
    public class Vacancy
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("key_skills")]
        public List<KeySkill> KeySkills { get; set; }

        [JsonPropertyName("schedule")]
        public Schedule Schedule { get; set; }

        [JsonPropertyName("accept_handicapped")]
        public bool AcceptHandicapped { get; set; }

        [JsonPropertyName("accept_kids")]
        public bool AcceptKids { get; set; }

        [JsonPropertyName("experience")]
        public Experience Experience { get; set; }

        [JsonPropertyName("alternate_url")]
        public string AlternateUrl { get; set; }

        [JsonPropertyName("apply_alternate_url")]
        public string ApplyAlternateUrl { get; set; }

        [JsonPropertyName("archived")]
        public bool Archived { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("area")]
        public Area Area { get; set; }

        [JsonPropertyName("initial_created_at")]
        public DateTime InitialCreatedAt { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("published_at")]
        public DateTime PublishedAt { get; set; }

        [JsonPropertyName("response_letter_required")]
        public bool ResponseLetterRequired { get; set; }

        [JsonPropertyName("type")]
        public TypeInfo Type { get; set; }

        [JsonPropertyName("has_test")]
        public bool HasTest { get; set; }

        [JsonPropertyName("billing_type")]
        public BillingType BillingType { get; set; }

        [JsonPropertyName("allow_messages")]
        public bool AllowMessages { get; set; }

        [JsonPropertyName("premium")]
        public bool Premium { get; set; }

        [JsonPropertyName("driver_license_types")]
        public List<DriverLicenseType> DriverLicenseTypes { get; set; }

        [JsonPropertyName("accept_incomplete_resumes")]
        public bool AcceptIncompleteResumes { get; set; }

        [JsonPropertyName("professional_roles")]
        public List<ProfessionalRole> ProfessionalRoles { get; set; }

        [JsonPropertyName("approved")]
        public bool Approved { get; set; }

        [JsonPropertyName("accept_temporary")]
        public bool AcceptTemporary { get; set; }

        [JsonPropertyName("branded_description")]
        public string BrandedDescription { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("contacts")]
        public Contacts Contacts { get; set; }

        [JsonPropertyName("department")]
        public Department Department { get; set; }

        [JsonPropertyName("employer")]
        public Employer Employer { get; set; }

        [JsonPropertyName("employment")]
        public Employment Employment { get; set; }

        [JsonPropertyName("insider_interview")]
        public InsiderInterview InsiderInterview { get; set; }

        [JsonPropertyName("languages")]
        public List<Language> Languages { get; set; }

        [JsonPropertyName("negotiations_url")]
        public string NegotiationsUrl { get; set; }

        [JsonPropertyName("relations")]
        public List<string> Relations { get; set; }

        [JsonPropertyName("response_url")]
        public string ResponseUrl { get; set; }

        [JsonPropertyName("salary")]
        public Salary Salary { get; set; }

        [JsonPropertyName("suitable_resumes_url")]
        public string SuitableResumesUrl { get; set; }

        [JsonPropertyName("test")]
        public Test Test { get; set; }

        [JsonPropertyName("vacancy_constructor_template")]
        public VacancyConstructorTemplate VacancyConstructorTemplate { get; set; }

        [JsonPropertyName("video_vacancy")]
        public VideoVacancy VideoVacancy { get; set; }

        [JsonPropertyName("working_days")]
        public List<WorkingDay> WorkingDays { get; set; }

        [JsonPropertyName("working_time_intervals")]
        public List<WorkingTimeInterval> WorkingTimeIntervals { get; set; }

        [JsonPropertyName("working_time_modes")]
        public List<WorkingTimeMode> WorkingTimeModes { get; set; }

        [JsonPropertyName("hidden")]
        public bool Hidden { get; set; }

        [JsonPropertyName("address")]
        public Address Address { get; set; }
    }
}
