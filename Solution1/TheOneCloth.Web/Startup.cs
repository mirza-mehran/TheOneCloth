using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheOneCloth.Web.Startup))]
namespace TheOneCloth.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
