using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EASolution.Domain
{
    /// <summary>
    /// The common attribute.
    /// </summary>
    [ComplexType]
    public class Common
    {
        [Required(ErrorMessage = "Please Enter Your Name")]
        [Display(Name = "Name")]
        [Column("Name")]
        [MaxLength(255)]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Column("Description")]
        [MaxLength(500)]
        public virtual string Description { get; set; }
    }

    [ComplexType]
    public class CommonSetup
    {
        [Required(ErrorMessage = "Please Enter Description")]
        [Display(Name = "Description")]
        [Column("Description")]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please Enter Weight")]
        [Column("Weight")]
        [Display(Name = "Weight")]
        public int Weight { get; set; }
    }
}