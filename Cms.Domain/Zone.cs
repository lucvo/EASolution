using EASolution.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Domain
{
    public class Zone: AuditableEntity<int>
    {
        public bool IsProtected { get; set; }

        public bool HasContent { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int ParentZoneId { get; set; }
        public Zone ParentZone { get; set; }
    }
}
