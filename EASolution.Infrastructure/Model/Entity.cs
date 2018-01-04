using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EASolution.Model
{
    public abstract class BaseEntity {
        [Timestamp]
        public virtual Byte[] RowVersion { get; set; }
    }

    public abstract class Entity<T> : BaseEntity, IEntity<T> 
    {
        public virtual T Id { get; set; }
    }
}
