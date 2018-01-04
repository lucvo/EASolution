using System.Data.Entity;
using EASolution.Domain;
using EASolution.Model;

namespace EASolution.Persistence
{
    public interface IConcreteContext : IContext
    {
        IDbSet<Project> Projects { get; set; }
        IDbSet<UseCaseCategory> UseCaseCategories { get; set; }
        IDbSet<ActorCategory> ActorCategories { get; set; }
        IDbSet<Factor> Factors { get; set; }
        IDbSet<Person> Persons { get; set; }
        IDbSet<Country> Countries { get; set; } 

    }
}