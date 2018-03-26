using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    SqlConn conn = new SqlConn();
    string queryString = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime value = new DateTime(2016, 5, 31);
        Response.Write(value);
        Response.Write(value.AddDays(1.5).ToString("dd/MM/yyyy"));
        Response.Write(value.AddDays(2.3));
        DataTable dt = new DataTable();
        queryString = "SELECT  st.[STD_ID], stp.PAY_AMT  FROM [TestDb].[dbo].[STUDENT] st join [TestDb].[dbo].[STUDENT_PAYMENT] stp on st.STD_ID = stp.STD_ID";

        conn.Connectdb();
        dt = conn.getDataTable(queryString);

        queryString = "SELECT * FROM [TestDb].[dbo].[STUDENT_PAYMENT]";

        DataSet ds = new DataSet();
        ds = conn.getDataSet(queryString, "DS");
        ds.Tables.Add(dt);

        queryString = "SELECT * FROM [TestDb].[dbo].[STUDENT]";
        dt = conn.getDataTable(queryString);
        ds.Tables.Add(dt);
        var data = (from table1 in ds.Tables[0].AsEnumerable()
                    join
                        table2 in ds.Tables[2].AsEnumerable()
                        on (Int32)table1["std_id"] equals (Int32)table2["std_id"]
                    select new { 
                    StudentId= table1["std_id"],
                    Payment=table1["Pay_amt"]
                    });
    }

    public DataSet getDataSet(string procedureName)
    {
        DataSet ds = null;
        try
        {
            if (!conn.isConnected)
            {
                conn.Connectdb();
                if (conn.HasError()) { }
            }
            ds = new DataSet();
            queryString = "web_act_OrderdetailmmtUpdate";
            SqlParameter[] param = new SqlParameter[3];
            param[0] = conn.CreateParameter("@orderid", SqlDbType.VarChar, procedureName);
            conn.ExecuteProcedure(queryString, "update", ref ds, ref param);
        }
        catch (Exception ex)
        {
            //USFUtility.GenrateLog(ex.Message);
        }
        return ds;
    }
}
