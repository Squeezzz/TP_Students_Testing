using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(autorisation.Startup))]
namespace autorisation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
