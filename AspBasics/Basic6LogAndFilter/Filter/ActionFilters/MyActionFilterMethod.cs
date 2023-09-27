using Microsoft.AspNetCore.Mvc.Filters;

namespace Basic6LogAndFilter.Filter.ActionFilters
{
    public class MyActionFilterMethod : IActionFilter//, IOrderedFilter
    {
        public MyActionFilterMethod(ILogger<MyActionFilterMethod> logger)
        {
            Logger = logger;
        }

        public ILogger<MyActionFilterMethod> Logger { get; }

        public int Order => 3;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Logger.LogInformation("1 Executed MyActionFilterMethod");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Logger.LogInformation("1 Executing MyActionFilterMethod");
        }
    }
}
