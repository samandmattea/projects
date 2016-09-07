using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CapstoneV2.Web.Startup))]
namespace CapstoneV2.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
