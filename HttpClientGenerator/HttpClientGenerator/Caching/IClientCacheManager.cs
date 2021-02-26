using System;
using System.Threading.Tasks;

namespace HttpClientGenerator.Caching
{
    public delegate Task InvalidateCache();

    public interface IClientCacheManager : IDisposable
    {
        Task InvalidateCacheAsync();

        event InvalidateCache OnInvalidate;
    }
}
