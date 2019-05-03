using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VidPaynes.Startup))]
namespace VidPaynes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
