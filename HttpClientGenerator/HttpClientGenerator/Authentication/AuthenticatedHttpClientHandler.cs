using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClientGenerator.Authentication
{
    class AuthenticatedHttpClientHandler : DelegatingHandler
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Func<IServiceProvider, Task<string>> _getToken;

        public AuthenticatedHttpClientHandler(
            IServiceProvider serviceProvider,
            Func<IServiceProvider, Task<string>> getToken)
        {
            _serviceProvider = serviceProvider;
            _getToken = getToken ?? throw new ArgumentNullException(nameof(getToken));
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
                var token = await _getToken(_serviceProvider).ConfigureAwait(false);

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
