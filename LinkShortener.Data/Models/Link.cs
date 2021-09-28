using System.Text.Json.Serialization;

namespace LinkShortener.Data.Models
{
    public class Link
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("OriginalLink")]
        public string OriginalLink { get; set; }

        [JsonPropertyName("ShortenedLink")]
        public string ShortenedLink { get; set; }
    }
}
