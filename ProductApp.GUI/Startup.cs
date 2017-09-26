using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProductApp.GUI.Startup))]
namespace ProductApp.GUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
