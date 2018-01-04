using System.Data.Entity;
using EASolution.Domain;
using EASolution.Infrastructure.Persistence;

namespace EASolution.Persistence
{
    /// <summary>
    /// The concrete context.
    /// </summary>
    public class ProjectManagementContext : DataContext
    {
        public ProjectManagementContext()
            : base("EASolutionContext")
        {
            this.Configuration.LazyLoadingEnabled = true;

        }

        protected override void MapAdditionalConfiguration(DbModelBuilder modelBuilder)
        {

        }

        public IDbSet<Project> Projects { get; set; }
        public IDbSet<ProjectTask> Tasks { get; set; } 

        public IDbSet<UseCaseCategory> UseCaseCategories { get; set; }

        public IDbSet<ActorCategory> ActorCategories { get; set; }

        public IDbSet<Factor> Factors { get; set; }
    }
}
