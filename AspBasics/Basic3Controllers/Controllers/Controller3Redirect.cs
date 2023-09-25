using Microsoft.AspNetCore.Mvc;

namespace Basic3Controllers.Controllers
{
    
    public class RedirectedController
    {
        [Route("NewUrl")]
        public IActionResult Method1()
        {
            return new ContentResult() {Content= "Redirect from OldUrl to new Url",ContentType= "text/plain" };
        }

        [Route("v1/NewUrl")]
        public IActionResult Method2()
        {
            return new RedirectToActionResult("Method3", "Redirected", new { });
        }

        [Route("v2/NewUrl")]
        public IActionResult Method3()
        {
            return new ContentResult() { Content = "Version from v1 to v2 - 302", ContentType = "text/plain" };
        }

        [Route("v2/PMode")]
        public IActionResult Method4()
        {
            return new RedirectToActionResult("Method3", "Redirected", new { }, true);
        }


        [Route("localredirect")]
        public IActionResult Method5()
        {
            return new LocalRedirectResult("/NewUrl");
        }

        [Route("resultredirect")]
        public IActionResult Method6()
        {
            return new RedirectResult("google.co.in");
        }


    }
}
