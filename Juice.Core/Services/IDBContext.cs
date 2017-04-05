using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Juice.Core.Services
{
    public interface IDBContext
    {
        DbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();

        void Dispose();
    }
}
