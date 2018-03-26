using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Call_javascript_from_code_behind_Using_Session : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["newUser"] = "false";
    }
    protected void CallJavascript(object sender, EventArgs e)
    {
        Session["newUser"] = "true";
    }
}