using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Change_URL_without_page_load_Default5 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if(true)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "none", "<script>executeAfter();</script>", false);
        
        }
    }
}