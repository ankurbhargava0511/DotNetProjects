using WebApiRestWithOpenApi.Controllers;

namespace WebApiRestWithOpenApi.Services
{
    public interface IContactService
    {
        bool AddContact(Contact value);
        bool Delete(int id);
        Contact GetContactById(int id);
        IEnumerable<Contact> GetContacts();
        bool UpdateContact(int id, Contact value);
    }
}