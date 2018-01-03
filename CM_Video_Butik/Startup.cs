using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CM_Video_Butik.Startup))]
namespace CM_Video_Butik
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
