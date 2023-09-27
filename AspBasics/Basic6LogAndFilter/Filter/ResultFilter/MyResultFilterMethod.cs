using Microsoft.AspNetCore.Mvc.Filters;

namespace Basic6LogAndFilter.Filter.ActionFilters
{
    public class MyResultFilterMethod : IResultFilter
    {
        public MyResultFilterMethod(ILogger<MyResultFilterMethod> logger)
        {
            Logger = logger;
        }

        public ILogger<MyResultFilterMethod> Logger { get; }

        

        public void OnResultExecuted(ResultExecutedContext context)
        {
            Logger.LogInformation("6 Executed Result Filter. . Now we can change the response. Include Header and change in body");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            Logger.LogInformation("6 Excuting Result Filter.");
        }
    }
}
