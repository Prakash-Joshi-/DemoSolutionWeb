
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;

namespace GraphApplication
{
    public partial class GoogleChart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetChartData();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static object[] GetChartData()
        {
            List<GoogleChartData> data = new List<GoogleChartData>(); 
            //Here MyDatabaseEntities  is our dbContext
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                data = dc.GoogleChartDatas.ToList();
            }

            var chartData = new object[data.Count + 1];
            chartData[0] = new object[]{
                "Year",
                "Electronics",
                "Books &amp; Media",
                "Home &amp; Kitchen",
                "Average"
            };

            int j = 0;
            foreach (var i in data)
            {
                j++;
                chartData[j] = new object[] {i.Year.ToString(), i.Electronics, i.BookAndMedia, i.HomeAndKitchen,
                    (i.Electronics + i.BookAndMedia + i.HomeAndKitchen)/3};
            }
            return chartData;
        } 
    }
}