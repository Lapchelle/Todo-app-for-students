using WebApplication1.Data;
using WebApplication1.Dto;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class TargetRepository : ITargetRepository
    {
        private readonly PostgresContext _context;

        public TargetRepository(PostgresContext context)
        {
            _context = context;
        }

        public bool CreateTarget(int userId, int statusId, Target target)
        {
            var targetOwnerEntity = _context.Users.Where(a => a.Id == userId).FirstOrDefault();
            var status = _context.Statuses.Where(a => a.Id == statusId).FirstOrDefault();

            var targetOwner = new User_targets()
            {
                User = targetOwnerEntity,
                Target = target,
            };

            _context.Add(targetOwner);

            var taskStat = new Status_targets()
            {
                Status = status,
                Target = target,
            };

            _context.Add(taskStat);

            _context.Add(target);

            return Save();
        }

        public bool DeleteTarget(Target target)
        {
            _context.Remove(target);
            return Save();
        }

        public Target GetTarget(int id)
        {
            return _context.Targets.Where(p => p.Id == id).FirstOrDefault();
        }

        public Target GetTarget(string name)
        {
            return _context.Targets.Where(p => p.Description == name).FirstOrDefault();
        }



        public ICollection<Target> GetTargets()
        {
            return _context.Targets.OrderBy(p => p.Id).ToList();
        }

        public Target GetTargetTrimToUpper(TargetDto targetCreate)
        {
            return GetTargets().Where(c => c.Description.Trim().ToUpper() == targetCreate.Description.TrimEnd().ToUpper())
                .FirstOrDefault();
        }

        public bool TargetExists(int targetId)
        {
            return _context.Targets.Any(p => p.Id == targetId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateTarget(int ownerId, int categoryId, Target target)
        {
            _context.Update(target);
            return Save();
        }
    }
}
