using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Josn_demo.App_Code.Helpers.Encoding;

namespace Josn_demo
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var email = Request.QueryString["email"];
            String MyURL = "http://www.mydomain.com/page.aspx?e=" + Server.UrlEncode("emailAddress@network.com");

            var bytes = Encoding.UTF8.GetBytes("emailAddress@network.com");
            MyURL = Convert.ToBase64String(bytes);

            var data = Convert.FromBase64String(MyURL);
            var str = Encoding.UTF8.GetString(data);

            var encode = EncodeBase64("vinod.yadav@utsavfashion.com");

            var decode = DecodeBase64(encode);

            email = EncodeBase64(email);
            Response.Write(email);

            Test1();
            Test2();


        }

        static void Test1()
        {
            string textEncoded = System.Text.Encoding.UTF8.EncodeBase64("test1...");
            System.Diagnostics.Debug.Assert(textEncoded == "dGVzdDEuLi4=");

            string textDecoded = System.Text.Encoding.UTF8.DecodeBase64(textEncoded);
            System.Diagnostics.Debug.Assert(textDecoded == "test1...");
        }

        static void Test2()
        {
            string textEncoded = System.Text.Encoding.UTF8.EncodeBase64(null);
            System.Diagnostics.Debug.Assert(textEncoded == null);

            string textDecoded = System.Text.Encoding.UTF8.DecodeBase64(textEncoded);
            System.Diagnostics.Debug.Assert(textDecoded == null);
        }



        // Encode
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        // Decode
        public static string Base64Decode(string base64EncodedData)
        {
            try
            {
                var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
                return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            }
            catch (Exception)
            {
                return null;
            }
        }







        public static string EncodeBase64( string text)
        {
            if (text == null)
            {
                return null;
            }

            byte[] textAsBytes = System.Text.Encoding.UTF8.GetBytes(text);
            return System.Convert.ToBase64String(textAsBytes);
        }

        public static string DecodeBase64( string encodedText)
        {
            if (encodedText == null)
            {
                return null;
            }

            byte[] textAsBytes = System.Convert.FromBase64String(encodedText);
            return System.Text.Encoding.UTF8.GetString(textAsBytes);
        }

        // The input is not a valid Base-64 string as it contains a non-base 64 character, more than two padding characters, or an illegal character among the padding characters
        public static bool TryParseBase64(string encodedText, out string decodedText)
        {
            if (encodedText == null)
            {
                decodedText = null;
                return false;
            }

            try
            {
                byte[] textAsBytes = System.Convert.FromBase64String(encodedText);
                decodedText = System.Text.Encoding.UTF8.GetString(textAsBytes);
                return true;
            }
            catch (Exception)
            {
                decodedText = null;
                return false;
            }
        }






        //public static string EncodeBase64(this System.Text.Encoding encoding, string text)
        //{
        //    if (text == null)
        //    {
        //        return null;
        //    }

        //    byte[] textAsBytes = encoding.GetBytes(text);
        //    return System.Convert.ToBase64String(textAsBytes);
        //}

        //public static string DecodeBase64(this System.Text.Encoding encoding, string encodedText)
        //{
        //    if (encodedText == null)
        //    {
        //        return null;
        //    }

        //    byte[] textAsBytes = System.Convert.FromBase64String(encodedText);
        //    return encoding.GetString(textAsBytes);
        //}

        //// The input is not a valid Base-64 string as it contains a non-base 64 character, more than two padding characters, or an illegal character among the padding characters
        //public static bool TryParseBase64(this System.Text.Encoding encoding, string encodedText, out string decodedText)
        //{
        //    if (encodedText == null)
        //    {
        //        decodedText = null;
        //        return false;
        //    }

        //    try
        //    {
        //        byte[] textAsBytes = System.Convert.FromBase64String(encodedText);
        //        decodedText = encoding.GetString(textAsBytes);
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        decodedText = null;
        //        return false;
        //    }
        //}
    }
}