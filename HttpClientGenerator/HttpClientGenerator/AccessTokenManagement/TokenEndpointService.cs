// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace HttpClientGenerator.AccessTokenManagement
{
    /// <summary>
    /// Implements token endpoint operations using IdentityModel
    /// </summary>
    public class TokenEndpointService : ITokenEndpointService
    {
        private readonly ITokenClientConfigurationService _configService;
        private readonly HttpClient _httpClient;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="configService"></param>
        /// <param name="httpClientFactory"></param>
        public TokenEndpointService(
            ITokenClientConfigurationService configService,
            IHttpClientFactory httpClientFactory)
        {
            _configService = configService;
            _httpClient = httpClientFactory.CreateClient(AccessTokenManagementDefaults.BackChannelHttpClientName);
        }

        /// <inheritdoc/>
        public async Task<TokenResponse> RequestClientAccessToken(string clientName = AccessTokenManagementDefaults.DefaultTokenClientName)
        {
            var requestDetails = await _configService.GetClientCredentialsRequestAsync(clientName);

            return await _httpClient.RequestClientCredentialsTokenAsync(requestDetails);
        }
    }
}