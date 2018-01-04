using EASolution.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Domain
{
    public class ContentNodeType:Entity<int>
    {
        [MaxLength(50)]
        public string Type { get; set; }
        public int TypeOrdinal { get; set; }
    }
}
