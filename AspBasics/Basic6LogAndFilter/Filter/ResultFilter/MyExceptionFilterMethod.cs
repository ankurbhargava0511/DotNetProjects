using Microsoft.AspNetCore.Mvc.Filters;

namespace Basic6LogAndFilter.Filter.ActionFilters
{
    public class MyExceptionFilterMethod : IExceptionFilter
    {
        public MyExceptionFilterMethod(ILogger<MyExceptionFilterMethod> logger)
        {
            Logger = logger;
        }

        public ILogger<MyExceptionFilterMethod> Logger { get; }

        

        public void OnException(ExceptionContext context)
        {
            Logger.LogInformation("9 Exceute exception filter. execute when action generate exception. for other use exception middleware");
            context.HttpContext.Response.WriteAsync("In Exceptionfilter");
        }
    }
}
