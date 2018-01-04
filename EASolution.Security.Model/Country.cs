using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using EASolution.Model;

namespace EASolution.Security.Domain
{
    public class Country : Entity<int>
    {      
        [Required]
        [Display(Name = "Country Name")]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Account> Persons { get; set; }

        public override string ToString()
        {
            return string.Format("Country {1} Name:{0} {2}", Name, "{", "}");
        }
    }
}
