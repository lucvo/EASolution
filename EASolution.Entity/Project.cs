using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using EASolution.Model;

namespace EASolution.Domain
{
    /// <summary>
    /// The project.
    /// </summary>
    public class Project : AuditableEntity<int>
    {
        public Common Detail { get; set; }

         [Required(ErrorMessage = "Please Enter Your Unit (Hour or Day)")]
        public EstimationUnit Unit { get; set; }

        [Required(ErrorMessage = "Please Enter Your Effort Per Use Case Point")]
        [Column("EffortPerPoint")]
        public int UnitPerPoint { get; set; }

        public ApprovalAttribute Approved { get; set; }

        public ICollection<UseCaseCategory> UseCaseWeightSetup { get; set; }
        public ICollection<ActorCategory> ActorWeightSetup { get; set; }
        public ICollection<Factor> FactorSetup { get; set; }

        public ICollection<ProjectTask> ProjectTasks { get; set; } 
    }
}
