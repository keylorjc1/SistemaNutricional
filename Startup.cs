using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemaNutricional.Startup))]
namespace SistemaNutricional
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
