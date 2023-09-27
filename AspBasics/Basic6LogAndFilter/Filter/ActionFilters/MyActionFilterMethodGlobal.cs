using Microsoft.AspNetCore.Mvc.Filters;

namespace Basic6LogAndFilter.Filter.ActionFilters
{
    public class MyActionFilterMethodGlobal : IActionFilter
    {
        public MyActionFilterMethodGlobal(ILogger<MyActionFilterMethodGlobal> logger)
        {
            Logger = logger;
        }

        public ILogger<MyActionFilterMethodGlobal> Logger { get; }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Logger.LogInformation("1 Executed Action Filter Global");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Logger.LogInformation("1 Executing  Action Filter Global");
        }
    }
}
