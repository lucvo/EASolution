using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EASolution.Model;

namespace EASolution.Domain
{
    /// <summary>
    /// The factor.
    /// </summary>
    public class Factor : Entity<int>
    {
        [Required(ErrorMessage = "Please Enter Factory Type")]
        [Display(Name = "Factory Type")]
        public FactoryType Type { get; set; }

        [Required(ErrorMessage = "Please Enter Factory Name")]
        [Display(Name = "Factory Name")]
        [Column("Name")]
        [MaxLength(50)]
        public string Name { get; set; }

        public CommonSetup Detail { get; set; }

        [Required(ErrorMessage = "Please Enter Factory Weight Value")]
        [Display(Name = "Weight Value")]
        public int Value { get; set; }


        [DisplayName("Project")]
        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
    }
}