using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiDemo.Controllers
{
    public class PDFController : ApiController
    {
        public string GetPdfBase64String()
        {
            Byte[] PdfAsByte = File.ReadAllBytes(@"E:\test.pdf");

            return Convert.ToBase64String(PdfAsByte);
        }
        public HttpResponseMessage GetBookForHRM()
        {
            byte[] dataBytes = Convert.FromBase64String(GetPdfBase64String());
            //converting Pdf file into bytes array  
            //var dataBytes = File.ReadAllBytes(@"E:\test.pdf");
            //adding bytes to memory stream   
            var dataStream = new MemoryStream(dataBytes);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(dataStream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "bk1.pdf";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;
        }
    }
}
