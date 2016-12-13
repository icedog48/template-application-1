using $ext_projectname$.Core.Models;
using $ext_projectname$.Core.Repositories;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.Repositories
{
    public class NhibernateRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly ISession session;

        public NhibernateRepository(ISession session)
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
