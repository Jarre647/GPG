using System;
using HttpClientGenerator;
using HttpClientGenerator.Caching;
using HttpClientGenerator.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using SQLRepository.Client.Contracts;

namespace SQLRepository.Client
{
    public static class AutofacExtension
    {
        public static void RegisterSQLRepositoryClient(
            this IServiceCollection services,
            SQLRepositoryClientSettings settings,
            Func<HttpClientGeneratorBuilder, HttpClientGeneratorBuilder> builderConfigure
        )
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            if (string.IsNullOrWhiteSpace(settings.ServiceUrl))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(settings.ServiceUrl));

            services.AddHttpContextAccessor();

            var clientBuilder = HttpClientGenerator.HttpClientGenerator.BuildForUrl(settings.ServiceUrl)
                .WithCachingStrategy(new AttributeBasedCachingStrategy(TimeSpan.Zero))
                .WithCorrelationIdHandler(services)
                .WithAdditionalCallsWrapper(new ExceptionHandlerCallsWrapper());

            if (builderConfigure != null)
                clientBuilder = builderConfigure(clientBuilder);

            var clientGenerator = clientBuilder.Create();

            clientGenerator.Register<IGrudgeApi>(services);

            services.AddTransient<ISQLRepositoryClient, SQLRepositoryClient>();
        }
    }
}
