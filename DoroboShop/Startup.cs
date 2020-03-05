using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoroboShop.Startup))]
namespace DoroboShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
