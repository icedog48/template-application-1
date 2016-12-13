using $safeprojectname$.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.Services
{
    public interface IService<TEntity> where TEntity : Entity
    {
        void Save(TEntity entity);

        void Remove(TEntity entity);
    }
}
