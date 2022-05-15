﻿using Restaurant.Web.Models.Response;
using System.Text.Json;

namespace Restaurant.Web.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;

                response.ContentType = "application/json";

                var result = JsonSerializer.Serialize(new Response<string>(true,error.Message,""));

                await response.WriteAsync(result);
            }
        }
    }
}
