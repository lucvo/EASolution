using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EASolution.Model;
using System.Collections.Generic;

namespace EASolution.Security.Domain
{
    public class AppUser : AuditableEntity<Guid>
    {
        [Required]
        [MaxLength(255)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(255)]
        public string Email { get; set; }
        [Required]
        [MaxLength(255)]
        public string Password { get; set; }

        public bool Enable { get; set; }

        public virtual Account UserInfo { get; set; }

        public virtual ICollection<AppRole> Roles { get; set; }
    }
}