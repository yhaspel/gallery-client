namespace Gallery.Api.Services
{
    public interface IMemoryCacheService
    {
        bool GetFromCache<T>(string key, out T result);
        void SetCacheEntry<T>(string key, T value, TimeSpan expiry);
    }
}
