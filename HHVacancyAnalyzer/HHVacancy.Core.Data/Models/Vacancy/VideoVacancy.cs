using System.Text.Json.Serialization;

namespace HHVacancy.Core.Data.Models.Vacancy
{
    public class VideoVacancy
    {
        [JsonPropertyName("cover_picture")]
        public CoverPicture CoverPicture { get; set; }

        [JsonPropertyName("video_url")]
        public string VideoUrl { get; set; }
    }
}
