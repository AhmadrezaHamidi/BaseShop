using AhmadShop.Application.ExternalInterfaces.Caching;
using Microsoft.Extensions.Caching.Memory;

namespace CHMS.Infrastructure.Caching;

internal sealed class CacheService : ICacheService
{
    private readonly IMemoryCache _cache;

    public CacheService(IMemoryCache cache)
    {
        _cache = cache;
    }

    public Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
    {
        // Retrieve the cached value
        if (_cache.TryGetValue(key, out T? cacheValue))
        {
            return Task.FromResult(cacheValue);
        }

        // Return default if not found
        return Task.FromResult<T?>(default);
    }

    public Task SetAsync<T>(
        string key,
        T value,
        TimeSpan? expiration = null,
        CancellationToken cancellationToken = default)
    {
        // Set the cache entry with optional expiration
        var cacheEntryOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = expiration ?? TimeSpan.FromMinutes(5) // Default expiration of 5 minutes
        };

        _cache.Set(key, value, cacheEntryOptions);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(string key, CancellationToken cancellationToken = default)
    {
        // Remove the cache entry
        _cache.Remove(key);
        return Task.CompletedTask;
    }
}
