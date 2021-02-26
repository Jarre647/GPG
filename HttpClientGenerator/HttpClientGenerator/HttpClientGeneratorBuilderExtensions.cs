using System;
using HttpClientGenerator.AccessTokenManagement;
using HttpClientGenerator.Authentication;
using IdentityModel.Client;
using Microsoft.Extensions.DependencyInjection;

namespace HttpClientGenerator
{
    /// <summary>
    /// Provides a simple interface for configuring the <see cref="HttpClientGenerator"/> for friquient use-cases
    /// Warning! By default the Caching Strategy  is AttributeBasedCachingStrategy.
    /// </summary>
    public static class HttpClientGeneratorBuilderExtensions
    {
        /// <summary>
        /// Adds support for access token usage for sending authenticated requests.
        /// Access token is extracted from current http context.
        /// </summary>
        /// <returns></returns>
        public static HttpClientGeneratorBuilder WithClientCredentialsAuthorization(
            this HttpClientGeneratorBuilder builder,
            IServiceCollection services,
            ClientCredentialSettings credentials)
        {
            string clientKey = Guid.NewGuid().ToString();

            services.AddAccessTokenManagement(options =>
            {
                options.Client.Clients.Add(clientKey, new ClientCredentialsTokenRequest
                {
                    Address = credentials.TokenEndpoint, // "http://localhost:5000/connect/token",
                    ClientId = credentials.ClientId, // "Spa",
                    ClientSecret = credentials.ClientSecret, // "secret",
                    Scope = credentials.Scope // "userprofile" // optional
                });
            })
            .ConfigureBackchannelHttpClient();

            builder.AddDelegatingHandler(b => b.AddHttpMessageHandler(
                (serviceProvider) => new ClientCredentialsAuthenticationHandler(serviceProvider, clientKey)));

            return builder;
        }
    }
}