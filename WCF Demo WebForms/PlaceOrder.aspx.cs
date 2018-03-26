using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WCF_Demo_WebForms
{
    public partial class PlaceOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Order order = new Order
            {
                OrderID = "10550",
                OrderDate = DateTime.Now.ToString(),
                ShippedDate = DateTime.Now.AddDays(10).ToString(),
                ShipCountry = "India",
                OrderTotal = "781"
            };

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Order));
            MemoryStream mem = new MemoryStream();
            ser.WriteObject(mem, order);
            string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
            WebClient webClient = new WebClient();
            webClient.Headers["Content-type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            webClient.UploadString("http://localhost:52769/OrderService.svc/PlaceOrder", "POST", data);   
        }
    }
}