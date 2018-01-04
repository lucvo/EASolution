using System.ComponentModel.DataAnnotations;
using EASolution.Model;

namespace EASolution.Recruitment.Model
{
    public class SourceType : Entity<int>
    {
        [MaxLength(255)]
        public string Name { get; set; }
    }
}