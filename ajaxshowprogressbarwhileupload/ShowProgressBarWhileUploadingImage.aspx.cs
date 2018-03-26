using System;
using System.IO;

public partial class ShowProgressBarWhileUploadingImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string fileName = Path.GetFileName(uploadfiles1.FileName);
        uploadfiles1.SaveAs(Server.MapPath("~/uploads/") + fileName);
        lblMsg.Text = "File Uploaded Successfully";
        System.Threading.Thread.Sleep(2000);
    }
}