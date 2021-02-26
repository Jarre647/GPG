using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using HttpClientGenerator.AccessTokenManagement;
using IdentityModel.AspNetCore.AccessTokenManagement;

namespace HttpClientGenerator.Authentication
{
    /// <summary>
    /// Gets access token from IdentityModel provider for client credentials.
    /// </summary>
    class ClientCredentialsAuthenticationHandler : DelegatingHandler
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly string _clientKey;

        public ClientCredentialsAuthenticationHandler(
            IServiceProvider serviceProvider,
            string clientKey)
        {
            _serviceProvider = serviceProvider;
            _clientKey = clientKey;
        }

        /// <summary>
        /// Sends request
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var accessTokenManagementService = (IAccessTokenManagementService)_serviceProvider.GetService(typeof(IAccessTokenManagementService));

            string token = await accessTokenManagementService.GetClientAccessTokenAsync(_clientKey);

            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
