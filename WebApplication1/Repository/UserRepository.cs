using WebApplication1.Data;
using WebApplication1.Dto;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly PostgresContext _context;

        public UserRepository(PostgresContext context)
        {
            _context = context;
        }

        public bool CreateUser(User user)
        {
            _context.Add(user);
            return Save();
        }

        public bool DeleteUser(User user)
        {
            _context.Remove(user);
            return Save();
        }

        public User GetUser(int userId)
        {
            return _context.Users.Where(o => o.Id == userId).FirstOrDefault();
        }

        public ICollection<User> GetUserOfAContact(int contId)
        {
            return _context.UserContacts.Where(p => p.Contact.Id == contId).Select(o => o.User).ToList();
        }


        public ICollection<User> GetUserOfATask(int taskId)
        {
            return _context.User_Tasks.Where(p => p.Task.Id == taskId).Select(o => o.User).ToList();
        }

        public ICollection<User> GetUserOfATarget(int targId)
        {
            return _context.User_Targets.Where(p => p.Target.Id == targId).Select(o => o.User).ToList();
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public ICollection<Contact> GetContactOfAUser(int userId)
        {
            return _context.UserContacts.Where(p => p.User.Id == userId).Select(p => p.Contact).ToList();
        }

        public ICollection<Target> GetTargetOfAUser(int userId)
        {
            return _context.User_Targets.Where(p => p.User.Id == userId).Select(p => p.Target).ToList();
        }

        public ICollection<Models.Task> GetTaskOfAUser(int userId)
        {
            return _context.User_Tasks.Where(p => p.User.Id == userId).Select(p => p.Task).ToList();
        }

        public bool UserExists(int userId)
        {
            return _context.Users.Any(o => o.Id == userId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateUser(User user)
        {
            _context.Update(user);
            return Save();
        }
    }
}
