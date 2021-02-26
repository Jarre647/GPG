using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using HttpClientGenerator.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Refit;

namespace HttpClientGenerator
{
    /// <summary>
    /// Generates client proxies for <see cref="Refit"/> interfaces
    /// </summary>
    /// <remarks>
    /// By default adds custom headers, caching for attribute-marked methods and retries.
    /// To disable caching provide empty callsWrappers.
    /// To disable retries provide null for the retryStrategy.
    /// </remarks>
    public class HttpClientGenerator : IHttpClientGenerator
    {
        private readonly string _rootUrl;
        private readonly RefitSettings _refitSettings;
        private readonly List<ICallsWrapper> _wrappers;
        //private readonly List<Type> _registeredDelegatingHandlers;
        private readonly List<Func<IHttpClientBuilder, IHttpClientBuilder>> _registeredDelegatingHandlers;

        /// <summary>
        /// Kicks-off the fluent interface of building a configured <see cref="HttpClientGenerator"/>.<br/>
        /// </summary>
        public static HttpClientGeneratorBuilder BuildForUrl(string rootUrl)
        {
            return new HttpClientGeneratorBuilder(rootUrl);
        }

        /// <inheritdoc />
        public HttpClientGenerator(string rootUrl, IEnumerable<ICallsWrapper> callsWrappers,
            IEnumerable<DelegatingHandler> httpDelegatingHandlers,
            IEnumerable<Func<IHttpClientBuilder, IHttpClientBuilder>> registeredDelegatingHandlers)
            : this(rootUrl, callsWrappers, httpDelegatingHandlers, registeredDelegatingHandlers, null, null)
        {
        }

        /// <inheritdoc />
        public HttpClientGenerator(string rootUrl, 
            IEnumerable<ICallsWrapper> callsWrappers,
            IEnumerable<DelegatingHandler> httpDelegatingHandlers,
            IEnumerable<Func<IHttpClientBuilder, IHttpClientBuilder>> registeredDelegatingHandlers,
            JsonSerializerSettings jsonSerializerSettings,
            IUrlParameterFormatter urlParameterFormatter)
        {
            _rootUrl = rootUrl;
            var httpMessageHandler = CreateHttpMessageHandler(httpDelegatingHandlers.ToList().GetEnumerator());
            _refitSettings = new RefitSettings
            {
                HttpMessageHandlerFactory = () => httpMessageHandler,
                ContentSerializer = new JsonContentSerializer(jsonSerializerSettings)
            };

            if (urlParameterFormatter != null)
                _refitSettings.UrlParameterFormatter = urlParameterFormatter;

            _wrappers = callsWrappers.ToList();
            _registeredDelegatingHandlers = registeredDelegatingHandlers.ToList();
        }

        /// <inheritdoc />
        public void Register<TInterface>(
            IServiceCollection services) where TInterface : class
        {
            Register<TInterface>(services, null);
        }

        /// <inheritdoc />
        public void Register<TInterface>(
            IServiceCollection services,
            string name) where TInterface : class
        {
            var type = typeof(TInterface).Name;

            var uniqueName = $"{name}{UniqueName.ForType<TInterface>()}";

            IHttpClientBuilder httpClientBuilder = services
                .AddHttpClient(uniqueName) // unique name
                    .AddTypedClient(
                        (client, serviceProvider) => WrapIfNeeded(RestService.For<TInterface>(client, _refitSettings), name));

            httpClientBuilder
                .ConfigureHttpClient(client => client.BaseAddress = new Uri(_rootUrl));
            
            if (_registeredDelegatingHandlers != null)
            {
                foreach (var handler in _registeredDelegatingHandlers)
                {
                    handler.Invoke(httpClientBuilder);
                }
            }
        }

        /// <summary>
        /// Constructs <see cref="HttpMessageHandler"/> from an enumerable of delegating handlers 
        /// </summary>
        private static HttpMessageHandler CreateHttpMessageHandler(IEnumerator<DelegatingHandler> handlersEnumerator)
        {
            if (handlersEnumerator.MoveNext())
            {
                var current = handlersEnumerator.Current;
                current.InnerHandler = CreateHttpMessageHandler(handlersEnumerator);
                return current;
            }
            else
            {
                // if no more handlers found - add the handler actually making the calls
                return new HttpClientHandler();
            }
        }

        private T WrapIfNeeded<T>(T obj, string name)
        {
            return _wrappers.Count > 0
                ? AopProxy.Create(obj, name, _wrappers.Select(w => (AopProxy.MethodCallHandler)w.HandleMethodCall).ToArray())
                : obj;
        }
    }
}