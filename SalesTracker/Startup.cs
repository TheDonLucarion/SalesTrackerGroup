using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SalesTracker.Startup))]
namespace SalesTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
