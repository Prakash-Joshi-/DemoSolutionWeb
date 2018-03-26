using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Josn_demo.App_Code;
using System.Web.Script.Serialization;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Josn_demo
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Person _person = new Person("John", "Doe", true, 666);
            string _JSON = new JavaScriptSerializer().Serialize(_person);
            WebItemWiseMeasurementValues values = new WebItemWiseMeasurementValues()
            {
                field_name = "aroundbust",
                isRequired = "1",
                minValue = "28",
                maxValue = "66"
            };
            List<WebItemWiseMeasurementValues> webItemWiseMeasurementValues = new List<WebItemWiseMeasurementValues>();
            webItemWiseMeasurementValues.Add(values);

            Item item = new Item()
            {
                itemcode = "kqu30",
                webcid="2",
                webItemWiseMeasurementValues=webItemWiseMeasurementValues
            };

            string itemJson = new JavaScriptSerializer().Serialize(item);
            
            //var strJSON = String.Empty;

            //context.Request.InputStream.Position = 0;
            //using (var inputStream = new StreamReader(context.Request.InputStream))
            //{
            //    strJSON = inputStream.ReadToEnd();
            //}

            //JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            //object serJsonDetails = javaScriptSerializer.Deserialize(strJSON, typeof(object));



            string json;
            using (var reader = new StreamReader(Request.InputStream))
            {
                json = reader.ReadToEnd();
            }
           // var person = Newtonsoft.Json.Decode(json);

            // uses using Newtonsoft.Json;
            dynamic stuff = JsonConvert.DeserializeObject("{ 'Name': 'Jon Smith', 'Address': { 'City': 'New York', 'State': 'NY' }, 'Age': 42 }");
            string name = stuff.Name;
            string address = stuff.Address.City;

            // using using Newtonsoft.Json.Linq;
            dynamic stuff1 = JObject.Parse("{ 'Name': 'Jon Smith', 'Address': { 'City': 'New York', 'State': 'NY' }, 'Age': 42 }");
            string name1 = stuff.Name;
            string address1 = stuff.Address.City;
        }
    }
}