using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TimeTrax.Startup))]
namespace TimeTrax
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
