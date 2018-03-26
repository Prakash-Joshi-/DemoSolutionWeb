using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Call_javascript_from_code_behind_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnServerSide_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "myFunction", "myFunction();", true);
    }

    ////Following statement is used to call pre-defined javascript function
    //protected void btnServerSide_Click(object sender, EventArgs e)
    //{
    //    ScriptManager.RegisterStartupScript(myUpdatePanelID, myUpdatePanelID.GetType(),
    //    "myFunction", "myFunction();", true);
    //}
}