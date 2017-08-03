using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Roomaku.Startup))]
namespace Roomaku
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
