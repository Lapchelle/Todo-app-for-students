using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class StatusRepository : IStatusRepository
    {
        private PostgresContext _context;
        public StatusRepository(PostgresContext context)
        {
            _context = context;
        }
        public bool StatusExists(int id)
        {
            return _context.Statuses.Any(c => c.Id == id);
        }

        public bool CreateStatus(Status status)
        {
            _context.Add(status);
            return Save();
        }

        public bool DeleteStatus(Status status)
        {
            _context.Remove(status);
            return Save();
        }

        public ICollection<Status> GetStatuses()
        {
            return _context.Statuses.ToList();
        }

        public Status GetStatus(int id)
        {
            return _context.Statuses.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<Models.Task> GetTaskByStatus(int statusId)
        {
            return _context.StatusTasks.Where(e => e.StatusId == statusId).Select(c => c.Task).ToList();
        }

        public ICollection<Target> GetTargetByStatus(int statusId)
        {
            return _context.StatusTargets.Where(e => e.StatusId == statusId).Select(c => c.Target).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateStatus(Status status)
        {
            _context.Update(status);
            return Save();
        }

       
    }
}
