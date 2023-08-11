namespace LearningSomething.Middlewares
{
    public class CustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync(" Custom Middleware ");
            await next(context);
        }
    }
}
