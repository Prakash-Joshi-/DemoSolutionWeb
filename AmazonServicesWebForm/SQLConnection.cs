
using log4net;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace MagentoIntegration.Lib
{
    public class SQLConnection
    {

        //============================================================
        //***** protected and private variables ********
        //============================================================

        //Start Database Connecion File

        private readonly string DB_TIMEOUT = ConfigurationManager.AppSettings["DB_TIMEOUT"];
        private readonly string DB_MINPOOL = ConfigurationManager.AppSettings["DB_MINPOOL"];
        private readonly string DB_MAXPOOL = ConfigurationManager.AppSettings["DB_MAXPOOL"];


        private readonly string WEBDB_SERVER = ConfigurationManager.AppSettings["WEBDB_SERVER"];
        private readonly string WEBDB_USER = ConfigurationManager.AppSettings["WEBDB_USER"];
        private readonly string WEBDB_PASS = ConfigurationManager.AppSettings["WEBDB_PASS"];
        private readonly string WEBDB_DATABASE = ConfigurationManager.AppSettings["WEBDB_DATABASE"];

        private readonly string DB_SERVER_MDM = ConfigurationManager.AppSettings["DB_SERVER_MDM"];
        private readonly string DB_USER_MDM = ConfigurationManager.AppSettings["DB_USER_MDM"];
        private readonly string DB_PASS_MDM = ConfigurationManager.AppSettings["DB_PASS_MDM"];
        private readonly string DB_DATABASE_MDM = ConfigurationManager.AppSettings["DB_DATABASE_MDM"];

        private readonly string DB_SERVER_Image = ConfigurationManager.AppSettings["DB_SERVER_Image"];
        private readonly string DB_USER_Image = ConfigurationManager.AppSettings["DB_USER_Image"];
        private readonly string DB_PASS_Image = ConfigurationManager.AppSettings["DB_PASS_Image"];
        private readonly string DB_DATABASE_Image = ConfigurationManager.AppSettings["DB_DATABASE_Image"];

        private readonly string DB_SERVER_Mag = ConfigurationManager.AppSettings["DB_SERVER_Mag"];
        private readonly string DB_USER_Mag = ConfigurationManager.AppSettings["DB_USER_Mag"];
        private readonly string DB_PASS_Mag = ConfigurationManager.AppSettings["DB_PASS_Mag"];
        private readonly string DB_DATABASE_Mag = ConfigurationManager.AppSettings["DB_DATABASE_Mag"];

        private readonly string OMSDB_SERVER = ConfigurationManager.AppSettings["OMSDB_SERVER"];
        private readonly string OMSDB_USER = ConfigurationManager.AppSettings["OMSDB_USER"];
        private readonly string OMSDB_PASS = ConfigurationManager.AppSettings["OMSDB_PASS"];
        private readonly string OMSDB_DATABASE = ConfigurationManager.AppSettings["OMSDB_DATABASE"];

        readonly string XmlLogDB_SERVER = ConfigurationManager.AppSettings["XmlLogDB_SERVER"];
        readonly string XmlLogDB_USER = ConfigurationManager.AppSettings["XmlLogDB_USER"];
        readonly string XmlLogDB_PASS = ConfigurationManager.AppSettings["XmlLogDB_PASS"];
        readonly string XmlLogDB_DATABASE = ConfigurationManager.AppSettings["XmlLogDB_DATABASE"];

        private string CString_;
        private string LastError_;
        private bool isRollback_;
        private bool isConnected_;
        private string Query_;
        private string Table_;

        private SqlConnection Connection_;
        private SqlTransaction DatabaseTransaction_;
        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //################################################
        /// <summary>Initializes a new instance of the ResultDBConnectivity.RSQLConnection class with no arguments.</summary>
        public SQLConnection()
        {
            Reset();
        }

        //################################################
        /// <summary>Opens a database connection with the property settings specified in RSQLConnection class.</summary>
        /// </summary>
        /// <summary>
        /// Connection function for OMS databse
        /// </summary>
        public void ConnectMDM()
        {
            try
            {
                string dbPASS = DecryptConnectionString(DB_PASS_MDM);
                CString_ = "Data Source=" + DB_SERVER_MDM + ";Database=" + DB_DATABASE_MDM + ";User ID=" + DB_USER_MDM + ";Password=" + dbPASS + ";Connection Timeout=" + DB_TIMEOUT + ";Min Pool Size=" + DB_MINPOOL + ";Max Pool Size=" + DB_MAXPOOL + ";Pooling =True;Persist Security Info=True;Connection Lifetime=7200;";

                Connection_ = new SqlConnection();
                Connection_.ConnectionString = CString_;
                Connection_.Open();
                isConnected_ = true;
            }
            catch (Exception e)
            {
                LastError_ = "Error in connection:- " + e.Message + System.Environment.NewLine;
                logger.Error(LastError_);
                isConnected_ = false;
            }
        }

        /// <summary>
        /// Connection to live Image dataBase
        /// </summary>
        public void ConnectLiveImageDb()
        {
            try
            {
                string dbPASS = DecryptConnectionString(DB_PASS_Image);
                CString_ = "Data Source=" + DB_SERVER_Image + ";Database=" + DB_DATABASE_Image + ";User ID=" + DB_USER_Image + ";Password=" + dbPASS + ";Connection Timeout=" + DB_TIMEOUT + ";Min Pool Size=" + DB_MINPOOL + ";Max Pool Size=" + DB_MAXPOOL + ";Pooling =True;Persist Security Info=True;Connection Lifetime=7200;";
                Connection_ = new SqlConnection();
                Connection_.ConnectionString = CString_;
                Connection_.Open();
                isConnected_ = true;
            }
            catch (Exception e)
            {
                LastError_ = "Error in connection:- " + e.Message + System.Environment.NewLine;
                logger.Error(LastError_);

                isConnected_ = false;
            }
        }

        /// <summary>
        /// Connection function for Magento databse
        /// </summary>
        public void ConnectMagento()
        {
            try
            {
                string dbPASS = DecryptConnectionString(DB_PASS_Mag);
                CString_ = "Data Source=" + DB_SERVER_Mag + ";Database=" + DB_DATABASE_Mag + ";User ID=" + DB_USER_Mag + ";Password=" + dbPASS + ";Connection Timeout=" + DB_TIMEOUT + ";Min Pool Size=" + DB_MINPOOL + ";Max Pool Size=" + DB_MAXPOOL + ";Pooling =True;Persist Security Info=True;Connection Lifetime=7200;";

                Connection_ = new SqlConnection();
                Connection_.ConnectionString = CString_;
                Connection_.Open();
                isConnected_ = true;
            }
            catch (Exception e)
            {
                LastError_ = "Error in connection:- " + e.Message + System.Environment.NewLine;
                logger.Error(LastError_);
                isConnected_ = false;
            }
        }

        /// <summary>
        /// Connection function for WEB databse
        /// </summary>
        public void ConnectWebshop()
        {
            try
            {
                string WEBDBPASS = DecryptConnectionString(WEBDB_PASS);
                CString_ = "Data Source=" + WEBDB_SERVER + ";Database=" + WEBDB_DATABASE + ";User ID=" + WEBDB_USER + ";Password=" + WEBDBPASS + ";Connection Timeout=" + DB_TIMEOUT + ";Min Pool Size=" + DB_MINPOOL + ";Max Pool Size=" + DB_MAXPOOL + ";Pooling =True;Persist Security Info=True;Connection Lifetime=7200;";
                Connection_ = new SqlConnection();
                Connection_.ConnectionString = CString_;
                Connection_.Open();
                isConnected_ = true;
            }
            catch (Exception e)
            {
                LastError_ = "Error in connection:- " + e.Message + System.Environment.NewLine;
                logger.Error(LastError_);
                isConnected_ = false;
            }
        }

        /// <summary>
        /// Connection function for Oms databse
        /// </summary>
        public void ConnectOMS()
        {
            try
            {
                string OMSDBPASS = DecryptConnectionString(OMSDB_PASS);
                CString_ = "Data Source=" + OMSDB_SERVER + ";Database=" + OMSDB_DATABASE + ";User ID=" + OMSDB_USER + ";Password=" + OMSDBPASS + ";Connection Timeout=" + DB_TIMEOUT + ";Min Pool Size=" + DB_MINPOOL + ";Max Pool Size=" + DB_MAXPOOL + ";Pooling =True;Persist Security Info=True;Connection Lifetime=7200;";
                Connection_ = new SqlConnection();
                Connection_.ConnectionString = CString_;
                Connection_.Open();
                isConnected_ = true;
            }
            catch (Exception e)
            {
                LastError_ = "Error in connection:- " + e.Message + System.Environment.NewLine;
                logger.Error(LastError_);
                isConnected_ = false;
            }
        }

        public void ConnectXmlLogDB()
        {
            try
            {
                var dxPass = DecryptConnectionString(XmlLogDB_PASS);
                CString_ = "Data Source=" + XmlLogDB_SERVER + ";Database=" + XmlLogDB_DATABASE + ";User ID=" + XmlLogDB_USER + ";Password=" + dxPass + ";Connection Timeout=" + DB_TIMEOUT + ";Min Pool Size=" + DB_MINPOOL + ";Max Pool Size=" + DB_MAXPOOL + ";Pooling =True;Persist Security Info=True";
                isConnected_ = true;
                Connection_ = new SqlConnection { ConnectionString = CString_ };
                Connection_.Open();
            }
            catch (Exception e)
            {
                LastError_ = "Error in connection:- " + e.Message + Environment.NewLine;
                logger.Error(LastError_);
                isConnected_ = false;
            }
        }
        //######################################################## 
        /// <summary>Executes a SQL statement and return System.Data.SqlClient.DataReader.</summary>
        /// <param name="Script">SQL statement to execute at the data source.</param>
        /// <returns>A System.Data.SqlClient.SqlDataReader object.</returns>
        public SqlDataReader getReader(String Script)
        {
            SqlCommand cmdQuery = null;
            SqlDataReader readr = null;
            LastError_ = "";

            if (Script.Length > 0 && IsOpen())
            {
                try
                {
                    cmdQuery = new SqlCommand();
                    cmdQuery.CommandText = Script;
                    if (IsBegin()) cmdQuery.Transaction = DatabaseTransaction_;
                    cmdQuery.Connection = Connection_;
                    readr = cmdQuery.ExecuteReader();
                }
                catch (Exception e) { LastError_ = e.Message + System.Environment.NewLine; logger.Error(LastError_); }
            }
            return readr;
        }

        //######################################################## 
        /// <summary>Executes a SQL statement and return System.Data.SqlClient.DataAdapter.</summary>
        /// <param name="Script">SQL statement to execute at the data source.</param>
        /// <returns>A System.Data.SqlClient.SqlDataAdapter object.</returns>
        public SqlDataAdapter getAdapter(String Script)
        {
            SqlCommand cmdQuery = null;
            SqlDataAdapter Adpt = null;
            LastError_ = "";

            if (Script.Length > 0 && IsOpen())
            {
                try
                {
                    cmdQuery = new SqlCommand();
                    cmdQuery.CommandText = Script;
                    if (IsBegin()) cmdQuery.Transaction = DatabaseTransaction_;
                    cmdQuery.Connection = Connection_;
                    Adpt = new SqlDataAdapter(cmdQuery);
                }
                catch (Exception e) { LastError_ = e.Message + System.Environment.NewLine; logger.Error(LastError_); }
            }
            return Adpt;
        }

        //######################################################## 
        /// <summary>Executes a SQL statement and return System.Data.DataTable.</summary>
        /// <param name="Script">SQL statement to execute at the data source.</param>
        /// <returns>A System.Data.DataTable object.</returns>        
        public DataTable getDataTable(String Script)
        {
            SqlCommand cmdQuery = null;
            SqlDataAdapter Adpt = null;
            DataTable dt = null;
            LastError_ = "";

            if (Script.Length > 0 && IsOpen())
            {
                try
                {
                    cmdQuery = new SqlCommand();
                    cmdQuery.CommandText = Script;
                    if (IsBegin()) cmdQuery.Transaction = DatabaseTransaction_;
                    cmdQuery.Connection = Connection_;
                    Adpt = new SqlDataAdapter(cmdQuery);
                    dt = new DataTable();
                    Adpt.Fill(dt);
                    Adpt.Dispose();
                }
                catch (Exception e) { LastError_ = e.Message + System.Environment.NewLine; logger.Error(LastError_); }
            }
            return dt;
        }

        //######################################################## 
        /// <summary>Executes a SQL statement and return System.Data.DataSet.</summary>
        /// <param name="Script">SQL statement to execute at the data source.</param>
        /// <param name="table">The name of the source table to use for table mapping.</param>
        /// <returns>A System.Data.DataSet object.</returns>
        public DataSet getDataSet(String Script, String table)
        {
            SqlCommand cmdQuery = null;
            SqlDataAdapter Adpt = null;
            DataSet ds = null;
            LastError_ = "";

            if (Script.Length > 0 && IsOpen())
            {
                try
                {
                    cmdQuery = new SqlCommand();
                    cmdQuery.CommandTimeout = 120;
                    cmdQuery.CommandText = Script;
                    if (IsBegin()) cmdQuery.Transaction = DatabaseTransaction_;
                    cmdQuery.Connection = Connection_;
                    Adpt = new SqlDataAdapter(cmdQuery);
                    ds = new DataSet();
                    Adpt.Fill(ds, table);
                    Adpt.Dispose();
                }
                catch (Exception e) { LastError_ = e.Message + System.Environment.NewLine; logger.Error(LastError_); }
            }
            return ds;
        }

        //######################################################## 
        ///<summary>Executes a SQL statement and fill System.Data.DataTable. </summary>
        ///<param name="Script">SQL statement to execute at the data source.</param>
        ///<param name="dt">Refernce of an object of System.Data.DataTable.</param>
        public void createDataTable(String Script, ref DataTable dt)
        {
            SqlCommand cmdQuery = null;
            SqlDataAdapter Adpt = null;
            LastError_ = "";

            if (Script.Length > 0 && IsOpen())
            {
                try
                {
                    cmdQuery = new SqlCommand();
                    cmdQuery.CommandText = Script;
                    if (IsBegin()) cmdQuery.Transaction = DatabaseTransaction_;
                    cmdQuery.Connection = Connection_;
                    Adpt = new SqlDataAdapter(cmdQuery);

                    if (dt == null) dt = new DataTable();
                    Adpt.Fill(dt);
                    Adpt.Dispose();
                }
                catch (Exception e) { LastError_ = e.Message + System.Environment.NewLine; logger.Error(LastError_); }
            }
        }

        //######################################################## 
        ///<summary>Executes a SQL statement and fill System.Data.DataTable. </summary>        
        ///<param name="dt">Refernce of an object of System.Data.DataTable.</param>       
        public void createDataTable(ref DataTable dt)
        {
            SqlCommand cmdQuery = null;
            SqlDataAdapter Adpt = null;
            LastError_ = "";

            if (Query_.Length > 0 && IsOpen())
            {
                try
                {
                    cmdQuery = new SqlCommand();
                    cmdQuery.CommandText = Query_;
                    if (IsBegin()) cmdQuery.Transaction = DatabaseTransaction_;
                    cmdQuery.Connection = Connection_;
                    Adpt = new SqlDataAdapter(cmdQuery);

                    if (dt == null) dt = new DataTable();
                    Adpt.Fill(dt);
                    Adpt.Dispose();
                }
                catch (Exception e) { LastError_ = e.Message + System.Environment.NewLine; logger.Error(LastError_); }
            }
        }

        //######################################################## 
        /// <summary>Executes a SQL statement and fill System.Data.DataSet.</summary>
        /// <param name="Script">SQL statement to execute at the data source.</param>
        /// <param name="table">The name of the source table to use for table mapping.</param>
        /// <param name="ds">Refernce of an object of System.Data.DataSet.</param> 
        public void createDataSet(String Script, String table, ref DataSet ds)
        {
            SqlCommand cmdQuery = null;
            SqlDataAdapter Adpt = null;
            LastError_ = "";

            if (Script.Length > 0 && IsOpen())
            {
                try
                {
                    cmdQuery = new SqlCommand();
                    cmdQuery.CommandText = Script;
                    if (IsBegin()) cmdQuery.Transaction = DatabaseTransaction_;
                    cmdQuery.Connection = Connection_;
                    Adpt = new SqlDataAdapter(cmdQuery);

                    if (ds == null) ds = new DataSet();
                    Adpt.Fill(ds, table);
                    Adpt.Dispose();
                }
                catch (Exception e) { LastError_ = e.Message + System.Environment.NewLine; logger.Error(LastError_); }
            }
        }

        //######################################################## 
        /// <summary>Executes a SQL statement and fill System.Data.DataSet.</summary>        
        /// <param name="ds">Refernce of an object of System.Data.DataSet.</param> 
        public void createDataSet(ref DataSet ds)
        {
            SqlCommand cmdQuery = null;
            SqlDataAdapter Adpt = null;
            LastError_ = "";

            if (Query_.Length > 0 && IsOpen())
            {
                try
                {
                    cmdQuery = new SqlCommand();
                    cmdQuery.CommandText = Query_;
                    if (IsBegin()) cmdQuery.Transaction = DatabaseTransaction_;
                    cmdQuery.Connection = Connection_;
                    Adpt = new SqlDataAdapter(cmdQuery);

                    if (ds == null) ds = new DataSet();
                    Adpt.Fill(ds, Table_);
                    Adpt.Dispose();
                }
                catch (Exception e) { LastError_ = e.Message + System.Environment.NewLine; logger.Error(LastError_); }
            }
        }

        //######################################################## 
        /// <summary>Executes a Non Select SQL statement and returns the number of rows affected.</summary>        
        /// <param name="Script">SQL statement to execute at the data source.</param>
        /// <returns>The number of rows affected.</returns>
        public int Execute(String Script)
        {
            SqlCommand cmdQuery;
            LastError_ = "";
            int AffectedRec = 0;

            if (Script.Length > 0 && IsOpen())
            {
                try
                {
                    cmdQuery = new SqlCommand();
                    cmdQuery.CommandText = Script;
                    if (IsBegin()) cmdQuery.Transaction = DatabaseTransaction_;
                    cmdQuery.Connection = Connection_;
                    AffectedRec = cmdQuery.ExecuteNonQuery();
                }
                catch (Exception e) { LastError_ = e.Message + System.Environment.NewLine; logger.Error(LastError_); }
            }
            return AffectedRec;
        }

        //#################################################        
        /// <summary>Creates a new instance of a System.Data.SqlClient.SqlParameter object.</summary>
        /// <param name="Name">The name of the parameter to map.</param>
        /// <param name="Value">An System.Object that is the value of the System.Data.SqlClient.SqlParameter.</param>
        /// <returns>A System.Data.SqlClient.SqlParameter object.</returns>
        public SqlParameter CreateParameter(string Name, Object Value)
        {
            SqlParameter Param = null;
            // if (Value.ToString().Trim().Length == 0) { Value = DBNull.Value; }
            try
            {
                Param = new SqlParameter();
                Param.ParameterName = Name;
                Param.Value = Value;
            }
            catch (Exception e) { LastError_ = e.Message + System.Environment.NewLine; logger.Error(LastError_); }
            return Param;
        }

        //#################################################
        /// <summary>Creates a new instance of a System.Data.SqlClient.SqlParameter object.</summary>
        /// <param name="Name">The name of the parameter to map.</param>
        /// <param name="Type">One of the System.Data.SqlDbType values.</param>
        /// <param name="Value">An System.Object that is the value of the System.Data.SqlClient.SqlParameter.</param>
        /// <returns>A System.Data.SqlClient.SqlParameter object.</returns>       
        public SqlParameter CreateParameter(string Name, SqlDbType Type, Object Value)
        {
            SqlParameter Param = null;
            // if (Value.ToString().Trim().Length == 0) { Value = DBNull.Value; }
            try
            {
                Param = new SqlParameter();
                Param.ParameterName = Name;
                Param.SqlDbType = Type;
                Param.Value = Value;
            }
            catch (Exception e) { LastError_ = e.Message + System.Environment.NewLine; logger.Error(LastError_); }
            return Param;
        }

        //#################################################
        /// <summary>Creates a new instance of a System.Data.SqlClient.SqlParameter object.</summary>
        /// <param name="Name">The name of the parameter to map.</param>
        /// <param name="Type">One of the System.Data.SqlDbType values.</param>
        /// <param name="Size">The length of the parameter.</param>
        /// <param name="Value">An System.Object that is the value of the System.Data.SqlClient.SqlParameter.</param>
        /// <returns>A System.Data.SqlClient.SqlParameter object.</returns>            
        public SqlParameter CreateParameter(string Name, SqlDbType Type, int Size, Object Value)
        {
            SqlParameter Param = null;
            //if (Value.ToString().Trim().Length == 0) { Value = DBNull.Value; }
            try
            {
                Param = new SqlParameter();
                Param.ParameterName = Name;
                Param.SqlDbType = Type;
                Param.Size = Size;
                Param.Value = Value;
            }
            catch (Exception e) { LastError_ = e.Message + System.Environment.NewLine; logger.Error(LastError_); }
            return Param;
        }

        //#################################################
        /// <summary>Creates a new instance of a System.Data.SqlClient.SqlParameter object.</summary>
        /// <param name="Name">The name of the parameter to map.</param>
        /// <param name="Type">One of the System.Data.SqlDbType values.</param>
        /// <param name="Direction">One of the System.Data.ParameterDirection values.</param>
        /// <returns>A System.Data.SqlClient.SqlParameter object.</returns>        
        public SqlParameter CreateParameter(string Name, SqlDbType Type, ParameterDirection Direction)
        {
            SqlParameter Param = null;
            try
            {
                Param = new SqlParameter();
                Param.ParameterName = Name;
                Param.SqlDbType = Type;
                Param.Direction = Direction;
            }
            catch (Exception e) { LastError_ = e.Message + System.Environment.NewLine; logger.Error(LastError_); }
            return Param;
        }

        //#################################################
        /// <summary>Creates a new instance of a System.Data.SqlClient.SqlParameter object.</summary>
        /// <param name="Name">The name of the parameter to map.</param>
        /// <param name="Type">One of the System.Data.SqlDbType values.</param>
        /// <param name="Direction">One of the System.Data.ParameterDirection values.</param>
        /// <param name="Value">An System.Object that is the value of the System.Data.SqlClient.SqlParameter.</param>
        /// <returns>A System.Data.SqlClient.SqlParameter object.</returns>            
        public SqlParameter CreateParameter(string Name, SqlDbType Type, ParameterDirection Direction, Object Value)
        {
            SqlParameter Param = null;
            // if (Value.ToString().Trim().Length == 0) { Value = DBNull.Value; }
            try
            {
                Param = new SqlParameter();
                Param.ParameterName = Name;
                Param.SqlDbType = Type;
                Param.Direction = Direction;
                if (Value != null) { Param.Value = Value; }
            }
            catch (Exception e) { LastError_ = e.Message + System.Environment.NewLine; logger.Error(LastError_); }
            return Param;
        }

        //#################################################
        /// <summary>Creates a new instance of a System.Data.SqlClient.SqlParameter object.</summary>
        /// <param name="Name">The name of the parameter to map.</param>
        /// <param name="Type">One of the System.Data.SqlDbType values.</param>
        /// <param name="Size">The length of the parameter.</param>
        /// <param name="Direction">One of the System.Data.ParameterDirection values.</param>
        /// <returns>A System.Data.SqlClient.SqlParameter object.</returns>            
        public SqlParameter CreateParameter(string Name, SqlDbType Type, int Size, ParameterDirection Direction)
        {
            SqlParameter Param = null;
            try
            {
                Param = new SqlParameter();
                Param.ParameterName = Name;
                Param.SqlDbType = Type;
                Param.Size = Size;
                Param.Direction = Direction;
            }
            catch (Exception e) { LastError_ = e.Message + System.Environment.NewLine; logger.Error(LastError_); }
            return Param;
        }

        //#################################################
        /// <summary>Executes a Non Select SQL Procedure without parameter and returns the number of rows affected.</summary> 
        /// <param name="Script">SQL Procedure Name to execute at the data source.</param>
        /// <returns>The number of rows affected.</returns>
        public int ExecuteProcedureNonQuery(String Script)
        {
            SqlCommand cmdQuery = null;
            int Result = 0;
            LastError_ = "";

            if (Script.Length > 0 && IsOpen())
            {
                try
                {
                    cmdQuery = new SqlCommand();
                    cmdQuery.CommandText = Script;
                    if (IsBegin()) cmdQuery.Transaction = DatabaseTransaction_;
                    cmdQuery.CommandType = CommandType.StoredProcedure;
                    cmdQuery.Connection = Connection_;

                    Result = cmdQuery.ExecuteNonQuery();
                }
                catch (Exception e) { LastError_ = e.Message + System.Environment.NewLine; logger.Error(LastError_); }
            }

            return Result;
        }

        //#################################################
        /// <summary>Executes a Non Select SQL Procedure with parameter and returns the number of rows affected.</summary> 
        /// <param name="Script">SQL Procedure Name to execute at the data source.</param>
        /// <param name="Params">Reference of An Array of System.Data.SqlClient.SqlParameter.</param>
        /// <returns>The number of rows affected.</returns>        
        public int ExecuteProcedureNonQuery(String Script, ref SqlParameter[] Params)
        {
            SqlCommand cmdQuery = null;
            int Result = 0;
            LastError_ = "";

            if (Script.Length > 0 && IsOpen())
            {
                try
                {
                    cmdQuery = new SqlCommand();
                    cmdQuery.CommandText = Script;
                    if (IsBegin()) cmdQuery.Transaction = DatabaseTransaction_;
                    cmdQuery.CommandType = CommandType.StoredProcedure;
                    cmdQuery.Connection = Connection_;

                    for (int i = 0; i < Params.Length; i++)
                    {
                        if (Params[i] != null) { cmdQuery.Parameters.Add(Params[i]); }
                    }
                    Result = cmdQuery.ExecuteNonQuery();
                }
                catch (Exception e) { LastError_ = e.Message + System.Environment.NewLine; logger.Error(LastError_); }
            }

            return Result;
        }

        //#################################################
        ///<summary>Executes a SQL Procedure without parameter and returns System.Data.SqlClient.SqlDataReader.</summary>
        ///<param name="Script">SQL Procedure Name to execute at the data source.</param>        
        ///<returns>A System.Data.SqlClient.SqlDataReader object.</returns>        
        public SqlDataReader ExecuteProcedure(String Script)
        {
            SqlCommand cmdQuery = null;
            SqlDataReader readr = null;
            LastError_ = "";

            if (Script.Length > 0 && IsOpen())
            {
                try
                {
                    cmdQuery = new SqlCommand();
                    cmdQuery.CommandText = Script;
                    if (IsBegin()) cmdQuery.Transaction = DatabaseTransaction_;
                    //cmdQuery.CommandType = CommandType.StoredProcedure;
                    cmdQuery.Connection = Connection_;

                    readr = cmdQuery.ExecuteReader();
                }
                catch (Exception e) { LastError_ = e.Message + System.Environment.NewLine; logger.Error(LastError_); }
            }

            return readr;
        }

        //#################################################
        ///<summary>Executes a SQL Procedure with parameter and returns System.Data.SqlClient.SqlDataReader.</summary>
        ///<param name="Script">SQL Procedure Name to execute at the data source.</param>
        ///<param name="Params">Reference of An Array of System.Data.SqlClient.SqlParameter.</param>
        ///<returns>A System.Data.SqlClient.SqlDataReader object.</returns>   
        public SqlDataReader ExecuteProcedure(String Script, ref SqlParameter[] Params)
        {
            SqlCommand cmdQuery = null;
            SqlDataReader readr = null;
            LastError_ = "";

            if (Script.Length > 0 && IsOpen())
            {
                try
                {
                    cmdQuery = new SqlCommand();
                    cmdQuery.CommandText = Script;
                    if (IsBegin()) cmdQuery.Transaction = DatabaseTransaction_;
                    cmdQuery.CommandType = CommandType.StoredProcedure;
                    cmdQuery.Connection = Connection_;

                    for (int i = 0; i < Params.Length; i++)
                    {
                        if (Params[i] != null) { cmdQuery.Parameters.Add(Params[i]); }
                    }
                    readr = cmdQuery.ExecuteReader();
                }
                catch (Exception e) { LastError_ = e.Message + System.Environment.NewLine; logger.Error(LastError_); }
            }

            return readr;
        }

        //#################################################
        ///<summary>Execute a SQL Procedure with parameter and fill a System.Data.DataSet.</summary>
        ///<param name="Script">SQL Procedure Name to execute at the data source.</param>
        ///<param name="table">The name of the source table to use for table mapping.</param>
        ///<param name="ds">Refernce of an object of System.Data.DataSet.</param> 
        ///<param name="Params">Reference of An Array of System.Data.SqlClient.SqlParameter.</param>
        public void ExecuteProcedure(String Script, String table, ref DataSet ds, ref SqlParameter[] Params)
        {
            SqlCommand cmdQuery = null;
            SqlDataAdapter Adpt = null;
            LastError_ = "";

            if (Script.Length > 0 && IsOpen())
            {
                try
                {
                    cmdQuery = new SqlCommand();
                    cmdQuery.CommandTimeout = 60;
                    cmdQuery.CommandText = Script;
                    if (IsBegin()) cmdQuery.Transaction = DatabaseTransaction_;
                    cmdQuery.CommandType = CommandType.StoredProcedure;
                    cmdQuery.Connection = Connection_;

                    for (int i = 0; i < Params.Length; i++)
                    {
                        if (Params[i] != null) { cmdQuery.Parameters.Add(Params[i]); }
                    }

                    Adpt = new SqlDataAdapter(cmdQuery);

                    if (ds == null) ds = new DataSet();
                    Adpt.Fill(ds, table);
                    Adpt.Dispose();
                }
                catch (Exception e) { LastError_ = e.Message + System.Environment.NewLine; logger.Error(LastError_); throw; }
            }
        }

        //#################################################
        ///<summary>Execute a SQL Procedure without parameter and fill a System.Data.DataSet.</summary>
        ///<param name="Script">SQL Procedure Name to execute at the data source.</param>
        ///<param name="table">The name of the source table to use for table mapping.</param>
        ///<param name="ds">Refernce of an object of System.Data.DataSet.</param>      
        public void ExecuteProcedure(String Script, String table, ref DataSet ds)
        {
            SqlCommand cmdQuery = null;
            SqlDataAdapter Adpt = null;
            LastError_ = "";

            if (Script.Length > 0 && IsOpen())
            {
                try
                {
                    cmdQuery = new SqlCommand();
                    cmdQuery.CommandText = Script;
                    if (IsBegin()) cmdQuery.Transaction = DatabaseTransaction_;
                    cmdQuery.CommandType = CommandType.StoredProcedure;
                    cmdQuery.Connection = Connection_;

                    Adpt = new SqlDataAdapter(cmdQuery);
                    if (ds == null) ds = new DataSet();
                    Adpt.Fill(ds, table);
                    Adpt.Dispose();
                }
                catch (Exception e) { LastError_ = e.Message + System.Environment.NewLine; logger.Error(LastError_); }
            }
        }

        //#################################################
        ///<summary>Execute a SQL Procedure without parameter and fill a System.Data.DataTable.</summary>
        ///<param name="Script">SQL Procedure Name to execute at the data source.</param>        
        ///<param name="dt">Refernce of an object of System.Data.DataTable.</param>        
        public void ExecuteProcedure(String Script, ref DataTable dt)
        {
            SqlCommand cmdQuery = null;
            SqlDataAdapter Adpt = null;
            LastError_ = "";

            if (Script.Length > 0 && IsOpen())
            {
                try
                {
                    cmdQuery = new SqlCommand();
                    cmdQuery.CommandText = Script;
                    if (IsBegin()) cmdQuery.Transaction = DatabaseTransaction_;
                    cmdQuery.CommandType = CommandType.StoredProcedure;
                    cmdQuery.Connection = Connection_;

                    Adpt = new SqlDataAdapter(cmdQuery);
                    if (dt == null) dt = new DataTable();
                    Adpt.Fill(dt);
                    Adpt.Dispose();
                }
                catch (Exception e) { LastError_ = e.Message + System.Environment.NewLine; logger.Error(LastError_); }
            }
        }

        //#################################################
        ///<summary>Execute a SQL Procedure with parameter and fill a System.Data.DataTable.</summary>
        ///<param name="Script">SQL Procedure Name to execute at the data source.</param>        
        ///<param name="dt">Refernce of an object of System.Data.DataTable.</param>    
        ///<param name="Params">Reference of An Array of System.Data.SqlClient.SqlParameter.</param>
        public void ExecuteProcedure(String Script, ref DataTable dt, ref SqlParameter[] Params)
        {
            SqlCommand cmdQuery = null;
            SqlDataAdapter Adpt = null;
            LastError_ = "";

            if (Script.Length > 0 && IsOpen())
            {
                try
                {
                    cmdQuery = new SqlCommand();
                    cmdQuery.CommandText = Script;
                    if (IsBegin()) cmdQuery.Transaction = DatabaseTransaction_;
                    cmdQuery.CommandType = CommandType.StoredProcedure;
                    cmdQuery.Connection = Connection_;

                    for (int i = 0; i < Params.Length; i++)
                    {
                        if (Params[i] != null) { cmdQuery.Parameters.Add(Params[i]); }
                    }

                    Adpt = new SqlDataAdapter(cmdQuery);

                    if (dt == null) dt = new DataTable();
                    Adpt.Fill(dt);
                    Adpt.Dispose();
                }
                catch (Exception e) { LastError_ = e.Message + System.Environment.NewLine; logger.Error(LastError_); }
            }
        }

        //#################################################
        ///<summary>Execute a SQL Procedure with parameter and fill a System.Data.DataSet, SQL Procedure Name and source table name must be set by property.</summary>       
        ///<param name="ds">Refernce of an object of System.Data.DataSet.</param> 
        ///<param name="Params">Reference of An Array of System.Data.SqlClient.SqlParameter.</param>
        public void ExecuteProcedure(ref DataSet ds, ref SqlParameter[] Params)
        {
            SqlCommand cmdQuery = null;
            SqlDataAdapter Adpt = null;
            LastError_ = "";

            if (Query_.Length > 0 && IsOpen())
            {
                try
                {
                    cmdQuery = new SqlCommand();
                    cmdQuery.CommandText = Query_;
                    if (IsBegin()) cmdQuery.Transaction = DatabaseTransaction_;
                    cmdQuery.CommandType = CommandType.StoredProcedure;
                    cmdQuery.Connection = Connection_;

                    for (int i = 0; i < Params.Length; i++)
                    {
                        if (Params[i] != null) { cmdQuery.Parameters.Add(Params[i]); }
                    }

                    Adpt = new SqlDataAdapter(cmdQuery);

                    if (ds == null) ds = new DataSet();
                    Adpt.Fill(ds, Table_);
                    Adpt.Dispose();
                }
                catch (Exception e) { LastError_ = e.Message + System.Environment.NewLine; logger.Error(LastError_); }
            }
        }

        //#################################################
        ///<summary>Execute a SQL Procedure without parameter and fill a System.Data.DataSet, SQL Procedure Name and source table name must be set by property.</summary>       
        ///<param name="ds">Refernce of an object of System.Data.DataSet.</param>         
        public void ExecuteProcedure(ref DataSet ds)
        {
            SqlCommand cmdQuery = null;
            SqlDataAdapter Adpt = null;
            LastError_ = "";

            if (Query_.Length > 0 && IsOpen())
            {
                try
                {
                    cmdQuery = new SqlCommand();
                    cmdQuery.CommandText = Query_;
                    if (IsBegin()) cmdQuery.Transaction = DatabaseTransaction_;
                    cmdQuery.CommandType = CommandType.StoredProcedure;
                    cmdQuery.Connection = Connection_;

                    Adpt = new SqlDataAdapter(cmdQuery);
                    if (ds == null) ds = new DataSet();
                    Adpt.Fill(ds, Table_);
                    Adpt.Dispose();
                }
                catch (Exception e) { LastError_ = e.Message + System.Environment.NewLine; logger.Error(LastError_); }
            }
        }

        //#################################################
        ///<summary>Execute a SQL Procedure without parameter and fill a System.Data.DataTable, SQL Procedure Name must be set by property.</summary>       
        ///<param name="dt">Refernce of an object of System.Data.DataTable.</param>
        public void ExecuteProcedure(ref DataTable dt)
        {
            SqlCommand cmdQuery = null;
            SqlDataAdapter Adpt = null;
            LastError_ = "";

            if (Query_.Length > 0 && IsOpen())
            {
                try
                {
                    cmdQuery = new SqlCommand();
                    cmdQuery.CommandText = Query_;
                    if (IsBegin()) cmdQuery.Transaction = DatabaseTransaction_;
                    cmdQuery.CommandType = CommandType.StoredProcedure;
                    cmdQuery.Connection = Connection_;

                    Adpt = new SqlDataAdapter(cmdQuery);
                    if (dt == null) dt = new DataTable();
                    Adpt.Fill(dt);
                    Adpt.Dispose();
                }
                catch (Exception e) { LastError_ = e.Message + System.Environment.NewLine; logger.Error(LastError_); }
            }
        }

        //#################################################
        ///<summary>Execute a SQL Procedure with parameter and fill a System.Data.DataTable, SQL Procedure Name must be set by property.</summary>       
        ///<param name="dt">Refernce of an object of System.Data.DataTable.</param> 
        ///<param name="Params">Reference of An Array of System.Data.SqlClient.SqlParameter.</param>        
        public void ExecuteProcedure(ref DataTable dt, ref SqlParameter[] Params)
        {
            SqlCommand cmdQuery = null;
            SqlDataAdapter Adpt = null;
            LastError_ = "";

            if (Query_.Length > 0 && IsOpen())
            {
                try
                {
                    cmdQuery = new SqlCommand();
                    cmdQuery.CommandText = Query_;
                    if (IsBegin()) cmdQuery.Transaction = DatabaseTransaction_;
                    cmdQuery.CommandType = CommandType.StoredProcedure;
                    cmdQuery.Connection = Connection_;

                    for (int i = 0; i < Params.Length; i++)
                    {
                        if (Params[i] != null) { cmdQuery.Parameters.Add(Params[i]); }
                    }

                    Adpt = new SqlDataAdapter(cmdQuery);

                    if (dt == null) dt = new DataTable();
                    Adpt.Fill(dt);
                    Adpt.Dispose();
                }
                catch (Exception e) { LastError_ = e.Message + System.Environment.NewLine; logger.Error(LastError_); }
            }
        }

        //#################################################
        ///<summary>Starts a database transaction.</summary>        
        public void BeginTrans()
        {
            try
            {
                DatabaseTransaction_ = Connection_.BeginTransaction();
            }
            catch (Exception e) { LastError_ = e.Message + System.Environment.NewLine; logger.Error(LastError_); }
        }

        //#################################################
        ///<summary>Commits the database transaction.</summary>
        public void CommitTrans()
        {
            try
            {
                DatabaseTransaction_.Commit();
            }
            catch (Exception e) { LastError_ = e.Message + System.Environment.NewLine; logger.Error(LastError_); }
        }

        //#################################################
        ///<summary>Rolls back a transaction from a pending state.</summary>
        public void RollbackTrans()
        {
            try
            {
                DatabaseTransaction_.Rollback();
                isRollback_ = true;
            }
            catch (Exception e) { LastError_ = e.Message + System.Environment.NewLine; logger.Error(LastError_); }
        }

        //#################################################
        /// <summary>Gets the System.Data.SqlClient.SqlConnection object.</summary>
        public SqlConnection Connection
        {
            get
            {
                return Connection_;
            }
        }

        //#################################################
        ///<summary>Get the Roll back status of database transaction.</summary>        
        public bool isRollback
        {
            get
            {
                return isRollback_;
            }
        }

        //#################################################
        ///<summary>Get the connected status of System.Data.SqlClient.SqlConnection object.</summary>        
        public bool isConnected
        {
            get
            {
                return isConnected_;
            }
        }

        //#################################################
        ///<summary>Get the last error message.</summary>        
        public string LastError
        {
            get
            {
                return LastError_;
            }
        }

        //#################################################
        ///<summary>Set the SQL Statement or Procedure Name.</summary>        
        public string Query
        {
            set
            {
                Query_ = value;
            }
        }

        //#################################################
        ///<summary>Set the source table name for System.Data.DataSet mapping.</summary>    
        public string Table
        {
            set
            {
                Table_ = value;
            }
        }

        //######################################################## 
        ///<summary>Check the database transaction status, return true if transaction begin else false.</summary>       
        public Boolean IsBegin() { if (DatabaseTransaction_ != null)  return true; else  return false; }

        //########################################################
        ///<summary>Check the database connection status, return true if connection is open else false.</summary>       
        public Boolean IsOpen() { if (Connection_ != null) return true; else return false; }

        //######################################################## 
        ///<summary>Check the exception status, return true if exception occures else false.</summary>        
        public Boolean HasError() { if (LastError_.Length > 0) return true; else return false; }


        //#################################################
        ///<summary>Reset all class varaibale and object.</summary>        
        public void Reset()
        {
            try
            {
                if (Connection_ != null) { if (Connection_.State == ConnectionState.Open) { Connection_.Dispose(); } }
                Connection_ = null;

                if (DatabaseTransaction_ != null) { DatabaseTransaction_.Rollback(); }
                DatabaseTransaction_ = null;
            }
            catch (Exception) { Connection_ = null; }

            isRollback_ = false;
            isConnected_ = false;
            LastError_ = "";
            CString_ = "";
            Query_ = "";
            Table_ = "";
        }

        private string DecryptConnectionString(string str)
        {
            var b = Convert.FromBase64String(str);
            var decryptedConnectionString = System.Text.Encoding.ASCII.GetString(b);
            return decryptedConnectionString;
        }

    }

}


