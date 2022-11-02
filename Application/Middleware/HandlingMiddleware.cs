using Microsoft.Extensions.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net;
using System;
using Domain.Interfaces;

namespace Application.Middleware
{
    public class HandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IlogService _log;

        public HandlingMiddleware(RequestDelegate next, IlogService log)
        {
            this.next = next;
            _log = log;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        [ExcludeFromCodeCoverageAttribute]
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            string text = exception?.Message ?? "Erro ErrorHandlingMiddleware";
            JObject jObject = new JObject();
            jObject.Add("msgErro", (JToken)text);
            jObject.Add("log_id", (JToken)Guid.NewGuid().ToString());
            jObject.Add("data", (JToken)DateTime.Now);
            jObject.Add("Exception", exception?.ToString());
            StringValues? stringValues = context?.Request?.Headers["correlation-id"];
            StringValues? stringValues2 = stringValues;
            if (string.IsNullOrEmpty(stringValues2.HasValue ? ((string)stringValues2.GetValueOrDefault()) : null))
            {
                stringValues = context?.Request?.Headers["request_id"];
            }

            stringValues2 = stringValues;
            if (string.IsNullOrEmpty(stringValues2.HasValue ? ((string)stringValues2.GetValueOrDefault()) : null))
            {
                stringValues = context?.Request?.Headers["access_token"];
            }

            StringValues? stringValues3 = context?.Request?.Headers["client_id"];
            HttpRequest httpRequest = context?.Request;
            HttpStatusCode? statuscode = HttpStatusCode.InternalServerError;
            stringValues2 = stringValues3;
            string user = (stringValues2.HasValue ? ((string)stringValues2.GetValueOrDefault()) : null);
            stringValues2 = stringValues;
            JObject resultMsg = new JObject();
            resultMsg.Add("erro", "Erro interno.");

            if (context != null)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;
            }

            return context?.Response.WriteAsync(resultMsg.ToString());
        }
    }
}
