using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCWork.Startup))]
namespace MVCWork
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
