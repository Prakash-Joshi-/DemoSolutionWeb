using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Change_URL_without_page_load_Default7 : System.Web.UI.Page
{
    static String queryString;
    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(queryString))
        {
            Button1.PostBackUrl = queryString;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        queryString = "?value=1234";
        Response.Redirect(String.Format("Default7.aspx?FieldName={0}", "Assign Values here")); 
    }
}