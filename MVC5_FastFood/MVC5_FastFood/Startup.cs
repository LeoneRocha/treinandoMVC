using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5_FastFood.Startup))]
namespace MVC5_FastFood
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
