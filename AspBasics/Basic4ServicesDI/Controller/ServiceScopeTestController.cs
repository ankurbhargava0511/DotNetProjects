using Basic4ServicesDI.AllServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Basic4ServicesDI
{
    public class ServiceScopeTestController : Controller
    {
        public ServiceScopeTestController(ITrans trans, IScoped scoped, ISingle single)
        {
            Trans = trans;
            Scoped = scoped;
            Single = single;
        }

       
        public ITrans Trans { get; }
        public IScoped Scoped { get; }
        public ISingle Single { get; }

        [Route("myCounter")]
        
        public IActionResult Add()
        {
            
            return new ContentResult() { Content = $"DI Service at Scopred level  Trans-{Trans.Add()} , Scoped-{Scoped.Add()} , Single={Single.Add()}", ContentType = "text/plain" };
        }
    }
}
