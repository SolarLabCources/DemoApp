using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcAdmin.Startup))]
namespace MvcAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
