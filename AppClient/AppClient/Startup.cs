using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppClient.Startup))]
namespace AppClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
