using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;
using EASolution.Model;
using System;

namespace EASolution.Security.Domain
{
    public class Account : AuditableEntity<Guid>
    {
       
        [Required]
        [DisplayName("First Name")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        [Required]
        [MaxLength(14)]
        public string ZipCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [MaxLength(50)]
        public string State { get; set; }

        [Required]
        [MaxLength(50)]
        public string Database { get; set; }
        public int CountryId { get; set;  }

        public virtual Country Country { get; set; }

        public virtual AppUser User { get; set; }

        [NotMapped]
        public Guid UserId { get { return Id; } }
       

        [NotMapped]
        public string Name { get { return string.Format("{0} {1}", FirstName, LastName); } }
        
        public override string ToString()
        {
            return string.Format("Person{7} Name:{0}, Phone:{1}, Address:{2}, ZipCode: {3}, City: {4}, State: {5}, Country: {6} {8}", Name,Phone,Address,ZipCode,City,State, CountryId,"{","}");
        }
    }
}
