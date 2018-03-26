using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WCF_Cache_Demo
{
    public partial class WebFormCache1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            FileStream fs = new FileStream(Server.MapPath("schemadata.xml"), FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fs);
            ds.ReadXml(reader);
            fs.Close();

            DataView Source = new DataView(ds.Tables[0]);

            // Use the LiteralControl constructor to create a new
            // instance of the class.
            LiteralControl myLiteral = new LiteralControl();

            // Set the LiteralControl.Text property to an HTML
            // string and the TableName value of a data source.
            myLiteral.Text = "<h6><font face=\"verdana\">Caching an XML Table: " + Source.Table.TableName + " </font></h6>";

            MyDataGrid.DataSource = Source;
            MyDataGrid.DataBind();

            TimeMsg.Text = DateTime.Now.ToString("G");

        }
    }
}