using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IUserRepository
    {
        public bool CreateUser(User user);
        public bool DeleteUser(User user);
        public User GetUser(int userId);
        public ICollection<User> GetUserOfAContact(int contId);
        public ICollection<User> GetUserOfATask(int taskId);
        public ICollection<User> GetUserOfATarget(int targId);
        public ICollection<User> GetUsers();


        public ICollection<Contact> GetContactOfAUser(int userId);

        public ICollection<Target> GetTargetOfAUser(int userId);

        ICollection<Models.Task> GetTaskOfAUser(int userId);
        public bool UserExists(int userId);
        public bool Save();
        public bool UpdateUser(User user);
    }
}
