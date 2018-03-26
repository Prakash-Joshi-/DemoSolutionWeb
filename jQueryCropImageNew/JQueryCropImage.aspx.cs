using System;
using System.Drawing;
using System.IO;
using Image = System.Drawing.Image;

public partial class JQueryCropImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btncrop_Click(object sender, EventArgs e)
    {
        Rectangle cropcords = new Rectangle();
        Image oimg;
        Bitmap bitMap;
        int a1 = Convert.ToInt32(x1.Value);
        int a = Convert.ToInt32(hdnx.Value);
        try
        {
            string fname = "tulips.jpg";
            string fpath = Path.Combine(Server.MapPath("~/images"), fname).ToString();
            oimg = Image.FromFile(fpath);
            cropcords = new Rectangle(
            Convert.ToInt32(hdnx.Value),
            Convert.ToInt32(hdny.Value),
            Convert.ToInt32(hdnw.Value),
            Convert.ToInt32(hdnh.Value));
            string cfname, cfpath;
            bitMap = new Bitmap(cropcords.Width, cropcords.Height, oimg.PixelFormat);
            Graphics grph = Graphics.FromImage(bitMap);
            grph.DrawImage(oimg, new Rectangle(0, 0, bitMap.Width, bitMap.Height), cropcords, GraphicsUnit.Pixel);
            cfname = "crop_" + fname;
            cfpath = Path.Combine(Server.MapPath("~/cropimages"), cfname);
            bitMap.Save(cfpath);
            imgcropped.Visible = true;
            imgcropped.Src = "~/cropimages/" + cfname;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}