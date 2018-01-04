using EASolution.Domain;
using EASolution.Model;
using EASolution.Security.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EASolution.Security.Domain
{
    public class AppRole : Entity<int>
    {
        public Common Detail { get; set; }
        public int RoleOrdinal {get;set; }

        public virtual ICollection<AppUser> Persons { get; set; }
    }
}
