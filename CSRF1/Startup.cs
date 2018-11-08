using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSRF1.Startup))]
namespace CSRF1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
