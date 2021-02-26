using System;
using Autofac;
using HttpClientGenerator.Caching;
using HttpClientGenerator.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace HttpClientGenerator
{
    /// <summary>
    /// Autofac extension to register refit clients.
    /// </summary>
    public static class AutofacExtensions
    {
        /// <summary>
        /// Registers Refit client of type <typeparamref name="TInterface"/>.
        /// </summary>
        public static void RegisterClient<TInterface>(
            this IServiceCollection services,
            ContainerBuilder builder,
            string serviceUrl,
            Func<HttpClientGeneratorBuilder, HttpClientGeneratorBuilder> builderConfigure = null)
            where TInterface : class
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (string.IsNullOrWhiteSpace(serviceUrl))
                throw new ArgumentException("Value cannot be empty.", nameof(serviceUrl));

            var clientBuilder = global::HttpClientGenerator.HttpClientGenerator.BuildForUrl(serviceUrl)
                .WithCorrelationIdHandler(services)
                .WithCachingStrategy(new AttributeBasedCachingStrategy())
                .WithAdditionalCallsWrapper(new ExceptionHandlerCallsWrapper());
            
            clientBuilder = builderConfigure?.Invoke(clientBuilder) ?? clientBuilder.WithoutRetries();

            clientBuilder.Create().Register<TInterface>(services);
        }
    }
}
