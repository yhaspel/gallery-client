namespace Gallery.Api
{
    public class GalleryDto
    {
        public string Id { get; set; }
        public string Author { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Url { get; set; }
        public string DownloadUrl { get; set; }
    }
}