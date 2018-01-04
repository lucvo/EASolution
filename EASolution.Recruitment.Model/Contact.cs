using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EASolution.Model;

namespace EASolution.Recruitment.Model
{
    public class Contact : Entity<int>
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

        [MaxLength(4)]
        public string ExtNumber { get; set; }

        public int? ManagerId { get; set; }

        public Contact Manager { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public virtual ICollection<JobPosting> RequestedJobs { get; set; }
        public virtual ICollection<Interview> Interviews { get; set; }
    }
}