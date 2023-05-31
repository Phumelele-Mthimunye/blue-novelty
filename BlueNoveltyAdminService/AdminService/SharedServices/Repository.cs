using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdminService.SharedServices
{
    public class Repository<Entity, IdType> : IRepository<Entity, IdType> where Entity : class, IEntityFrameworkObjectId<IdType>
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public void Add(Entity obj)
        {
            _context.Set<Entity>().Add(obj);
        }

        public void AddRange(IEnumerable<Entity> objects)
        {
            _context.Set<Entity>().AddRange(objects);
        }

        public Entity AddWithReturnEntity(Entity obj)
        {
            return _context.Set<Entity>().Add(obj).Entity;
        }

        public int Count(Expression<Func<Entity, bool>> criteria = null)
        {
            if (criteria == null) criteria = t => true;
            return _context.Set<Entity>().Count(criteria);
        }

        public void Delete(IdType id)
        {
            var existing = _context.Set<Entity>().Find(id);
            _context.Set<Entity>().Remove(existing);
        }

        public IQueryable<Entity> Get(Expression<Func<Entity, bool>> criteria = null)
        {
            return criteria == null ? _context.Set<Entity>().AsQueryable() : _context.Set<Entity>().Where(criteria);
        }

        public IQueryable<Entity> Get(Expression<Func<Entity, bool>> criteria, int limit)
        {
            var results = criteria == null ? _context.Set<Entity>() : _context.Set<Entity>().Where(criteria);
            return results.Take(limit);
        }

        public Entity GetById(IdType id)
        {
            return _context.Set<Entity>().Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Entity obj)
        {
            var entity = GetById(obj.Id);
            if (entity != null)
            {
                _context.Entry(entity).CurrentValues.SetValues(obj);
                Save();
            }
            else
            {
                throw new Exception("Unable to find entity framework object");
            }
        }

        public void UpdateWithTrackedEntity(Entity obj)
        {
            _context.Set<Entity>().Update(obj);
        }
    }
}
