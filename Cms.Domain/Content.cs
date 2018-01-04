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
    public class Content:AuditableEntity<Guid>
    {
        public bool IsCheckedOut { get; set; }
        public bool IsProtected { get; set; }
        public bool Status { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpireyDate { get; set; }
        public ApprovalAttribute Approved { get; set; }
        public DateTime DeletedDate { get; set; }
        [MaxLength(256)]
        public string DeletedBy { get; set; }
        public int ZoneId { get; set; }
        public Zone Zone { get; set; }
    }
}
