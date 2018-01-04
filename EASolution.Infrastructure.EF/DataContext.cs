using EASolution.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EASolution.Infrastructure.Persistence
{
    public abstract class DataContext : DbContext, IContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataContext"/> class.
        /// </summary>
        /// <param name="nameOrConnectionString">Either the database name or a connection string.</param>
        protected DataContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        /// <summary>
        /// The on model creating.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ////Configure RowVersion property as Concurrency token
            modelBuilder.Properties()
                .Where(p => p.Name == "RowVersion")
                .Configure(p => p.IsConcurrencyToken(true));

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            this.MapAdditionalConfiguration(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// The add configuration mapping.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        protected abstract void MapAdditionalConfiguration(DbModelBuilder modelBuilder);

        /// <summary>
        /// The save changes.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditableEntity
                    && (x.State == System.Data.Entity.EntityState.Added || x.State == System.Data.Entity.EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                var entity = entry.Entity as IAuditableEntity;
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
                        Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                        Entry(entity).Property(x => x.CreatedDate).IsModified = false;
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
            var sql = new StringBuilder();
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
        /// <returns>number of effective rows</returns>
        public int ExecuteSqlCommand(string sqlQuery, params System.Data.Common.DbParameter[] parameters)
        {
            var sql = new StringBuilder();
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

            return Database.ExecuteSqlCommand(sql.ToString(), parameters);
        }

        /// <summary>
        /// Executes the scalar command.
        /// </summary>
        /// <typeparam name="TValue">Type value
        /// </typeparam>
        /// <param name="sqlQuery">
        /// The SQL query.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// vale 
        /// </returns>
        public TValue ExecuteScalar<TValue>(string sqlQuery, params System.Data.Common.DbParameter[] parameters)
        {
            var sql = new StringBuilder();
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
            return Database.SqlQuery<TValue>(sql.ToString(), parameters).FirstOrDefault<TValue>();

        }
    }
}
