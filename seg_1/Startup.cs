using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(seg_1.Startup))]
namespace seg_1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
