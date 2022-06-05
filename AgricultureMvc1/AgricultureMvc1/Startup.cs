using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AgricultureMvc1.Startup))]
namespace AgricultureMvc1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
