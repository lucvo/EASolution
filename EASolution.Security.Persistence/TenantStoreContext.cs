using System.Data.Entity;
using EASolution.Domain;
using EASolution.Infrastructure.Persistence;
using EASolution.Security.Domain;

namespace EASolution.Persistence
{
    /// <summary>
    /// The concrete context.
    /// </summary>
    public class TenantStoreContext : DataContext
    {
        public TenantStoreContext()
            : base("TenantStoreContext")
        {
            this.Configuration.LazyLoadingEnabled = true;

        }

        protected override void MapAdditionalConfiguration(DbModelBuilder modelBuilder)
        {

        }

        public IDbSet<AppUser> Users { get; set; }
        public IDbSet<Account> UserAccounts { get; set; } 

        public IDbSet<AppRole> Roles { get; set; }
    }
}
