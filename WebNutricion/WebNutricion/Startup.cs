using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebNutricion.Startup))]
namespace WebNutricion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
