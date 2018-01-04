using EASolution.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Domain
{
    public class ContentNode: AuditableEntity<Guid>
    {
        public string Source { get; set; }
        public bool Status { get; set; }
        public bool IsCheckOut { get; set; }
        public int Version { get; set; }
        public DateTime DeletedDate { get; set; }
        [MaxLength(256)]
        public string DeletedBy { get; set; }
        public Guid ContentId { get; set; }
        public Content Content { get; set; }
        public int TypeId { get; set; }
        public ContentNodeType Type { get; set; }
    }
}
