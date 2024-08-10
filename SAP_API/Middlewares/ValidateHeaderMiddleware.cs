using DotnetSdkUtilities.Factory.ResponseFactory;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using SAP_API.Common;
using SAP_API.Configuration;
using System;
using System.Net;

namespace SAP_API.Middlewares
{
    public class ValidateHeaderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IOptionsMonitor<Settings> _setting;
        private readonly ILogger<ValidateHeaderMiddleware> _logger;
        public ValidateHeaderMiddleware(RequestDelegate next, IOptionsMonitor<Settings> setting, ILogger<ValidateHeaderMiddleware> logger)
        {
            _next = next;
            _setting = setting;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var factory = context.RequestServices.GetService<IApiResponseFactory>();

            var request = context.Request;
            if (request.Path.ToString().StartsWith("/swagger/"))
            {
                await _next(context);
                return;
            }
            if (!context.Request.Headers.TryGetValue("API-Key", out var headerValue))
            {

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var message = "Header API-Key is missing.";
                var response = factory?.CreateErrorResponse(ErrorCodes.BadRequestKeyNotFound, message);

                _logger.LogWarning(message);
                await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
                return;
            }
            if (!_setting.CurrentValue.ValidKeys.Contains(headerValue!))
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                var message = "Invalid header key value.";
                var response = factory?.CreateErrorResponse(ErrorCodes.UnauthorizedKeyInvalid, message);

                _logger.LogWarning(message);
                await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
                return;
            }

            await _next(context);
        }
    }
}
