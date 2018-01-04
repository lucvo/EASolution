using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EASolution.Model;

namespace EASolution.Recruitment.Model
{
    public class JobPosting : AuditableEntity<int>
    {
        [MaxLength(255)]
        public string Name { get; set; }
        public string JobDescription { get; set; }
        public string JobSkills { get; set; }
        public string Benefits { get; set; }
        public int HiringManagerId { get; set; }
        public Contact HiringManager { get; set; }
        public string PostedDate { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime ApporveDate { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public virtual ICollection<JobApplication> JobApplications { get; set; } 
    }
}