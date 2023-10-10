using Asp.net2_cookieAuthentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.Arm;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Asp.net2cookieAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class HomeController : ControllerBase
    {
        

        [HttpGet("login")]
        public async Task<IActionResult> login()
        {

            var claims = new List<Claim>();
            claims.Add(new Claim("usr", "testuser"));
            claims.Add(new Claim("user-type", "app-user"));

            var identity = new ClaimsIdentity(claims, AuthSchemes.AuthScheme0);

            await HttpContext.SignInAsync(AuthSchemes.AuthScheme0, new ClaimsPrincipal(identity));
            return Ok();

        }

        [HttpGet("emplogin")]
        public async Task<IActionResult> emplogin()
        {

            var claims = new List<Claim>();
            claims.Add(new Claim("usr", "testuser"));
            claims.Add(new Claim("user-type", "emp-user"));

            var identity = new ClaimsIdentity(claims, AuthSchemes.AuthScheme1);

            await HttpContext.SignInAsync(AuthSchemes.AuthScheme0, new ClaimsPrincipal(identity));
            return Ok();

        }

        [HttpGet("adminlogin")]
        public async Task<IActionResult> adminlogin()
        {

            var claims = new List<Claim>();
            claims.Add(new Claim("usr", "testuser"));
            claims.Add(new Claim("user-type", "admin-user"));

            var identity = new ClaimsIdentity(claims, AuthSchemes.AuthScheme1);

            await HttpContext.SignInAsync(AuthSchemes.AuthScheme0, new ClaimsPrincipal(identity));
            return Ok();

        }


        [HttpGet("app-user")]
        public string normaluser()
        {
            if(!HttpContext.User.Identities.Any(x=>x.AuthenticationType== AuthSchemes.AuthScheme0))
            {
                HttpContext.Response.StatusCode = 401;
                return "Not";
            }
            if (!HttpContext.User.HasClaim("user-type", "app-user"))
            {
                HttpContext.Response.StatusCode = 403;
                return "Not";
            }
            return "Allowed";
        }


        [HttpGet("emp-user")]
        public string empuser()
        {
            if (!HttpContext.User.Identities.Any(x => x.AuthenticationType == AuthSchemes.AuthScheme1))
            {
                HttpContext.Response.StatusCode = 401;
                return "Not";
            }
            if (!HttpContext.User.HasClaim("user-type", "emp-user"))
            {
                HttpContext.Response.StatusCode = 403;
                return "Not";
            }
            return "Allowed";
        }


        [HttpGet("admin-user")]
        public string adminuser()
        {
            if (!HttpContext.User.Identities.Any(x => x.AuthenticationType == AuthSchemes.AuthScheme1))
            {
                HttpContext.Response.StatusCode = 401;
                return "Not";
            }
            if (!HttpContext.User.HasClaim("user-type", "admin-user"))
            {
                HttpContext.Response.StatusCode = 403;
                return "Not";
            }
            return "Allowed";
        }
    }
}
