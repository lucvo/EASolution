using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EASolution.Model;

namespace EASolution.Recruitment.Model
{
    public class JobApplication : AuditableEntity<Guid>
    {
        public string Resume { get; set; }

        [MaxLength(255)]
        [Display(Name = "Resume file")]
        public string AttachedFile { get; set; }

        public DateTime AppliedDate { get; set; }

        public int AppliedById { get; set; }
        public Candidate AppliedCandidate { get; set; }
        public int JobPostingId { get; set; }
        public JobPosting JobPosting { get; set; }
        public ICollection<Interview> Interviews { get; set; } 
    }
}