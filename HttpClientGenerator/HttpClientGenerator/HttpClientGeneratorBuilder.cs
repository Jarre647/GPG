using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Autofac;
using HttpClientGenerator.Authentication;
using HttpClientGenerator.Caching;
using HttpClientGenerator.Handlers;
using HttpClientGenerator.Infrastructure;
using HttpClientGenerator.Retries;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json;
using Refit;

namespace HttpClientGenerator
{
    /// <summary>
    /// Provides a simple interface for configuring the <see cref="HttpClientGenerator"/> for friquient use-cases
    /// Warning! By default the Caching Strategy  is AttributeBasedCachingStrategy.
    /// </summary>
    public class HttpClientGeneratorBuilder
    {
        /// <inheritdoc />
        public HttpClientGeneratorBuilder(string rootUrl)
        {
            _rootUrl = rootUrl ?? throw new ArgumentNullException(nameof(rootUrl));
        }

        private string _rootUrl;
        private string _apiKey;
        private IRetryStrategy _retryStrategy = new LinearRetryStrategy();
        private TimeSpan? _timeout = null;
        private ICachingStrategy _cachingStrategy = new AttributeBasedCachingStrategy();
        private List<ICallsWrapper> _additionalCallsWrappers = new List<ICallsWrapper>();
        private List<DelegatingHandler> _additionalDelegatingHandlers = new List<DelegatingHandler>();
        private List<Func<IHttpClientBuilder, IHttpClientBuilder>> _registeredDelegatingHandlers = new List<Func<IHttpClientBuilder, IHttpClientBuilder>>();
        private JsonSerializerSettings _jsonSerializerSettings;
        private IUrlParameterFormatter _urlParameterFormatter;

        /// <summary>
        /// Specifies the value of the api-key header to add to the requests.
        /// If not called - no api-key is added. 
        /// </summary>
        public HttpClientGeneratorBuilder WithApiKey(string apiKey)
        {
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
            return this;
        }

        /// <summary>
        /// Adds support for access token usage for sending authenticated requests.
        /// Access token is extracted from current http context.
        /// </summary>
        /// <returns></returns>
        public HttpClientGeneratorBuilder WithAccessTokenAuthorization(IServiceCollection services)
        {
            services.TryAddTransient<AccessTokenAuthenticationHandler>();

            _registeredDelegatingHandlers.Add(builder => builder.AddHttpMessageHandler<AccessTokenAuthenticationHandler>());

            return this;
        }

        /// <summary>
        /// Adds delegating handler to the build http client
        /// </summary>
        /// <param name="handler"></param>
        public void AddDelegatingHandler(Func<IHttpClientBuilder, IHttpClientBuilder> handler)
        {
            _registeredDelegatingHandlers.Add(handler);
        }

        /// <summary>
        /// Adds support for for sending authenticated requests.
        /// Access token is received from specified delegate.
        /// </summary>
        /// <returns></returns>
        public HttpClientGeneratorBuilder WithAuthentication(Func<IServiceProvider, Task<string>> authorizationHeaderValueGetter)
        {
            _registeredDelegatingHandlers.Add(builder => builder.AddHttpMessageHandler(
                (serviceProvider) => new AuthenticatedHttpClientHandler(serviceProvider, authorizationHeaderValueGetter)));

            return this;
        }

        /// <summary>
        /// Sets the retry stategy used to handle requests failures. If not called - the default one is used.
        /// </summary>
        public HttpClientGeneratorBuilder WithRetriesStrategy(IRetryStrategy retryStrategy)
        {
            _retryStrategy = retryStrategy ?? throw new ArgumentNullException(nameof(retryStrategy));
            return this;
        }

        /// <summary>
        /// Configures not to use retries
        /// </summary>
        public HttpClientGeneratorBuilder WithoutRetries()
        {
            _retryStrategy = null;
            return this;
        }

        /// <summary>
        /// Configures to use timeout.
        /// </summary>
        /// <exception cref="System.TimeoutException">Throws for any client's generated method</exception>
        public HttpClientGeneratorBuilder WithTimeout(TimeSpan timeout)
        {
            _timeout = timeout;
            return this;
        }

        /// <summary>
        /// Configures the caching strategy to use. If not called - the default one is used.
        /// </summary>
        public HttpClientGeneratorBuilder WithCachingStrategy(ICachingStrategy cachingStrategy)
        {
            _cachingStrategy = cachingStrategy ?? throw new ArgumentNullException(nameof(cachingStrategy));
            return this;
        }

        /// <summary>
        /// Configures not to use methods results caching
        /// </summary>
        public HttpClientGeneratorBuilder WithoutCaching()
        {
            _cachingStrategy = null;
            return this;
        }


