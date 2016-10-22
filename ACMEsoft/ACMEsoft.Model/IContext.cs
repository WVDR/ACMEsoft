using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMEsoft.Model
{
    public interface IContext
    {
        IDbSet<Person> Persons { get; set; }
        IDbSet<Employee> Countries { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}
