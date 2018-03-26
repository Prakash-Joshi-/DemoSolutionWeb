using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Database_First_ContosoUniversityData.Startup))]
namespace MVC_Database_First_ContosoUniversityData
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
