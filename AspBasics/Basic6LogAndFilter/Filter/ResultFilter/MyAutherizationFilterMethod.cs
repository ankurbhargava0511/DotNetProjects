using Microsoft.AspNetCore.Mvc.Filters;

namespace Basic6LogAndFilter.Filter.ActionFilters
{
    public class MyAutherizationFilterMethod : IAuthorizationFilter
    {
        public MyAutherizationFilterMethod(ILogger<MyResourceFilterMethod> logger)
        {
            Logger = logger;
        }

        public ILogger<MyResourceFilterMethod> Logger { get; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Logger.LogInformation("8 Executed Autherozation Filter. Read Cookie and token here");
        }

        

    }
}
