using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IStatusRepository
    {
        ICollection<Status> GetStatuses();
        Status GetStatus(int id);
        ICollection<Models.Task> GetTaskByStatus(int statusId);

        ICollection<Target> GetTargetByStatus(int statusId);
        bool StatusExists(int id);
        bool CreateStatus(Status status);
        bool UpdateStatus(Status status);
        bool DeleteStatus(Status status);
        bool Save();
    }
}
