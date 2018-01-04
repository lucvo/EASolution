using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EASolution.Model;
using Autofac.Extras.DynamicProxy2;

namespace EASolution.Infrastructure.Service
{
    [Intercept("log-calls")]
    public interface IEntityService<T> : IService
     where T : BaseEntity
    {
        void Create(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Update(T entity);
    }
}
