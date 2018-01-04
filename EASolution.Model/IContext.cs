using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace EASolution.Model
{
    public interface IContext
    {

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        IList<TEntity> ExecuteSqlQuery<TEntity>(string sqlQuery, params DbParameter[] parameters);
        int ExecuteSqlCommand(string sqlQuery, params DbParameter[] parameters);
        T ExecuteScalarCommand<T>(string sqlQuery, params System.Data.Common.DbParameter[] parameters);
        
        int SaveChanges();
        Task<int> SaveChangesAsync();

        void Dispose();

    }
}