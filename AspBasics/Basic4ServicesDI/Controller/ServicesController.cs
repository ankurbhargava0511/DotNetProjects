using Basic4ServicesDI.AllServices;
using Microsoft.AspNetCore.Mvc;

namespace Basic4ServicesDI
{
    public class ServicesController : Controller
    {
        public ServicesController(IPersons persons)
        {
            Persons = persons;
        }

        public IPersons Persons { get; }

        [Route("myServices")]
        [Route("/")]
        public IActionResult getServices()
        {
            string ppp = string.Empty;

            foreach(var persosn in Persons.GetPerson())
            {
                ppp = ppp + persosn.Name;
            }


            return new ContentResult() { Content = $"DI Service at contructor level -{ppp}", ContentType = "text/plain" };
        }
    }
}
