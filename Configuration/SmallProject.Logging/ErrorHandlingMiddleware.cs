using log4net;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace SmallProject.Logging
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private static readonly ILog log = LogManager.GetLogger(typeof(Log4NetConfiguration));

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            //var message = FormatErrorMessage(ex.Message);

            var result = JsonConvert.SerializeObject(new { error = ex.Message });

            context.Response.ContentType = "application/json; charset=utf-8";
            context.Response.StatusCode = 500;
            context.Response.HttpContext.Features.Get<Microsoft.AspNetCore.Http.Features.IHttpResponseFeature>().ReasonPhrase = JsonConvert.SerializeObject(ex.Message);

            return context.Response.WriteAsync(result);
        }
    }
}
