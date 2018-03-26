Imports System.Drawing
Imports System.IO
Imports Image = System.Drawing.Image
Partial Class vbcode
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    End Sub
    Protected Sub btncrop_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim fname As String = "pool.jpg"
            Dim fpath As String = Path.Combine(Server.MapPath("~/images"), fname)
            Dim oimg As Image = Image.FromFile(fpath)
            Dim cropcords As New Rectangle(Convert.ToInt32(hdnx.Value), Convert.ToInt32(hdny.Value), Convert.ToInt32(hdnw.Value), Convert.ToInt32(hdnh.Value))
            Dim cfname As String, cfpath As String
            Dim bitMap As New Bitmap(cropcords.Width, cropcords.Height, oimg.PixelFormat)
            Dim grph As Graphics = Graphics.FromImage(bitMap)
            grph.DrawImage(oimg, New Rectangle(0, 0, bitMap.Width, bitMap.Height), cropcords, GraphicsUnit.Pixel)
            cfname = "crop_" & fname
            cfpath = Path.Combine(Server.MapPath("~/cropimages"), cfname)
            bitMap.Save(cfpath)
            imgcropped.Visible = True
            imgcropped.Src = "~/cropimages/" & cfname
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
