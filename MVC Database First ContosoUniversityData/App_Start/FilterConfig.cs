using System.Web;
using System.Web.Mvc;

namespace MVC_Database_First_ContosoUniversityData
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
