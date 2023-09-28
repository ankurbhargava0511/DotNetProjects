using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using WebApiRestWithOpenApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiRestWithOpenApi.Controllers.v2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class ContactsController : ControllerBase
    {
        public IContactService Contacts { get; }

        public ContactsController(IContactService contacts)
        {
            Contacts = contacts;
        }

        // GET: api/<ValuesController>
        /// <summary>
        /// Insert using Snipped for Getall
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return Contacts.GetContacts();
        }

        // GET api/<ValuesController>/5
        /// <summary>
        ///   Insert using Snipped for Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Contact> Get(int id)
        {


            var cont = Contacts.GetContactById(id);

            if (cont == null)
            {
                return Problem("Invalid Id", statusCode: 404);
            }
            return cont;
        }

        // POST api/<ValuesController>
        /// <summary>
        /// Insert using Snipped for Add new contact
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post([FromBody] Contact value)
        {
            if (!ModelState.IsValid)
            {

            }
            if (!Contacts.AddContact(value))
            {
                BadRequest();
            }
            return CreatedAtAction(nameof(Post), value);
        }

        // PUT api/<ValuesController>/5
        /// <summary>
        /// Insert using Snipped for to update 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Contact value)
        {

            var cont = Contacts.UpdateContact(id, value);

            if (!cont)
            {
                return NotFound();
            }
            else
            {
                return Content("Object Updated");
            }


        }

        // DELETE api/<ValuesController>/5
        /// <summary>
        /// Insert using Snipped for delete record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var cont = Contacts.Delete(id);

            if (!cont)
            {
                return NotFound();
            }
            else
            {
                return Content("Object removed");
            }

        }
    }



}
