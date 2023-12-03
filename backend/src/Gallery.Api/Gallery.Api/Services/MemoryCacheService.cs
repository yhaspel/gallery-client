using Microsoft.Extensions.Caching.Memory;

namespace Gallery.Api.Services
{
    public class MemoryCacheService : IMemoryCacheService
    {
        private readonly IMemoryCache memoryCache;

        public MemoryCacheService(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        public bool GetFromCache<T>(string key, out T result)
        {
            return memoryCache.TryGetValue<T>(key, out result);
        }

        public void SetCacheEntry<T>(string key, T value, TimeSpan expiry)
        {
            memoryCache.Set(key, value, new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(expiry)
                .SetPriority(CacheItemPriority.Normal));
        }
    }
}
