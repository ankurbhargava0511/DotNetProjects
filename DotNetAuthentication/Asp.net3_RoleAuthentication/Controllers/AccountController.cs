using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Asp.net3_RoleAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpGet("login")]
        public IActionResult Login()
        {
            return SignIn(
            new ClaimsPrincipal(
                new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
                        new Claim("my_role", "admin")
                    }, "cookie",
                    nameType: null,
                    roleType: "my_role"

                    )
                ),
            authenticationScheme: "cookie"
            );
        } 
    }
}
