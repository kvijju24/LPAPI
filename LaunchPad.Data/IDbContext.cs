using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace LaunchPad.Data
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
        void Dispose();
        DbEntityEntry Entry(object entity);
    }
}
