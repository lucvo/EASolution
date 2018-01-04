using EASolution.Model;
using EASolution.Security.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EASolution.StaffManagement.Model
{
    public class Employee : AuditableEntity<Guid>
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public virtual AppUser User { get; set; }

        [NotMapped]
        public Guid UserId { get { return Id; } }

        [NotMapped]
        public string Name { get { return string.Format("{0} {1}", FirstName, LastName); } }

        public override string ToString()
        {
            return string.Format("Person{6} Name:{0}, Phone:{1}, Address:{2}, ZipCode: {3}, City: {4}, State: {5}, {7}", Name, Phone, Address, ZipCode, City, State, "{", "}");
        }
    }
}
