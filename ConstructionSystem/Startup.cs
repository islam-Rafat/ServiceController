using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ConstructionSystem.Startup))]
namespace ConstructionSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
