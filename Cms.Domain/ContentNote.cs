using EASolution.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Domain
{
    public class ContentNote: AuditableEntity<Guid>
    {
        public string Note { get; set; }
        public string Author { get; set; }
        public Guid ContentId { get; set; }
    }
}
