using Core.Models;
using Core.Repositories;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.NHibernate.Repositories
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
