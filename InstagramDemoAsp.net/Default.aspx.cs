using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InstagramDemoAsp.net
{
    public partial class _Default : Page
    {
        static string code = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request["code"]) && !Page.IsPostBack)
            {
                code = Request["code"].ToString();
                GetDataInstagramToken();

            }  
        }
        //Function used to get instagram user id and access token  
        public void GetDataInstagramToken()
        {
            var json = "";
            try
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("client_id", ConfigurationManager.AppSettings["instagram.clientid"].ToString());
                parameters.Add("client_secret", ConfigurationManager.AppSettings["instagram.clientsecret"].ToString());
                parameters.Add("grant_type", "authorization_code");
                parameters.Add("redirect_uri", ConfigurationManager.AppSettings["instagram.redirecturi"].ToString());
                parameters.Add("code", code);
                parameters.Add("scope", "public_content");

                WebClient client = new WebClient();
                var result = client.UploadValues("https://api.instagram.com/oauth/aaccess_token", "POST", parameters);
                var response = System.Text.Encoding.Default.GetString(result);

                // deserializing nested JSON string to object  
                var jsResult = (JObject)JsonConvert.DeserializeObject(response);
                string accessToken = (string)jsResult["access_token"];
                int id = (int)jsResult["user"]["id"];

                //This code register id and access token to get on client side  
                Page.ClientScript.RegisterStartupScript(this.GetType(), "GetToken", "<script>var instagramaccessid=\"" + @"" + id + "" + "\"; var instagramaccesstoken=\"" + @"" + accessToken + "" + "\";</script>");

            }
            catch (Exception ex)
            {
                Response.Redirect("http://www.stackoverflow.com/search?q=" + ex.Message);

            }
        }  

        protected void btnAuthenticate_Click(object sender, EventArgs e)
        {
            var client_id = ConfigurationManager.AppSettings["instagram.clientid"].ToString();
            var redirect_uri = ConfigurationManager.AppSettings["instagram.redirecturi"].ToString();
            //Response.Redirect("https://api.instagram.com/oauth/authorize/?client_id=" + client_id + "&redirect_uri=" + redirect_uri + "&response_type=code");

            Response.Redirect("https://api.instagram.com/oauth/authorize/?client_id=" + client_id + "&redirect_uri=" + redirect_uri + "&response_type=code&scope=public_content+follower_list+likes+comments+relationships");
        }
    }
}