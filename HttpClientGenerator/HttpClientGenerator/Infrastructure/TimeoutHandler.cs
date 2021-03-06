﻿using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClientGenerator.Infrastructure
{
    /// <summary>
    /// Adds timeout to the request
    /// </summary>
    public class TimeoutHandler : DelegatingHandler
    {
        private TimeSpan _timeout;

        /// <inheritdoc />
        public TimeoutHandler(TimeSpan timeout)
        {
            _timeout = timeout;
        }

        /// <inheritdoc />
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            using (var cts = new CancellationTokenSource(_timeout))
            {
                try
                {
                    var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cts.Token, cancellationToken);

                    return await base.SendAsync(
                        request,
                        linkedCts.Token);
                }
                catch (OperationCanceledException exception)
                {
                    throw new TimeoutException("Operation timed out", exception);
                }
            }
        }
    }
}
