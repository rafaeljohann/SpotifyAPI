using Microsoft.Extensions.Caching.Memory;

namespace Spotify.Infra.CrossCutting.Extensions
{
    public static class IMemoryCacheExtensions
    {
        public static async Task<T> GetOrCreateValueAsync<T>(
            this IMemoryCache cache,
            string key,
            Func<Task<T>> factory,
            MemoryCacheEntryOptions options = null)
        {
            T result;

            if (cache.TryGetValue<T>(key, out result))
                return result;

            var value = await factory.Invoke();

            if (value is not null)
                cache.Set(key, value, options ?? new MemoryCacheEntryOptions());

            return value;
        }
    }
}