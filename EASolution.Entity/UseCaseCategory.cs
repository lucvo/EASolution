using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EASolution.Model;

namespace EASolution.Domain
{
    /// <summary>
    /// The use case category.
    /// </summary>
    public class UseCaseCategory : Entity<int>
    {
        [Required(ErrorMessage = "Please Enter Use Case Type")]
        [Display(Name = "Use Case Type")]
        [Column("Type")]
        public CategoryName Name { get; set; }

        public CommonSetup Detail { get; set; }


        [DisplayName("Project")]
        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
    }
}