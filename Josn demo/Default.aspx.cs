using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Josn_demo
{
    public partial class _Default : Page
    {
        public string var1 = "hello";
        public string var2 = "world";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            JObject jo = JObject.Parse(File.ReadAllText(@"D:\Prakash\DemoSolutionWeb\Josn demo\JSON\sachin.json"));
            string VolumeId = (string)jo["Volumes"][0]["VolumeId"];
            var allVolumeId = from p in jo["Volumes"] 
                              select (string)p["VolumeId"];

            foreach (var item in allVolumeId)
            {
                Response.Write(" \n");
                Response.Write(item);
            }
            // read JSON directly from a file
            using (StreamReader file = File.OpenText(@"D:\Prakash\DemoSolutionWeb\Josn demo\JSON\sachin.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject o2 = (JObject)JToken.ReadFrom(reader);
            }
        }
    }
}