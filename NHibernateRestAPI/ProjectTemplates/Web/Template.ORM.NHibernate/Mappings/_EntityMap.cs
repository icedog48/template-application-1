using Template.Core.Models;
using FluentNHibernate.Mapping;

namespace Template.ORM.NHibernate.Mappings
{
    public abstract class _EntityMap<TEntity> : ClassMap<TEntity> where TEntity : _Entity
    {
        public _EntityMap()
        {
            Id(x => x.Id);
        }
    }
}
