using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using EASolution.Model;

namespace EASolution.Recruitment.Model
{
    public class Candidate : AuditableEntity<int>
    {
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        
        [Required]
        [MaxLength(60)]
        public string Email { get; set; }
        
        [MaxLength(14)]
        public string HomePhone { get; set; }
        
        [Required]
        [MaxLength(14)]
        public string MobilePhone { get; set; }
        public int OriginalPositionId { get; set; }
        public int SuggestedPositionId { get; set; }
        
        public bool Rehire { get; set; }
        public int SourceId { get; set; }
        public SourceType Source { get; set; }
        public virtual ICollection<JobApplication> SubmittedApplications { get; set; }
        public Position OriginalPosition { get; set; }
        public Position SuggestedPosition { get; set; }
    }
    public class Feedback : AuditableEntity<int>
    {
        public int CandidateId { get; set; }
        public string ApplicationFeedback { get; set; }
       
        public Candidate ApplyingCandidate { get; set; }
      
    }
    public class BackgroundCheck : AuditableEntity<int>
    {
        public int CandidateId { get; set; }
        public DateTime BackgroundCheckDate { get; set; }
        public Candidate ApplyingCandidate { get; set; }
    }
}