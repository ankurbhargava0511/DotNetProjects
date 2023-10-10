using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Asp.net3_RoleAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Index()
        { return "Index Route";  }

        
        [HttpGet("secret")]
        [Authorize(Roles ="admin")]
        public string Secret() => "Secret Route";
        

    }
}
