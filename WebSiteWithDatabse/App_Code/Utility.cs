using System;
using System.IO;
using System.Web.Hosting;

/// <summary>
/// Summary description for Utility
/// </summary>
public class Utility
{
    public Utility()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static void WriteLog(string sPathName, string sErrMsg)
    {
        string sLogFormat;
        string sErrorTime;

        //sLogFormat used to create log files format :
        // dd/mm/yyyy hh:mm:ss AM/PM ==> Log Message
        sLogFormat = DateTime.Now.ToShortDateString().ToString() + "\t" + DateTime.Now.ToLongTimeString().ToString() + "\t";

        //this variable used to create log filename format "
        //for example filename : LogYYYYMMDD
        string sYear = DateTime.Now.Year.ToString();
        string sMonth = DateTime.Now.Month.ToString();
        string sDay = DateTime.Now.Day.ToString();
        if (sDay.Length == 1) { sDay = '0' + sDay; }
        if (sMonth.Length == 1) { sMonth = '0' + sMonth; }
        sErrorTime = sDay + "-" + sMonth + "-" + sYear;

        using (StreamWriter sw = new StreamWriter(HostingEnvironment.ApplicationPhysicalPath + "\\dberror\\" + sErrorTime + ".log", true))
        {
            sw.WriteLine(sLogFormat + sErrMsg);
            sw.Flush();
            sw.Close();
            sw.Dispose();
        }

        GC.Collect();
    }
}