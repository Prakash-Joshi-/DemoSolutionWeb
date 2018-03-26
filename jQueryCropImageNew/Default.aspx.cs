using System;
using System.Drawing;
using System.IO;
using Image = System.Drawing.Image;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Linq;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btncrop_Click(object sender, EventArgs e)
    {
        try
        {
            string fname = "slsl.jpg";
            string fpath = Path.Combine(Server.MapPath("~/images"), fname).ToString();
            Bitmap mBitmap = (Bitmap)Image.FromFile(fpath);
            //Bitmap mBitmap = (Bitmap)Image.FromFile("~/images/Tulips.jpg");
            //Bitmap mBitmap;
            //using (Stream BitmapStream = System.IO.File.Open("tulips.jpg", System.IO.FileMode.Open))
            //{
            //    Image img = Image.FromStream(BitmapStream);

            //    mBitmap = new Bitmap(img);
            //    //...do whatever
            //}
            
            
            
            Image oimg = Image.FromFile(fpath);
            string savePath = Path.Combine(Server.MapPath("~/cropimages"), fname).ToString();
            ImageHandler im = new ImageHandler();
            im.Save(mBitmap, 170, 246, 50, savePath);
            Rectangle cropcords = new Rectangle(
            Convert.ToInt32(hdnx.Value),
            Convert.ToInt32(hdny.Value),
            Convert.ToInt32(hdnw.Value),
            Convert.ToInt32(hdnh.Value));
            string cfname, cfpath;
            Bitmap bitMap = new Bitmap(cropcords.Width, cropcords.Height, oimg.PixelFormat);
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
    public class ImageHandler
    {
        /// <summary>
        /// Method to resize, convert and save the image.
        /// </summary>
        /// <param name="image">Bitmap image.</param>
        /// <param name="maxWidth">resize width.</param>
        /// <param name="maxHeight">resize height.</param>
        /// <param name="quality">quality setting value.</param>
        /// <param name="filePath">file path.</param>      
        public void Save(Bitmap image, int maxWidth, int maxHeight, int quality, string filePath)
        {
            // Get the image's original width and height
            int originalWidth = image.Width;
            int originalHeight = image.Height;

            // To preserve the aspect ratio
            float ratioX = (float)maxWidth / (float)originalWidth;
            float ratioY = (float)maxHeight / (float)originalHeight;
            float ratio = Math.Min(ratioX, ratioY);

            // New width and height based on aspect ratio
            int newWidth = (int)(originalWidth * ratio);
            int newHeight = (int)(originalHeight * ratio);

            // Convert other formats (including CMYK) to RGB.
            Bitmap newImage = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);

            // Draws the image in the specified size with quality mode set to HighQuality
            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            // Get an ImageCodecInfo object that represents the JPEG codec.
            ImageCodecInfo imageCodecInfo = this.GetEncoderInfo(ImageFormat.Jpeg);

            // Create an Encoder object for the Quality parameter.
            Encoder encoder = Encoder.Quality;

            // Create an EncoderParameters object. 
            EncoderParameters encoderParameters = new EncoderParameters(1);

            // Save the image as a JPEG file with quality level.
            EncoderParameter encoderParameter = new EncoderParameter(encoder, quality);
            encoderParameters.Param[0] = encoderParameter;
            newImage.Save(filePath, imageCodecInfo, encoderParameters);
        }

        /// <summary>
        /// Method to get encoder infor for given image format.
        /// </summary>
        /// <param name="format">Image format</param>
        /// <returns>image codec info.</returns>
        private ImageCodecInfo GetEncoderInfo(ImageFormat format)
        {
            return ImageCodecInfo.GetImageDecoders().SingleOrDefault(c => c.FormatID == format.Guid);
        }
    }
}
