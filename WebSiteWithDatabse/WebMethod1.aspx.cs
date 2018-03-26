using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebMethod1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static ArrayList GetDepartments()
    {
        return new ArrayList()
        {
            new { Value = 1, Display = "HR" },
            new { Value = 2, Display = "Admin" },
            new { Value = 3, Display = "Accounts" },
            new { Value = 4, Display = "IT" },
            new { Value = 5, Display = "Sales" },
            new { Value = 6, Display = "Customer Support" }
        };
    }


    [WebMethod]
    public static ArrayList GetEmployeeNames(int departmentID)
    {
        switch (departmentID)
        {
            case 1:
                return new ArrayList()
                {
                    new { Value = 1, Display = "Rajiv" },
                    new { Value = 2, Display = "Aditya" },
                    new { Value = 3, Display = "Anuj" }
                };

            case 2:
                return new ArrayList()
                {
                    new { Value = 4, Display = "Deepak Khurana" },
                    new { Value = 5, Display = "Ajit Singh" },
                    new { Value = 6, Display = "Ajit Singh" }
                };
            case 3:
                return new ArrayList()
        {
            new { Value = 7, Display = "Salman" },
            new { Value = 8, Display = "Tom Mandal" },
            new { Value = 9, Display = "Sunil Gupta" }
        };
            case 4:
                return new ArrayList()
        {
            new { Value = 10, Display = "Emily" },
            new { Value = 11, Display = "Lauri" },
            new { Value = 12, Display = "Sonu" },
            new { Value = 13, Display = "Karan" }
        };
            case 5:

                return new ArrayList()
        {
            new { Value = 14, Display = "Andy" },
            new { Value = 15, Display = "Reema Yaheee" },
            new { Value = 15, Display = "Neah Shameee" }
        };
            default:

                throw new ApplicationException("Invalid Department");
        }
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static Response GetStatus()
    {
        RootObject RootObject = new RootObject();
        Data data = new Data()
        {
            id="35",
            itemcode = "SMU3072",
            webcid="1"
        };

        Response response = new Response()
        {
            status="true",
            message = "Measurement saved successfully",
            data= data
        };
        return response;
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetStatus1()
    {
        RootObject RootObject = new RootObject();
        Data data = new Data()
        {
            id = "35",
            itemcode = "SMU3072",
            webcid = "1"
        };

        Response response = new Response()
        {
            status = "true",
            message = "Measurement saved successfully",
            data = data
        };
        var oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        Context.Response.Write(oSerializer.Serialize(response));
    }
}

public class Data
{
    public string id { get; set; }
    public string itemcode { get; set; }
    public string webcid { get; set; }
}

public class Response
{
    public string status { get; set; }
    public string message { get; set; }
    public Data data { get; set; }
}

public class RootObject
{
    public Response response { get; set; }
}