        /// <summary>
        /// Adds an additional method call wrapper
        /// </summary>
        public HttpClientGeneratorBuilder WithAdditionalCallsWrapper(ICallsWrapper callsWrapper)
        {
            _additionalCallsWrappers.Add(callsWrapper ?? throw new ArgumentNullException(nameof(callsWrapper)));
            return this;
        }

        /// <summary>
        /// Adds an additional http delegating handler
        /// </summary>
        public HttpClientGeneratorBuilder WithAdditionalDelegatingHandler(DelegatingHandler delegatingHandler)
        {
            _additionalDelegatingHandlers.Add(delegatingHandler ?? throw new ArgumentNullException(nameof(delegatingHandler)));
            return this;
        }

        /// <summary>
        /// Configure custom json serializer settings
        /// </summary>
        public HttpClientGeneratorBuilder WithJsonSerializerSettings(JsonSerializerSettings settings)
        {
            _jsonSerializerSettings = settings;
            return this;
        }

        /// <summary>
        ///     Configure custom <see cref="IUrlParameterFormatter" /> for refit settings.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="urlParameterFormatter" /> is null.
        /// </exception>
        public HttpClientGeneratorBuilder WithUrlParameterFormatter(
            IUrlParameterFormatter urlParameterFormatter)
        {
            _urlParameterFormatter =
                urlParameterFormatter ?? throw new ArgumentNullException(nameof(urlParameterFormatter));
            return this;
        }

        /// <summary>
        /// Configure client to log request and response data if status code of response does not equal 2xx.
        /// </summary>
        /// <param name="logFactory">Factory to create instance of <see cref="ILogger"/>.</param>
        /// <returns></returns>
        public HttpClientGeneratorBuilder WithRequestErrorLogging(ILoggerFactory logFactory)
        {
            var handler = new LogHttpRequestErrorHttpClientHandler(logFactory ?? throw new ArgumentNullException(nameof(logFactory)));
            _additionalDelegatingHandlers.Add(handler);
            return this;
        }

        /// <summary>
        /// Adds support for correlation ID for outgoing requests.
        /// Correlation ID is extracted from current http context.
        /// </summary>
        /// <returns></returns>
        public HttpClientGeneratorBuilder WithCorrelationIdHandler(IServiceCollection services)
        {
            services.TryAddTransient<CorrelationIdHandler>();

            _registeredDelegatingHandlers.Add(builder => builder.AddHttpMessageHandler<CorrelationIdHandler>());

            return this;
        }

        public HttpClientGeneratorBuilder WithCorrelationIdHandler(ContainerBuilder builder)
        {
            builder
                .RegisterType<CorrelationIdHandler>()
                .InstancePerLifetimeScope();

            _registeredDelegatingHandlers.Add(b => b.AddHttpMessageHandler<CorrelationIdHandler>());

            return this;
        }

        /// <summary>
        /// Creates the configured <see cref="HttpClientGenerator"/> instance
        /// </summary>
        public HttpClientGenerator Create()
        {
            return new HttpClientGenerator(_rootUrl, 
                GetCallsWrappers(),
                GetDelegatingHandlers(),
                _registeredDelegatingHandlers,
                _jsonSerializerSettings, 
                _urlParameterFormatter);
        }


        private IEnumerable<DelegatingHandler> GetDelegatingHandlers()
        {
            if (_timeout != null)
            {
                yield return new TimeoutHandler(_timeout.Value);
            }

            if (_additionalDelegatingHandlers != null)
            {
                foreach (var additionalDelegatingHandler in _additionalDelegatingHandlers)
                {
                    yield return additionalDelegatingHandler;
                }
            }

            if (_apiKey != null)
            {
                yield return new ApiKeyHeaderHttpClientHandler(_apiKey);
            }

            yield return new UserAgentHeaderHttpClientHandler(GetDefaultUserAgent());

            if (_retryStrategy != null)
            {
                yield return new RetryingHttpClientHandler(_retryStrategy);
            }
        }

        private IEnumerable<ICallsWrapper> GetCallsWrappers()
        {
            if (_additionalCallsWrappers != null)
            {
                foreach (var additionalCallsWrapper in _additionalCallsWrappers)
                {
                    yield return additionalCallsWrapper;
                }
            }

            if (_cachingStrategy != null)
            {
                var cacheProvider = new RemovableAsyncCacheProvider(new MemoryCache(new MemoryCacheOptions()));
                CachingCallsWrapper cachingCallsWrapper = new CachingCallsWrapper(_cachingStrategy, cacheProvider);
                //if (cacheManager != null)
                //{
                //    cacheManager.OnInvalidate += cachingCallsWrapper.InvalidateCache;
                //}

                yield return cachingCallsWrapper;
            }
        }

        private static string GetDefaultUserAgent()
        {
            return PlatformServices.Default.Application.ApplicationName + " v" +
                   PlatformServices.Default.Application.ApplicationVersion;
        }
    }
}