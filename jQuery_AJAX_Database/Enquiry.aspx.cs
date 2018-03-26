using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Enquiry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    [ScriptMethod]
    public static void SaveUser(EnquiryDetails enquiryDetails)
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO EnquiryDetails VALUES(@FirstName, @LastName,@EmailID,@PhoneNo)"))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@FirstName", enquiryDetails.FirstName);
                cmd.Parameters.AddWithValue("@LastName", enquiryDetails.LastName);
                cmd.Parameters.AddWithValue("@EmailID", enquiryDetails.EmailID);
                cmd.Parameters.AddWithValue("@PhoneNo", enquiryDetails.PhoneNo);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
    
}
public class EnquiryDetails
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailID { get; set; }
    public string PhoneNo { get; set; }
}
