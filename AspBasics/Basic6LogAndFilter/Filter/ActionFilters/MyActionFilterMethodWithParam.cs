using Microsoft.AspNetCore.Mvc.Filters;

namespace Basic6LogAndFilter.Filter.ActionFilters
{
    public class MyActionFilterMethodWithParam : IActionFilter//, IOrderedFilter
    {
        public MyActionFilterMethodWithParam(ILogger<MyActionFilterMethodWithParam> logger, string key, string value)
        {
            Logger = logger;
            Key = key;
            Value = value;
            
        }

        public ILogger<MyActionFilterMethodWithParam> Logger { get; }
        public string Key { get; }
        public string Value { get; }
        public string Param { get; }

        public int Order => 2;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Logger.LogInformation("2 Executed MyActionFilterMethod with Param" + Key + Value);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Logger.LogInformation("2 Executing MyActionFilterMethod with Param" + Key + Value);
        }
    }
}
