using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ashion.Startup))]
namespace Ashion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
