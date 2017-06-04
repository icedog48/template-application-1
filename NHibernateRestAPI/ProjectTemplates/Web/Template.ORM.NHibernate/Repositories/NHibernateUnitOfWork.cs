using Template.Core.Repositories;
using NHibernate;
using System;

namespace Template.ORM.NHibernate.Repositories
{
    public class NHibernateUnitOfWork : IUnitOfWork
    {
        private readonly ISession session;

        private ITransaction transaction = null;

        public NHibernateUnitOfWork(ISession session)
        {
            this.session = session;
        }

        public void Commit()
        {
            if (this.transaction == null) new InvalidOperationException();

            this.transaction.Commit();
        }

        public void Dispose()
        {
            if (this.transaction != null)
            {
                this.transaction.Dispose();
            }
        }

        public IUnitOfWork BeginTransaction()
        {
            this.transaction = this.session.BeginTransaction();

            return this;
        }

        public bool IsOpen()
        {
            if (transaction == null) return false;

            return transaction.IsActive;
        }
    }
}
