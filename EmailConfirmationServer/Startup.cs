using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmailConfirmationServer.Startup))]
namespace EmailConfirmationServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
