using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TenantStore.Portal.Startup))]
namespace TenantStore.Portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
