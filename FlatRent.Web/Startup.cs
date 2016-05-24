using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FlatRent.Web.Startup))]
namespace FlatRent.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
