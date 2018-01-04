using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EASolution.Model;

namespace EASolution.Recruitment.Model
{
    public class Position : AuditableEntity<int>
    {
        [MaxLength(255)]
        public string Name { get; set; }
        public bool Available { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Contact> Interviewers { get; set; }
        public virtual ICollection<Candidate> Candidates { get; set; } 
        public virtual ICollection<JobPosting> JobPostings { get; set; } 
    }
}