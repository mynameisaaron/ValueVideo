using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ValueVideo.Startup))]
namespace ValueVideo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
