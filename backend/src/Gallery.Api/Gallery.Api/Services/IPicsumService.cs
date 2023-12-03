namespace Gallery.Api.Services
{
    public interface IPicsumService
    {
        Task<IList<GalleryDto>> GetPageAsync(int page, int limit, CancellationToken cancellationToken);
        Task<IList<GalleryDto>> GetRandomListBasedOnPagingAsync(int limit, CancellationToken cancellationToken);
    }
}
