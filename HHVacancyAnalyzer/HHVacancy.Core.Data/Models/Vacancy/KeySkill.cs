using System.Text.Json.Serialization;

namespace HHVacancy.Core.Data.Models.Vacancy
{
    public class KeySkill
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

}
