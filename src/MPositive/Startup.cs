using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MPositive.Startup))]
namespace MPositive
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
