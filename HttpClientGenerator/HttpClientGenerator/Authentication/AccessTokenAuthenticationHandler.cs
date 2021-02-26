using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace HttpClientGenerator.Authentication
{
    /// <summary>
    /// Gets access token from current context and uses it as bearer authentication header.
    /// </summary>
    class AccessTokenAuthenticationHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        public AccessTokenAuthenticationHandler(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Sends request
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpContext context = this.httpContextAccessor.HttpContext;

            if (context == null)
                throw new InvalidOperationException("HttpContext is not defined.");

            var token = await context.GetTokenAsync("access_token");

            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
