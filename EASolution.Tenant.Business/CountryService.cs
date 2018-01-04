using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EASolution.Infrastructure.Service;
using EASolution.Infrastructure.Persistence;
using EASolution.Security.Domain;

namespace EASolution.TenantStore.Service
{
    public class CountryService : EntityService<Country>, ICountryService
    {

        public CountryService(IContext context)
            : base(context)
        {
            _dbset = _context.Set<Country>();
        }
        
    }
}
