using System.Collections.Generic;
using EASolution.Model;

namespace EASolution.Recruitment.Model
{
    public class Department : Entity<int>
    {
        public string Name { get; set; }
        public virtual ICollection<Contact> Interviewers { get; set; } 
    }
}