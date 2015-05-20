using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Twatter.Application.Startup))]
namespace Twatter.Application
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
