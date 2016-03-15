using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TownCleanWeb.Startup))]
namespace TownCleanWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
