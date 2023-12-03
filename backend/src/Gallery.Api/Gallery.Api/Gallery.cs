using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Gallery.Api
{
    [ExcludeFromCodeCoverage]
    public class Gallery
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("author")]
        public string Author { get; set; }
        [JsonPropertyName("width")]
        public int Width { get; set; }
        [JsonPropertyName("height")]
        public int Height { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("download_url")]
        public string DownloadUrl { get; set; }
    }
}