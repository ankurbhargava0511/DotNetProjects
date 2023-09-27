using Basic6LogAndFilter.Filter.ActionFilters;
using Microsoft.AspNetCore.Mvc;

namespace Basic6LogAndFilter.Controllers
{
    [Route("/")]
    [TypeFilter(typeof(MyActionFilterMethodForCons))]
    public class HomeController : Controller
    {

        public HomeController(ILogger<HomeController> _logger)
        {
            Logger = _logger;
        }

        public ILogger<HomeController> Logger { get; }

        public IActionResult Index()
        {
            Logger.LogInformation("Logging from Home controller using Ilooger");
            return Content(content: "Hello");
        }

        [Route("/ActionFilter")]
        [TypeFilter(typeof(MyActionFilterMethod))]
        [TypeFilter(typeof(MyActionFilterMethodWithParam),Arguments = new object[] {"TestKey", "TestValue"})]
        [TypeFilter(typeof(MyActionFilterMethodAsync))]
        [TypeFilter(typeof(MyResultFilterMethod))]
        [TypeFilter(typeof(MyResourceFilterMethod))]
        [TypeFilter(typeof(MyAutherizationFilterMethod))]
        
        public IActionResult ActionFilter()
        {
            
            return Content(content: "Hello Action");
        }

        [Route("/exceptionFilter")]
        [TypeFilter(typeof(MyExceptionFilterMethod))]
        public IActionResult ExceptionFilter()
        {
            throw new Exception();
            return Content(content: "Hello Action");
        }

    }
}
