using $ext_projectname$.Core.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.Mappings
{
    public abstract class _EntityMap<TEntity> : ClassMap<TEntity> where TEntity : _Entity
    {
        public _EntityMap()
        {
            Id(x => x.Id);
        }
    }
}
