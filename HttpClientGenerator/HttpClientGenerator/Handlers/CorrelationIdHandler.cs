using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HttpClientGenerator.Handlers
{
    /// <summary>
    /// Gets correlation ID from current context and passes it to the request.
    /// </summary>
    class CorrelationIdHandler : DelegatingHandler
    {
        // todo: make configurable
        private const string CorrelationHeader = "X-Correlation-ID";

        private readonly IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        public CorrelationIdHandler(IHttpContextAccessor httpContextAccessor)
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

            if (context != null && !request.Headers.Contains(CorrelationHeader))
            {
                // Check if current http context contains correlation id. If contains use it, if not - use asp.net trace identifier.
                string correlationId = context.Request.Headers[CorrelationHeader];

                request.Headers.Add(CorrelationHeader, !string.IsNullOrEmpty(correlationId) ? correlationId : context.TraceIdentifier);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
