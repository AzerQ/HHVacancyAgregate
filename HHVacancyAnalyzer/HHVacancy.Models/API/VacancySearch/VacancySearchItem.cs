using HHVacancy.Models.API.Vacancy;
using System.Text.Json.Serialization;

namespace HHVacancy.Models.API.VacancySearch
{
    public class VacancySearchItem
    {
        [JsonPropertyName("accept_incomplete_resumes")]
        public bool AcceptIncompleteResumes { get; set; }

        [JsonPropertyName("alternate_url")]
        public string AlternateUrl { get; set; }

        [JsonPropertyName("apply_alternate_url")]
        public string ApplyAlternateUrl { get; set; }

        [JsonPropertyName("area")]
        public Area Area { get; set; }

        [JsonPropertyName("department")]
        public Department Department { get; set; }

        [JsonPropertyName("employer")]
        public Employer Employer { get; set; }

        [JsonPropertyName("has_test")]
        public bool HasTest { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("professional_roles")]
        public List<ProfessionalRole> ProfessionalRoles { get; set; }

        [JsonPropertyName("published_at")]

        public DateTime PublishedAt { get; set; }

        [JsonPropertyName("relations")]
        public List<string> Relations { get; set; }

        [JsonPropertyName("response_letter_required")]
        public bool ResponseLetterRequired { get; set; }

        [JsonPropertyName("salary")]
        public Salary Salary { get; set; }

        [JsonPropertyName("snippet")]
        public Snippet Snippet { get; set; }

        [JsonPropertyName("type")]
        public VacancyType Type { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("accept_temporary")]
        public bool AcceptTemporary { get; set; }

        [JsonPropertyName("address")]
        public Address Address { get; set; }

        [JsonPropertyName("adv_response_url")]
        public string AdvResponseUrl { get; set; }

        [JsonPropertyName("archived")]
        public bool Archived { get; set; }

        [JsonPropertyName("contacts")]
        public Contacts Contacts { get; set; }

        [JsonPropertyName("created_at")]

        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("insider_interview")]
        public InsiderInterview InsiderInterview { get; set; }

        [JsonPropertyName("metro_stations")]
        public List<MetroStation> MetroStations { get; set; }

        [JsonPropertyName("premium")]
        public bool Premium { get; set; }

        [JsonPropertyName("response_url")]
        public string ResponseUrl { get; set; }

        [JsonPropertyName("schedule")]
        public Schedule Schedule { get; set; }

        [JsonPropertyName("sort_point_distance")]
        public double? SortPointDistance { get; set; }

        [JsonPropertyName("working_days")]
        public List<WorkingDay> WorkingDays { get; set; }

        [JsonPropertyName("working_time_intervals")]
        public List<WorkingTimeInterval> WorkingTimeIntervals { get; set; }

        [JsonPropertyName("working_time_modes")]
        public List<WorkingTimeMode> WorkingTimeModes { get; set; }

        [JsonPropertyName("counters")]
        public Counters Counters { get; set; }

        [JsonPropertyName("employment")]
        public Employment Employment { get; set; }

        [JsonPropertyName("experience")]
        public Experience Experience { get; set; }

        [JsonPropertyName("show_logo_in_search")]
        public bool? ShowLogoInSearch { get; set; }
    }

}