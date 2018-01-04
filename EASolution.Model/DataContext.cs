using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EASolution.Model
{
    public class DataContext : DbContext, IContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataContext"/> class.
        /// </summary>
        public DataContext() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataContext"/> class.
        /// </summary>
        /// <param name="nameOrConnectionString">Either the database name or a connection string.</param>
        public DataContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure RowVersion property as Concurrency token
            modelBuilder.Properties()
                .Where(p => p.Name == "RowVersion")
                .Configure(p => p.IsConcurrencyToken(true));

            AddConfigurationMapping(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        public virtual void AddConfigurationMapping(DbModelBuilder modelBuilder)
        {

        }
        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditableEntity
                    && (x.State == System.Data.Entity.EntityState.Added || x.State == System.Data.Entity.EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                IAuditableEntity entity = entry.Entity as IAuditableEntity;
                if (entity != null)
                {
                    string identityName = Thread.CurrentPrincipal.Identity.Name;
                    DateTime now = DateTime.UtcNow;

                    if (entry.State == System.Data.Entity.EntityState.Added)
                    {
                        entity.CreatedBy = identityName;
                        entity.CreatedDate = now;
                    }
                    else
                    {
                        base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                        base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                    }

                    entity.UpdatedBy = identityName;
                    entity.UpdatedDate = now;
                }
            }

            return base.SaveChanges();
        }

        /// <summary>
        /// Executes the SQL query.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="sqlQuery">The SQL query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public IList<TEntity> ExecuteSqlQuery<TEntity>(string sqlQuery, params System.Data.Common.DbParameter[] parameters)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("{0}", sqlQuery);
            int i = 0;
            foreach (var p in parameters)
            {
                if (i == 0)
                    sql.AppendFormat(" @{0}", p.ParameterName);
                else
                    sql.AppendFormat(", @{0}", p.ParameterName);
                i++;
            }
            var result = Database.SqlQuery<TEntity>(sql.ToString(), parameters).ToList<TEntity>();
            return result;
        }
        /// <summary>
        /// Executes the SQL command.
        /// </summary>
        /// <param name="sqlQuery">The SQL query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public int ExecuteSqlCommand(string sqlQuery, params System.Data.Common.DbParameter[] parameters)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("{0}", sqlQuery);
            int i = 0;
            foreach (var p in parameters)
            {
                if (i == 0)
                    sql.AppendFormat(" @{0}", p.ParameterName);
                else
                    sql.AppendFormat(", @{0}", p.ParameterName);
                i++;
            }
            return Database.ExecuteSqlCommand(TransactionalBehavior.EnsureTransaction, sql.ToString(), parameters);
        }

        /// <summary>
        /// Executes the scalar command.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="sqlQuery">The SQL query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public TEntity ExecuteScalarCommand<TEntity>(string sqlQuery, params System.Data.Common.DbParameter[] parameters)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("{0}", sqlQuery);
            int i = 0;
            foreach (var p in parameters)
            {
                if (i == 0)
                    sql.AppendFormat(" @{0}", p.ParameterName);
                else
                    sql.AppendFormat(", @{0}", p.ParameterName);
                i++;
            }
            return Database.SqlQuery<TEntity>(sql.ToString(), parameters).FirstOrDefault<TEntity>();

        }
    }
}
