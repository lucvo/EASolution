using EASolution.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantStore.Domain
{
    public class Account : AuditableEntity<Guid>
    {
        public string Name { get; set; }
        public string Database { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
