using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImageOperatoins.Images_from_unsplash.it
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://unsplash.it/list");
            httpWebRequest.Method = WebRequestMethods.Http.Get;
            httpWebRequest.Accept = "application/json";
            HttpWebResponse response = httpWebRequest.GetResponse() as HttpWebResponse;
            string text;
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                text = sr.ReadToEnd();
            }
            //var a = JsonConvert.DeserializeObject<UnsplashImageData>(text);
            var b = new JavaScriptSerializer().Deserialize<IEnumerable<UnsplashImageData>>(text);
            IEnumerable<UnsplashImageData> data = JsonConvert.DeserializeObject<IEnumerable<UnsplashImageData>>(text);

            string jsonStringSingle = "{'Id': 1, 'Name':'Thulasi Ram.S'}".Replace("'", "\"");
            var entity = new JavaScriptSerializer().Deserialize<IdName>(jsonStringSingle);

            string jsonStringCollection = "[{'Id': 2, 'Name':'Thulasi Ram.S'},{'Id': 2, 'Name':'Raja Ram.S'},{'Id': 3, 'Name':'Ram.S'}]".Replace("'", "\"");
            var collection = new JavaScriptSerializer().Deserialize<IEnumerable<IdName>>(jsonStringCollection);

            
        }
    }

    public class UnsplashImageData
    {
        public string format { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string filename { get; set; }
        public int id { get; set; }
        public string author { get; set; }
        public string author_url { get; set; }
        public string post_url { get; set; }
    }

    public class IdName
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    /*
       http://stackoverflow.com/questions/3279888/how-to-add-parameters-into-a-webrequest
        WebRequest example with parameters
        string data = "username=<value>&password=<value>"; //replace <value>
        byte[] dataStream = Encoding.UTF8.GetBytes(data);
        private string urlPath = "http://xxx.xxx.xxx/manager/";
        string request = urlPath + "index.php/org/get_org_form";
        WebRequest webRequest = WebRequest.Create(request);
        webRequest.Method = "POST";
        webRequest.ContentType = "application/x-www-form-urlencoded";
        webRequest.ContentLength = dataStream.Length;  
        Stream newStream=webRequest.GetRequestStream();
        // Send the data.
        newStream.Write(dataStream,0,dataStream.Length);
        newStream.Close();
        WebResponse webResponse = webRequest.GetResponse();
     */
}