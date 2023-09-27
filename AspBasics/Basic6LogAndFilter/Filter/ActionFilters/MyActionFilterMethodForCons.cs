using Microsoft.AspNetCore.Mvc.Filters;

namespace Basic6LogAndFilter.Filter.ActionFilters
{
    public class MyActionFilterMethodForCons : IActionFilter
    {
        public MyActionFilterMethodForCons(ILogger<MyActionFilterMethodForCons> logger)
        {
            Logger = logger;
        }

        public ILogger<MyActionFilterMethodForCons> Logger { get; }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Logger.LogInformation("3 Executed MyActionFilterMethodForCons");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Logger.LogInformation("3 Executing MyActionFilterMethodForCons");
        }
    }
}
