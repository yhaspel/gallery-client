using System.Text.Json;

namespace Gallery.Api.Services
{
    public class PicsumService : IPicsumService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IMemoryCacheService memoryCacheService;

        public PicsumService(IHttpClientFactory httpClientFactory,
            IMemoryCacheService memoryCacheService)
        {
            this.httpClientFactory = httpClientFactory;
            this.memoryCacheService = memoryCacheService;
        }

        public async Task<IList<GalleryDto>> GetPageAsync(int page, int limit, CancellationToken cancellationToken)
        {
            var httpClient = httpClientFactory.CreateClient(nameof(PicsumService));
            httpClient.BaseAddress = new Uri("https://picsum.photos/");
            var request = new HttpRequestMessage(HttpMethod.Get, $"v2/list?page={page}&limit={limit}");
            var response = await httpClient.SendAsync(request, cancellationToken);
            var content = await response.Content.ReadAsStringAsync();
            var pics = JsonSerializer.Deserialize<List<Gallery>>(content);
            return pics.Select(x => new GalleryDto
            {
                Author = x.Author,
                DownloadUrl = x.DownloadUrl,
                Height = x.Height,
                Id = x.Id,
                Url = x.Url,
                Width = x.Width,
            }).ToList();
        }

        public async Task<IList<GalleryDto>> GetRandomListBasedOnPagingAsync(int limit, CancellationToken cancellationToken)
        {
            int page = 1;
            var cacheKey = "gallery_page_rnd";
            var cacheValue = $"{page}_{limit}";
            IList<GalleryDto> newPicsPage;
            memoryCacheService.GetFromCache(cacheKey, out string pageRequestValue);
            if (string.IsNullOrEmpty(pageRequestValue))
            {
                page = int.Parse(pageRequestValue.Split("_").First()) + 1;
                newPicsPage = await GetPageAsync(page, limit, cancellationToken);
                memoryCacheService.SetCacheEntry(cacheKey, cacheValue, TimeSpan.FromHours(1));
                return newPicsPage;
            }
            newPicsPage = await GetPageAsync(page, limit, cancellationToken);
            memoryCacheService.SetCacheEntry(cacheKey, cacheValue, TimeSpan.FromHours(1));
            return newPicsPage;
        }
    }
}
