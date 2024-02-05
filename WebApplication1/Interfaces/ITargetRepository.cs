using Microsoft.EntityFrameworkCore;
using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface ITargetRepository
    {
        public bool CreateTarget(int userId, int statusId, Target target);
        public bool DeleteTarget(Target target);
        public Target GetTarget(int id);
        public Target GetTarget(string name);
        public ICollection<Target> GetTargets();
        Target GetTargetTrimToUpper(TargetDto targetCreate);
        public bool TargetExists(int targetId);
        public bool Save();
        public bool UpdateTarget(int ownerId, int categoryId, Target target);
    }
}
