using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidly_Team.Startup))]
namespace Vidly_Team
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
