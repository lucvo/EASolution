using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EASolution.Model;

namespace EASolution.Domain
{
    public class Document : Entity<int>
    {
        [ConcurrencyCheck]
        [Required(ErrorMessage = "Please Enter Your Name")]
        [Display(Name = "Name")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Summary")]
        [Display(Name = "Summary")]
        [MaxLength(2500)]
        public string Summary { get; set; }

        public virtual ICollection<FileDetail> FileDetails { get; set; }

    }
}