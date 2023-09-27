using Microsoft.AspNetCore.Mvc.Filters;

namespace Basic6LogAndFilter.Filter.ActionFilters
{
    public class MyActionFilterMethodAsync : IAsyncActionFilter//, IOrderedFilter
    {
        public MyActionFilterMethodAsync(ILogger<MyActionFilterMethod> logger)
        {
            Logger = logger;
        }

        public ILogger<MyActionFilterMethod> Logger { get; }

        public int Order => 3;

        

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Logger.LogInformation("4 Executing Async MyActionFilterMethod");
            await next();
            Logger.LogInformation("4 Executed Async MyActionFilterMethod");
        }
    }
}
