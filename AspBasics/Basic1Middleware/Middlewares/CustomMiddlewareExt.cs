namespace LearningSomething.Middlewares
{
    public class CustomMiddlewareExt:IMiddleware
    {
       

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync(" Custom Middleware Ext");
            await next(context);
        }
    }


    public static class ClassCustomMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomMiddlewareExt(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomMiddlewareExt>();
        }
    }
}
