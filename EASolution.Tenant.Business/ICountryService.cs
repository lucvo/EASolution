using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EASolution.Domain;
using EASolution.Model;
using EASolution.Infrastructure.Service;
using EASolution.Security.Domain;

namespace EASolution.TenantStore.Service
{
    public interface ICountryService : IEntityService<Country>
    {
       
    }
}
