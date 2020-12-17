using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MiniVault.Startup))]
namespace MiniVault
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
