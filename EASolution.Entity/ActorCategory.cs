using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EASolution.Model;

namespace EASolution.Domain
{
    /// <summary>
    /// The actor category.
    /// </summary>
    public class ActorCategory : Entity<int>
    {
        [Required(ErrorMessage = "Please Enter Actor Type")]
        [Display(Name = "Actor Type")]
        [Column("Type")]
        public CategoryType Name { get; set; }
        public Common Detail { get; set; }

        [DisplayName("Project")]
        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
    }
}