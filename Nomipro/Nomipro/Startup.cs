using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nomipro.Startup))]
namespace Nomipro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
