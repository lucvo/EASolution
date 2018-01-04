using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EASolution.Model;
using Serilog;

namespace EASolution.Infrastructure.Service.Decorator
{
    public class EntityServiceDecorator<T> where T : BaseEntity
    {
        private readonly IEntityService<T> _decorated;
        public EntityServiceDecorator(IEntityService<T> decorated)
        {
            _decorated = decorated;
        }
        
        public void Create(T entity)
        {
            _decorated.Create(entity);
        }

        public void Delete(T entity)
        {
            _decorated.Delete(entity);
        }

        public IEnumerable<T> GetAll()
        {
            var result = _decorated.GetAll();
            return result;
        }

        public void Update(T entity)
        {
            _decorated.Update(entity);
        }

        public T GetById(int id)
        {
            var result = _decorated.GetById(id);
            return result;
        }
    }
}
