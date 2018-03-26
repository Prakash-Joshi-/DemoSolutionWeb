using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InstagramDotNet;

namespace InstagramDemoAsp.net
{
    public partial class instagram : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Instagram ig = new Instagram("YOUR_ACCESS_TOKEN");

            //Outputs the numeric value of a username
            //returns a JSON String containing the user id value
            //ig.getUserId("USER_NAME");

            //Bound to your repeater in your .aspx page
            //Repeater1.DataSource = ig.getMediaRecent("INSTAGRAM_USER_ID", 10);
            //Repeater1.DataBind();

            Instagram ig = new Instagram("1677602674.bea4693.3bdc016e3f2c48d0ab86965c010c897f");

            //Outputs the numeric value of a username
            //returns a JSON String containing the user id value
            ig.getUserId("prakash_joshi_");

            //Bound to your repeater in your .aspx page
            Repeater1.DataSource = ig.getMediaRecent("1677602674", 10);
            Repeater1.DataBind();
        }
    }
}