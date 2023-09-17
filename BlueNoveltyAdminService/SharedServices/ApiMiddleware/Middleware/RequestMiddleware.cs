using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SharedServices.ApiMiddleware.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SharedServices.ApiMiddleware.Middleware
{
    public class RequestMiddleware<T>
    {
        private readonly RequestDelegate _next;
        private string _headerVariable;
        public RequestMiddleware(RequestDelegate next, string headerVariable)
        {
            _next = next;
            _headerVariable = headerVariable;
        }

        public async Task Invoke(HttpContext context, IRequestContextService<T> requestContextService)
        {
            var headerRequestIdentifier = context.Request.Headers[_headerVariable].FirstOrDefault();
            if (headerRequestIdentifier == null)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new { Title = "Forbidden", Message = $"{_headerVariable} not found", Status = context.Response.StatusCode }, Newtonsoft.Json.Formatting.Indented));
                return;
            }
            T requestIdentifier;
            try
            {
                requestIdentifier = (T)Convert.ChangeType(headerRequestIdentifier, typeof(T));
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new { Title = "Forbidden", Message = $"{_headerVariable} not valid value", Status = context.Response.StatusCode }, Newtonsoft.Json.Formatting.Indented));
                return;
            }

            requestContextService.SetRequestIdentifier(requestIdentifier);
            await _next(context);
        }
    }
}
