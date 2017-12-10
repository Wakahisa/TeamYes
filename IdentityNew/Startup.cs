using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityNew.Startup))]
namespace IdentityNew
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
