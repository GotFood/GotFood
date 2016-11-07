using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GotFood.Startup))]
namespace GotFood
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
