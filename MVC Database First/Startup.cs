using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Database_First.Startup))]
namespace MVC_Database_First
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
