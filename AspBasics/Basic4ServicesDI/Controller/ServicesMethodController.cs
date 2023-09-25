using Basic4ServicesDI.AllServices;
using Microsoft.AspNetCore.Mvc;

namespace Basic4ServicesDI
{
    public class ServicesMethodController : Controller
    {
        [Route("myServicesMethod")]
        
        public IActionResult getServices([FromServices] IPersons myPersons )
        {
            string ppp = string.Empty;

            foreach(var persosn in myPersons.GetPerson())
            {
                ppp = ppp + persosn.Name;
            }


            return new ContentResult() { Content = $"DI Service at Method level -{ppp}", ContentType = "text/plain" };
        }
    }
}
