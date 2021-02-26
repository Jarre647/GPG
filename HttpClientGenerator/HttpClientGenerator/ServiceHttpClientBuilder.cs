using System;
using System.Net.Http;
using System.Threading.Tasks;
using HttpClientGenerator.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace HttpClientGenerator
{
    /// <summary>
    /// Utility class for building api interface.
    /// </summary>
    public class ServiceHttpClientBuilder
    {
        private readonly IServiceCollection _serviceCollection;
        private readonly IHttpClientBuilder _httpClientBuilder;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="serviceCollection">Services collection (DI container)</param>
        /// <param name="httpClientBuilder">Http client builder</param>
        internal ServiceHttpClientBuilder(IServiceCollection serviceCollection, IHttpClientBuilder httpClientBuilder)
        {
            _serviceCollection = serviceCollection;
            _httpClientBuilder = httpClientBuilder;
        }

        /// <summary>
        /// Adds a delegate used to configure http client.
        /// </summary>
        /// <param name="configureClient"></param>
        /// <returns></returns>
        public ServiceHttpClientBuilder ConfigureHttpClient(Action<HttpClient> configureClient)
        {
            _httpClientBuilder.ConfigureHttpClient(configureClient);
            return this;
        }

        /// <summary>
        /// Adds an additional message handler.
        /// </summary>
        /// <typeparam name="THandler"></typeparam>
        /// <returns></returns>
        public ServiceHttpClientBuilder AddHttpMessageHandler<THandler>() where THandler : DelegatingHandler
        {
            _httpClientBuilder.AddHttpMessageHandler<THandler>();
            return this;
        }

        /// <summary>
        /// Adds support for access token usage for sending authenticated requests.
        /// Access token is extracted from current http context.
        /// </summary>
        /// <returns></returns>
        public ServiceHttpClientBuilder WithAccessTokenAuthorization()
        {
            _serviceCollection.TryAddTransient<AccessTokenAuthenticationHandler>();

            _httpClientBuilder.AddHttpMessageHandler<AccessTokenAuthenticationHandler>();

            return this;
        }

        /// <summary>
        /// Adds a delegate that is used to provide token value for authenticated requests.
        /// </summary>
        /// <param name="authorizationHeaderValueGetter"></param>
        /// <returns></returns>
        public ServiceHttpClientBuilder WithAuthorization(Func<IServiceProvider, Task<string>> authorizationHeaderValueGetter)
        {
            _httpClientBuilder.AddHttpMessageHandler(
                (serviceProvider) => new AuthenticatedHttpClientHandler(serviceProvider, authorizationHeaderValueGetter));
            return this;
        }
    }
}
