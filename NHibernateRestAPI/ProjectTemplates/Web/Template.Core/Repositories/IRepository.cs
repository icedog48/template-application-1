using Template.Core.Models;

namespace Template.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : _Entity
    {
        TEntity Get(int id);

        void Save(TEntity entity);

        void Remove(TEntity entity);
    }
}
