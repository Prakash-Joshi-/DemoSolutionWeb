using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebMethod_web_method_using_javascript : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static string ProcessIT(string name, string address)
    {
        string result = "Welcome Mr. " + name + ". Your address is '" + address + "'.";
        return result;
    }
}