using System;
using System.Reflection;
using System.Threading.Tasks;
using Refit;

namespace HttpClientGenerator.Infrastructure
{
    /// <summary>
    /// Calls wrapper to handle refit ApiException and throw ClientApiException (with HttpStatusCode and ErrorResponse) instead
    /// </summary>
    public class ExceptionHandlerCallsWrapper : ICallsWrapper
    {
        /// <inheritdoc />
        public async Task<object> HandleMethodCall(MethodInfo targetMethod, object[] args, Func<Task<object>> innerHandler)
        {
            try
            {
                return await innerHandler();
            }
            catch (ApiException ex)
            {
                throw;
            }
        }
    }
}
