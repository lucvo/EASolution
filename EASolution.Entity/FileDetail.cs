using System;
using System.ComponentModel.DataAnnotations;
using EASolution.Model;

namespace EASolution.Domain
{
    public class FileDetail : Entity<Guid>
    {
        [Required(ErrorMessage = "Please Enter Your Name")]
        [Display(Name = "File Name")]
        [MaxLength(250)]
        public string FileName { get; set; }

        [MaxLength(10)]
        public string Extension { get; set; }

        [Display(Name = "Support")]
        public int SupportId { get; set; }
        public virtual Support Support { get; set; }

    }
}