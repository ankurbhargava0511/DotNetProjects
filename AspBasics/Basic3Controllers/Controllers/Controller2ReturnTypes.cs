using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace Basic3Controllers.Controllers
{
    public class ReturnType:Controller
    {

        [Route("ContentResultType")]

        public ContentResult RetType1()
        {
            return new ContentResult() { Content = "Content Result of type text/plain", ContentType = "text/plain" };
        }



        [Route("ContentType")]

        public ContentResult RetType2()
        {
            return Content( "<h1>Welcome</h1> <p>Content result with text/html</p>", "text/html" );
        }

        [Route("JsonType")]
        public JsonResult RetType3()
        {
            Person p = new Person() { name = "test" };
            return new JsonResult(p);
        }


        [Route("iactionResultTypeforJson")]
        public IActionResult RetType4()
        {
            Person p = new Person() { name = "test" };
            return new JsonResult(p);
        }

        [Route("iactionResultTypefortext")]
        public IActionResult RetType5()
        {
            return new ContentResult() { Content = "Content Result of type text/plain. You can also return filetypr ", ContentType = "text/plain" };
        }

        [Route("statuscode")]
        public IActionResult RetType6()
        {
            Response.StatusCode = 200;
            return new ContentResult() { Content = "Content Result of type text/plain. You can also return filetypr ", ContentType = "text/plain" };
        }

        [Route("badRequestTest")]
        public IActionResult RetType7()
        {
            
            return BadRequest("This is bad Request response. ");
        }



        [Route("NonFoundTest")]
        public IActionResult RetType8()
        {

            return NotFound("This is from NotFound.  ");
        }


        [Route("oldUrl")]
        public IActionResult RetType9()
        {

            
            return new RedirectToActionResult("Method1", "Redirected", new { });
        }

    }

    internal class Person
    {
        public string name { get; set; }
    }

    //public class StoreController : Controller
    //{
    //    [Route("store/books")]
    //    public IActionResult Books
    //}
}
