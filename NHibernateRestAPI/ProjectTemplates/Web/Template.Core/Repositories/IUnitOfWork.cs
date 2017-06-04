using System;

namespace Template.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUnitOfWork BeginTransaction();

        void Commit();

        bool IsOpen();
    }
}
