using System.Text.Json.Serialization;

namespace HHVacancy.Models.API.Vacancy
{
    public class KeySkill
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

}
