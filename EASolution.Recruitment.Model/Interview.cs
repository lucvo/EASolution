using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EASolution.Model;

namespace EASolution.Recruitment.Model
{
    public class Interview : AuditableEntity<Guid>
    {
        [Required]
        public DateTime InterviewedDate { get; set; }

        public int InterviewerId { get; set; }
        public Contact Interviewer { get; set; }

        public bool PassedInterview { get; set; }
        public bool PassedBackgroundCheck { get; set; }

        [MaxLength(255)]
        [Display(Name = "Comment")]
        public string InterviewComment { get; set; }

        public Guid JobApplicationId { get; set; }
        public JobApplication JobApplication { get; set; }
    }
}
