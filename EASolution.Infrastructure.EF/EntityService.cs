using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EASolution.Model;

using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using EASolution.Infrastructure.Persistence;

namespace EASolution.Infrastructure.Service
{
    public class EntityService<T> : IEntityService<T> where T : BaseEntity
    {
        protected IContext _context;
        protected IDbSet<T> _dbset;

        public EntityService(IContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }     

        public virtual void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _dbset.Add(entity);
            Save();
        }


        public virtual void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            Save();
        }

        public virtual void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");         
              _dbset.Remove(entity);
            Save();
        }

        public virtual IEnumerable<T> GetAll()
        {         
             return _dbset.AsEnumerable<T>();
        }


        public virtual T GetById(int id)
        {
            return _dbset.FirstOrDefault();
        }

        private void Save()
        {
            bool saveFailed;
            do
            {
                saveFailed = false;
                try
                {
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;

                    // Get the current entity values and the values in the database 
                    var entry = ex.Entries.Single();
                    var currentValues = entry.CurrentValues;
                    var databaseValues = entry.GetDatabaseValues();

                    // Choose an initial set of resolved values. In this case we 
                    // make the default be the values currently in the database. 
                    var resolvedValues = currentValues.Clone();

                    // Have the user choose what the resolved values should be 
                    HaveUserResolveConcurrency(currentValues, databaseValues, resolvedValues);

                    // Update the original values with the database values and 
                    // the current values with whatever the user choose. 
                    entry.OriginalValues.SetValues(databaseValues);
                    entry.CurrentValues.SetValues(resolvedValues);
                }
            } while (saveFailed);
        }

        private void HaveUserResolveConcurrency(DbPropertyValues currentValues,
                                               DbPropertyValues databaseValues,
                                               DbPropertyValues resolvedValues)
        {
            // Show the current, database, and resolved values to the user and have 
            // them edit the resolved values to get the correct resolution. 
        }
    }
}
