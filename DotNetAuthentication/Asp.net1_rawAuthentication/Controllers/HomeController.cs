using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Asp.net1_rawAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public HomeController(IDataProtectionProvider idp, AuthService auth)
        {
            Idp = idp;
            Auth = auth;
        }

        public IDataProtectionProvider Idp { get; }
        public AuthService Auth { get; }

        #region cookies
        [HttpGet("loginwithcookie")]
        public IActionResult login()
        {
            HttpContext.Response.Headers["set-cookie"] = "auth=usr:username";
            return Ok();

        }
        [HttpGet("getusernamewithcookie")]
        public string Get()
        {
            
            var mycookie=HttpContext.Request.Headers.Cookie.FirstOrDefault(x => x.StartsWith("auth="));
            var payload= mycookie.Split("=").Last();
            return payload.Split(":").Last();
            
        }
        #endregion

        [HttpGet("loginwithProtectedcookie")]
        public IActionResult loginP()
        {
            var protector = Idp.CreateProtector("auth-cookie");
            HttpContext.Response.Headers["set-cookie"] = $"auth={protector.Protect("usr:usernameprotected")}";
            return Ok();

        }
        [HttpGet("getusernamewithprotectedcookie")]
        public string Getprotected()
        {
            var protector = Idp.CreateProtector("auth-cookie");
            var mycookie = HttpContext.Request.Headers.Cookie.FirstOrDefault(x => x.StartsWith("auth="));
            var payloadp = mycookie.Split("=").Last();
            var payload= protector.Unprotect(payloadp);

            return payload.Split(":").Last();

        }


        [HttpGet("signin")]
        public IActionResult signin()
        {
            Auth.SignIn();
            return Ok();

        }
        [HttpGet("getsigninUser")]
        public string getSigninUser()
        {
            return HttpContext.User.FindFirst("usr").Value;

        }


    }


    public class AuthService
    {
        public AuthService(IDataProtectionProvider idp, IHttpContextAccessor accessor)
        {
            Idp = idp;
            Accessor = accessor;
        }

        public IDataProtectionProvider Idp { get; }
        public IHttpContextAccessor Accessor { get; }

        public void SignIn()
        {
            var protector = Idp.CreateProtector("auth-cookie");
            Accessor.HttpContext.Response.Headers["set-cookie"] = $"auth={protector.Protect("usr:signin")}";
            

        }
    }
}
