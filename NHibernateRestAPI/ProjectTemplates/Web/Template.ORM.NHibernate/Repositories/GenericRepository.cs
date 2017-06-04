using Template.Core.Models;
using Template.Core.Repositories;
using NHibernate;

namespace Template.ORM.NHibernate.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : _Entity
    {
        protected readonly ISession session;

        public GenericRepository(ISession session)
        {
            this.session = session;
        }

        public TEntity Get(int id)
        {
            return session.Load<TEntity>(id);
        }

        public void Remove(TEntity entity)
        {
            session.Delete(entity);
        }

        public void Save(TEntity entity)
        {
            session.SaveOrUpdate(entity);
        }
    }
}
