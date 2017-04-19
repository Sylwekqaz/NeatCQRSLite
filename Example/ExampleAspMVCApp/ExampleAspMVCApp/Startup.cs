using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExampleAspMVCApp.Startup))]
namespace ExampleAspMVCApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
