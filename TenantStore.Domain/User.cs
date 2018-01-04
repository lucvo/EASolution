using EASolution.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantStore.Domain
{
    public class User : AuditableEntity<Guid>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public bool Enable { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}
