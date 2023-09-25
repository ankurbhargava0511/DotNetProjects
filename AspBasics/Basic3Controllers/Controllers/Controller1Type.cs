using Microsoft.AspNetCore.Mvc;

namespace Basic3Controllers.Controllers
{
    
    public class Home : Controller
    {
        [Route("Home")]
        [Route("/")]
        public string method1()
        {
            return "Hello from Home inherected from Controller. It has 2 route / and /Home";
        }

        [Route("ContentResult")]
        
        public ContentResult method2()
        {
            return new ContentResult() { Content = "Content Result of type text/plain", ContentType = "text/plain" };
        }


    }


    public class SecondController
    {
        [Route("Second")]
        public string method1()
        {
            return "Hello from Second not inherected from Controller , but name has controller";
        }
    }


    [Controller]
    public class WithAttributes 
    {
        [Route("Att")]
        public string method1()
        {
            return "Has controller attributes";
        }
    }

}
