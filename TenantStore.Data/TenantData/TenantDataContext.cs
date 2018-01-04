using EASolution.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TenantStore.Domain;

namespace TenantStore.Data.TenantData
{
    public class TenantDataContext : DataContext
    {
        public TenantDataContext() : base("tenantStore")
        {

        }
        protected override void MapAdditionalConfiguration(DbModelBuilder modelBuilder)
        {
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
