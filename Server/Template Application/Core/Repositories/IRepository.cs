using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        TEntity Get(int id);

        void Save(TEntity entity);

        void Remove(TEntity entity);
    }
}
