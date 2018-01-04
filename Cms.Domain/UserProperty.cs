using EASolution.Domain;
using EASolution.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Domain
{
    public class UserProperty: AuditableEntity<Guid>
    {
        public Common Detail { get; set; }
        [MaxLength(50)]
        public string Type { get; set; }
        public Guid OwnerId { get; set; }
    }
}
