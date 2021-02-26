using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace HttpClientGenerator
{
    /// <summary>
    /// Contains extension methods for registering api http client.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers service api implementation for the specified service type.
        /// </summary>
        /// <typeparam name="TService">Type of api interface</typeparam>
        /// <param name="services">Services collection</param>
        /// <returns>Http client builder for specified service api</returns>
        public static ServiceHttpClientBuilder AddServiceApi<TService>(this IServiceCollection services) where TService : class
        {
            IHttpClientBuilder httpClientBuilder = services.AddRefitClient<TService>();

            var builder = new ServiceHttpClientBuilder(services, httpClientBuilder);

            return builder;
        }
    }
}
