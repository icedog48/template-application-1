using $safeprojectname$.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.Repositories
{
    public interface IRepository<TEntity> where TEntity : _Entity
    {
        TEntity Get(int id);

        void Save(TEntity entity);

        void Remove(TEntity entity);
    }
}
