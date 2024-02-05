using WebApplication1.Data;
using WebApplication1.Dto;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly PostgresContext _context;

        public TaskRepository(PostgresContext context)
        {
            _context = context;
        }

        public bool CreateTask(int userId, int statusId, Models.Task task)
        {
            var taskOwnerEntity = _context.Users.Where(a => a.Id == userId).FirstOrDefault();
            var status = _context.Statuses.Where(a => a.Id == statusId).FirstOrDefault();

            var taskOwner = new User_tasks()
            {
                User = taskOwnerEntity,
                Task = task,
            };

            _context.Add(taskOwner);

            var taskStat = new Status_Tasks()
            {
                Status = status,
                Task = task,
            };

            _context.Add(taskStat);

            _context.Add(task);

            return Save();
        }

        public bool DeletePokemon(Models.Task task)
        {
            _context.Remove(task);
            return Save();
        }

        public Models.Task GetTask(int id)
        {
            return _context.Tasks.Where(p => p.Id == id).FirstOrDefault();
        }

        public Models.Task GetTask(string name)
        {
            return _context.Tasks.Where(p => p.Description == name).FirstOrDefault();
        }

       

        public ICollection<Models.Task> GetTasks()
        {
            return _context.Tasks.OrderBy(p => p.Id).ToList();
        }

        public Models.Task GetTaskTrimToUpper(TaskDto taskCreate)
        {
            return GetTasks().Where(c => c.Description.Trim().ToUpper() == taskCreate.Description.TrimEnd().ToUpper())
                .FirstOrDefault();
        }

        public bool TaskExists(int taskId)
        {
            return _context.Tasks.Any(p => p.Id == taskId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateTask(int ownerId, int categoryId, Models.Task task)
        {
            _context.Update(task);
            return Save();
        }
    }
}
