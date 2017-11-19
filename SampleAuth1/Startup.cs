using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SampleAuth1.Startup))]
namespace SampleAuth1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
