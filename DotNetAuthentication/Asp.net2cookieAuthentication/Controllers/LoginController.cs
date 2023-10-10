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
    
    public class LoginController : ControllerBase
    {
        

        [HttpGet("login")]
        [AllowAnonymous]
        public async Task<IActionResult> login()
        {

            var claims = new List<Claim>();
            claims.Add(new Claim("usr", "testuser"));
            claims.Add(new Claim("app-type", "app-user"));

            var identity = new ClaimsIdentity(claims, AuthSchemes.AuthScheme0);

            await HttpContext.SignInAsync(AuthSchemes.AuthScheme0, new ClaimsPrincipal(identity));
            return Ok();

        }

        [HttpGet("emplogin")]
        [AllowAnonymous]
        public async Task<IActionResult> emplogin()
        {

            var claims = new List<Claim>();
            claims.Add(new Claim("usr", "testuser"));
            claims.Add(new Claim("emp-type", "emp-user"));

            var identity = new ClaimsIdentity(claims, AuthSchemes.AuthScheme1);

            await HttpContext.SignInAsync(AuthSchemes.AuthScheme1, new ClaimsPrincipal(identity));
            return Ok();

        }

        [HttpGet("adminlogin")]
        [AllowAnonymous]
        public async Task<IActionResult> adminlogin()
        {

            var claims = new List<Claim>();
            claims.Add(new Claim("usr", "testuser"));
            claims.Add(new Claim("admin-type", "admin-user"));

            var identity = new ClaimsIdentity(claims, AuthSchemes.AuthScheme1);

            await HttpContext.SignInAsync(AuthSchemes.AuthScheme1, new ClaimsPrincipal(identity));
            return Ok();

        }


        [HttpGet("app-user")]
        [Authorize(Policy = "app")]
        public string normaluser()
        {
 
            return "Allowed from app";
        }


        [HttpGet("emp-user")]
        [Authorize(Policy = "emp")]
        public string empuser()
        {
            
            return "Allowed from emp";
        }


        [HttpGet("admin-user")]
        [Authorize(Policy = "admin")]
        public string adminuser()
        {
            
            return "Allowed from admin";
        }
    }
}
