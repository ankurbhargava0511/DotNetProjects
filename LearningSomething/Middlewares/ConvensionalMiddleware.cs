using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace LearningSomething.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ConvensionalMiddleware
    {
        private readonly RequestDelegate _next;

        public ConvensionalMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync(" Convensional Middleware ");
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ConvensionalMiddlewareExtensions
    {
        public static IApplicationBuilder UseConvensionalMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ConvensionalMiddleware>();
        }
    }
}
