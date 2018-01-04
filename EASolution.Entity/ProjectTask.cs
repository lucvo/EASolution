using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using EASolution.Model;

namespace EASolution.Domain
{
    public class ProjectTask : AuditableEntity<Guid>
    {
        public Common Detail { get; set; }
        
        public CategoryType UseCase { get; set; }
        public int UseCaseWeight { get; set; }

        public CategoryType Actor { get; set; }
        public int ActorWeight { get; set; }

        public int Estimate { get; set; }

        [DisplayName("Project")]
        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
    }
}