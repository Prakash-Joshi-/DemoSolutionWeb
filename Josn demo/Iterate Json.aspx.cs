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
    public partial class Iterate_Json : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            JObject json = JObject.Parse(File.ReadAllText(@"D:\Prakash\DemoSolutionWeb\Josn demo\JSON\json2.json"));
            dynamic dynJson = JsonConvert.DeserializeObject(File.ReadAllText(@"D:\Prakash\DemoSolutionWeb\Josn demo\JSON\json1.json"));
            foreach (var item in dynJson)
            {
                Console.WriteLine("{0} {1} {2} {3}\n", item.id, item.displayName, item.slug, item.imageUrl);
                Response.Write("item.id " + item.id + " <br> item.displayName " + item.displayName + " <br> item.slug " + item.slug + " <br> item.imageUrl " + item.imageUrl + " <br><br><br>");
            }


            //dynJson = JsonConvert.DeserializeObject(File.ReadAllText(@"D:\Prakash\DemoSolutionWeb\Josn demo\JSON\json2.json"));
            //foreach (var item in dynJson)
            //{
            //    Console.WriteLine("{0} {1} {2} {3}\n", item.Volumes.id, item.Volumes.displayName, item.Volumes.slug, item.Volumes.imageUrl);
            //    Response.Write("item.id " + item.Volumes.id + " <br> item.displayName " + item.Volumes.displayName + " <br> item.slug " + item.Volumes.slug + " <br> item.imageUrl " + item.Volumes.imageUrl + " <br><br><br>");
            //}

            // http://stackoverflow.com/questions/18066844/how-to-ignore-case-when-searching-a-json-object

            // http://stackoverflow.com/questions/11132288/iterating-over-json-object-in-c-sharp
            string file = Server.MapPath("~/JSON/json1.json");
            //deserialize JSON from file  
            string Json1 = System.IO.File.ReadAllText(file);
            var list = JsonConvert.DeserializeObject<List<MyItem>>(Json1);

            file = Server.MapPath("~/JSON/mmt1.json");
            //deserialize JSON from file  
            Json1 = System.IO.File.ReadAllText(file);
            var mmtlist = JsonConvert.DeserializeObject<RootObject>(Json1);


        }
    }
    public class MyItem
    {
        public string id;
        public string displayName;
        public string name;
        public string slug;
        public string imageUrl;
    }
    public class Mmtdetail
    {
        public int mmtid { get; set; }
        public string mmtname { get; set; }
        public string mmttype { get; set; }
        public string mmtformat { get; set; }
        public string email { get; set; }
        public string domain { get; set; }
        public string Customername { get; set; }
        public int itemcategory { get; set; }
    }

    public class Mmtdetails1
    {
        //public int mmtid { get; set; }
        public string filedname { get; set; }
        public string value { get; set; }
    }

    public class RootObject
    {
        public List<Mmtdetail> mmtdetails { get; set; }
        public List<Mmtdetails1> mmtdetails1 { get; set; }
    }
}