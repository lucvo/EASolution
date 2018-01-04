using System.Data.Entity;

namespace EASolution.Infrastructure.Persistence
{
    public class EFCodeConfig : DbConfiguration
    {
        public EFCodeConfig()
        {
            //define configuration here
            this.AddInterceptor(new EFCommandInterceptor());
        }
    }

}
