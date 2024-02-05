using Microsoft.EntityFrameworkCore;
using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface ITaskRepository
    {
        public bool CreateTask(int userId, int statusId, Models.Task task);

        public bool DeletePokemon(Models.Task task);

        public Models.Task GetTask(int id);

        public Models.Task GetTask(string name);
        public ICollection<Models.Task> GetTasks();

        public Models.Task GetTaskTrimToUpper(TaskDto taskCreate);
        public bool TaskExists(int taskId);
        public bool Save();
        public bool UpdateTask(int ownerId, int categoryId, Models.Task task);
    }
}
