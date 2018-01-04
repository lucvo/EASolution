using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EASolution.Domain
{
     [ComplexType]
    public class ApprovalAttribute
    {
        [Column("ApprovedDate")]
        public DateTime? Date { get; set; }

        [MaxLength(256)]
        [Column("ApprovedBy")]
        public string By { get; set; }
    }
}