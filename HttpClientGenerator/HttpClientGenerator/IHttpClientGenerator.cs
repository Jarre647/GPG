using Microsoft.Extensions.DependencyInjection;

namespace HttpClientGenerator
{
    /// <summary>
    /// Generates client proxies for <see cref="Refit"/> interfaces
    /// </summary>
    public interface IHttpClientGenerator
    {
        /// <summary>
        /// Register the proxy in dependency container
        /// </summary>
        void Register<TInterface>(IServiceCollection services, string name = null) where TInterface : class;
    }
}