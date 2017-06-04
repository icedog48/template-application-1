using Template.Core.Models;

namespace Template.Core.Services
{
    public interface IService<TEntity> where TEntity : _Entity
    {
        void Save(TEntity entity);

        void Remove(TEntity entity);

        TEntity Get(int id);
    }
}
