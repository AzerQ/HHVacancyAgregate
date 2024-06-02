using System.Text.Json.Serialization;

namespace HHVacancy.Models.API.Vacancy
{
    public class VacancyConstructorTemplate
    {
        [JsonPropertyName("bottom_picture")]
        public string BottomPicture { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("top_picture")]
        public string TopPicture { get; set; }
    }
}
