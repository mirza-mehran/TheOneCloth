using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(jQuery_Ajax_In_CRUD_Operations.Startup))]
namespace jQuery_Ajax_In_CRUD_Operations
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
