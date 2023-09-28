using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApiRestWithOpenApi.Services
{
    public class Contact
    {
        [Required(ErrorMessage ="Field is required")]
        [Range(1,int.MaxValue)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ContactService : IContactService
    {
        List<Contact> contacts = new List<Contact>();
        public IEnumerable<Contact> GetContacts()
        {
            return contacts;
        }


        public Contact GetContactById(int id)
        {
            var cont = contacts.FirstOrDefault(x => x.Id == id);

            return cont;
        }

        public bool AddContact(Contact value)
        {

            contacts.Add(value);
            return true;
        }


        public bool UpdateContact(int id, Contact value)
        {

            var cont = contacts.FirstOrDefault(x => x.Id == id);

            if (cont == null)
            {
                return false;
            }
            else
            {
                cont.Name = value.Name;
                return true;
            }


        }


        public bool Delete(int id)
        {
            var cont = contacts.FirstOrDefault(x => x.Id == id);

            if (cont == null)
            {
                return false;
            }
            else
            {
                contacts.Remove(cont);
                return true;
            }

        }
    }
}
