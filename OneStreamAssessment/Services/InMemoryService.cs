using Microsoft.Extensions.Caching.Memory;
using System;

public class InMemoryService
{
    private readonly IMemoryCache _cache;

    public InMemoryService(IMemoryCache cache)
    {
        _cache = cache;
    }

    public void SetCacheItem(string key, string value)
    {
        _cache.Set(key, value, TimeSpan.FromMinutes(30));
    }

    public string GetCacheItem(string key)
    {
        return _cache.TryGetValue(key, out string value) ? value : null;
    }
}
