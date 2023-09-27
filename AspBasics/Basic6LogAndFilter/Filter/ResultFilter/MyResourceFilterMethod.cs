using Microsoft.AspNetCore.Mvc.Filters;

namespace Basic6LogAndFilter.Filter.ActionFilters
{
    public class MyResourceFilterMethod : IResourceFilter
    {
        public MyResourceFilterMethod(ILogger<MyResourceFilterMethod> logger)
        {
            Logger = logger;
        }

        public ILogger<MyResourceFilterMethod> Logger { get; }

        

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Logger.LogInformation("7 Executed Result Filter. We can do caching ");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Logger.LogInformation("7 Excuting Result Filter. You can change model binding");
        }

    }
}
