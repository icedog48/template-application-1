using Core.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhibernateRepositories.Mappings
{
    public abstract class EntityMap<TEntity> : ClassMap<TEntity> where TEntity : Entity
    {
        public EntityMap()
        {
            Id(x => x.Id);
        }
    }
}
