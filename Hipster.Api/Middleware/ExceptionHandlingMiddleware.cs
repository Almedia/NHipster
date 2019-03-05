using System;
using System.Net;
using System.Threading.Tasks;
using Hipster.ApplicationService.Dto.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Hipster.Api.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
		private readonly ILogger _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next,ILoggerFactory loggerFactory){
            _next=next;
			 _logger = loggerFactory
                  .CreateLogger<ExceptionHandlingMiddleware>();
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
			{
				await _next(httpContext);
			}
			catch (Exception ex)
			{
					_logger.LogError(ex,"system exception");
				await HandleExceptionAsync(httpContext, ex);
			}
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
			var code = HttpStatusCode.InternalServerError; // 500 if unexpected
			var response = new ResponseBase()
			{
				UserMessage="işlem basarısız",
				Code=0001,
				Message=exception.Message
			};

		
			var result = JsonConvert.SerializeObject(response);
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)code;
			return context.Response.WriteAsync(result);
		}
    }
}