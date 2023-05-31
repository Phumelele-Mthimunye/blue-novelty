using System.Linq.Expressions;

namespace AdminService.SharedServices
{
    public interface IRepository<Entity, IdType>
    {
        IQueryable<Entity> Get(Expression<Func<Entity, bool>> criteria = null);

        IQueryable<Entity> Get(Expression<Func<Entity, bool>> criteria, int limit);

        Entity GetById(IdType id);

        void Add(Entity obj);

        Entity AddWithReturnEntity(Entity obj);

        void AddRange(IEnumerable<Entity> objects);

        void Update(Entity obj);

        void Delete(IdType id);

        int Count(Expression<Func<Entity, bool>> criteria = null);

        void Save();

        void UpdateWithTrackedEntity(Entity obj);
    }
}
