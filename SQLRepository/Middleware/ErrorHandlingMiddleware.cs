using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLog;
using SQLRepository.Exceptions;
using SQLRepository.Models;
using ILogger = Microsoft.Extensions.Logging.ILogger;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;


namespace SQLRepository.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly ILogger _log;
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _log = loggerFactory.CreateLogger<ErrorHandlingMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _log.Log(LogLevel.Error, "An error ocurred during request handling.", null, ex);

                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            if (ex is NotFoundException) code = HttpStatusCode.NotFound;
            else if (ex is UnauthorizedException) code = HttpStatusCode.Unauthorized;
            else if (ex is BadRequestException) code = HttpStatusCode.BadRequest;
            else if (ex is ConflictException) code = HttpStatusCode.Conflict;

            var response = new ErrorResponse
            {
                ErrorCode = (int)code,
                ErrorMessage = ex.Message,
                RequestId = context.TraceIdentifier
            };

            var body = JsonConvert.SerializeObject(response);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(body);
        }
    }
}
