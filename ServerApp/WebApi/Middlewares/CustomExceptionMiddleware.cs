using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApi.Services;

namespace WebApi.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _loggerService;

        public CustomExceptionMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }

        public async Task Invoke(HttpContext context)
        {
            Stopwatch watch = new();

            try
            {
                watch.Start();
                string message = $"[Request] {context.Request.Method} to {context.Request.Path}";
                _loggerService.Write(message);

                await _next(context);
                
                watch.Stop();
                message = $"[Respone] {context.Request.Method} to {context.Request.Path} responded with {context.Response.StatusCode} in {watch.ElapsedMilliseconds}ms";
                _loggerService.Write(message);
            }
            catch (Exception e)
            {
                watch.Stop();

                await HandleException(e, context, watch);
            }
        }

        private Task HandleException(Exception e, HttpContext context, Stopwatch watch)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = $"[Error] {context.Request.Method} to {context.Request.Path} responded with {context.Response.StatusCode} in {watch.ElapsedMilliseconds}ms. Error: {e.Message}";
            _loggerService.Write(message);

            var result = JsonConvert.SerializeObject(new { error = e.Message }, Formatting.None);

            return context.Response.WriteAsync(result);
        }
    }

    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomException(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
