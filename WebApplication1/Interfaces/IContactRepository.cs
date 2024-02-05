using WebApplication1.Dto;
using WebApplication1.Models;


namespace WebApplication1.Interfaces
{
    public interface IContactRepository
    {
        ICollection<Contact> GetContacts();
        Contact GetContact(int id);
        Contact GetContact(string name);
        Contact GetContactTrimToUpper(ContactDto contactCreate);
       
        bool ContactExists(int id);
        bool CreateContact(int user_id, Contact contact);
        bool UpdateContact(int user_id,Contact contact);
        bool DeleteContact(Contact category);
        bool Save();
    }
}
