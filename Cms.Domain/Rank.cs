using EASolution.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Domain
{
    public class Rank: Entity<int>
    {
        public int RankOrdinal { get; set; }
        public int Value { get; set; }
    }
}
