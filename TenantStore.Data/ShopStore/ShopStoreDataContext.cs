using EASolution.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TenantStore.Data.ShopData
{
    public class ShopStoreDataContext : DataContext
    {
        public ShopStoreDataContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {

        }
        protected override void MapAdditionalConfiguration(DbModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }
    }
}
