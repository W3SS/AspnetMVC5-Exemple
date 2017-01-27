using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ModuloCongresso.UI.Site.Startup))]
namespace ModuloCongresso.UI.Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
