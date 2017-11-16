using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeamYesIdentity.Startup))]
namespace TeamYesIdentity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
