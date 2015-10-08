using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Wisata.Startup))]
namespace Wisata
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
