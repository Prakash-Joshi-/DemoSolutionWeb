using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Josn_demo.App_Code.Helpers.Encoding
{
    public static class EncodingForBase64
    {
        public static string EncodeBase64(this System.Text.Encoding encoding, string text)
        {
            if (text == null)
            {
                return null;
            }

            byte[] textAsBytes = encoding.GetBytes(text);
            return System.Convert.ToBase64String(textAsBytes);
        }

        public static string DecodeBase64(this System.Text.Encoding encoding, string encodedText)
        {
            if (encodedText == null)
            {
                return null;
            }

            byte[] textAsBytes = System.Convert.FromBase64String(encodedText);
            return encoding.GetString(textAsBytes);
        }


        public static bool TryParseBase64(this System.Text.Encoding encoding, string encodedText, out string decodedText)
        {
            if (encodedText == null)
            {
                decodedText = null;
                return false;
            }

            try
            {
                byte[] textAsBytes = Convert.FromBase64String(encodedText);
                decodedText = encoding.GetString(textAsBytes);
                return true;
            }
            catch (Exception)
            {
                decodedText = null;
                return false;
            }
        }

    }
}