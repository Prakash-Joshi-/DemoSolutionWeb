using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Jquery_AutoComplete : System.Web.UI.Page
{
    static SqlConn conn = new SqlConn();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static List<string> GetADUsers(string strADUser)
    {
        string AutoCmpltVal = string.Empty;
        List<string> objList = new List<string>();
        string query = string.Format("Select distinct Emp_FirstName,Emp_MiddleName from Employee where Emp_FirstName LIKE '%{0}%'", strADUser);

        try
        {
            if (!conn.isConnected)
            {
                conn.Connectdb();
                if (conn.HasError()) { }
            }
            SqlDataReader dr = conn.getReader(query);
            while (dr.Read())
            {
                AutoCmpltVal = (string)dr["Emp_FirstName"] + "," + (string)dr["Emp_MiddleName"];
                objList.Add(AutoCmpltVal);
            }
            
        }
        catch (Exception ex)
        {
        }
        return objList;
        //using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["mycon"]))
        //{
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    SqlDataReader dr;
        //    con.Open();
        //    dr = cmd.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        AutoCmpltVal = (string)dr["Emp_FirstName"] + "," + (string)dr["Emp_MiddleName"];
        //        objList.Add(AutoCmpltVal);
        //    }
        //    return objList;
        //}
    }
}