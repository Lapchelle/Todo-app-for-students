using WebApplication1.Data;
using WebApplication1.Dto;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class ContactRepository: IContactRepository
    {
        private PostgresContext _context;
        public ContactRepository(PostgresContext context)
        {
            _context = context;
        }
        public bool ContactExists(int id)
        {
            return _context.Contacts.Any(c => c.Id == id);
        }

        public bool CreateContact(int userId, Contact contact)
        {
            var contactOwnerEntity = _context.Users.Where(a => a.Id == userId).FirstOrDefault();
            
            var contactOwner = new User_contacts()
            {
                User = contactOwnerEntity,
                Contact = contact,
            };

            _context.Add(contactOwner);

            

           

            _context.Add(contact);

            return Save();
        }


        public bool DeleteContact(Contact category)
        {
            _context.Remove(category);
            return Save();
        }
        public Contact GetContact(int id)
        {
            return _context.Contacts.Where(e => e.Id == id).FirstOrDefault();
        }

        public Contact GetContact(string name)
        {
            return _context.Contacts.Where(e => e.Description == name).FirstOrDefault();
        }


        public Contact GetContactTrimToUpper(ContactDto contactCreate)
        {
            return GetContacts().Where(c => c.Description.Trim().ToUpper() == contactCreate.Description.TrimEnd().ToUpper())
            .FirstOrDefault();
        }

        public ICollection<Contact> GetContacts()
        {
            return _context.Contacts.OrderBy(p => p.Id).ToList();
        }


        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateContact(int user_id,Contact contact)
        {
            _context.Update(contact);
            return Save();
        }

       
    }
}
