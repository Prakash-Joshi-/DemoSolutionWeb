using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Amazon;
using Amazon.S3.Model;
using System.IO;
using Amazon.S3;
using System.Diagnostics;

namespace AmazonServicesWebForm
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("Debug");
            String _ItemImageName = string.Empty;
            String _ItemImagePath = String.Empty;
            String _GroupCode = string.Empty;
            int _entityId = 0, _imageType = 0;
            string _key = string.Empty;
            //_ItemImageName = "brj80" + "-superenlarge";
            //_ItemImagePath = "/BRJ/brj80/".ToLower().TrimStart('/');
            //_GroupCode = "brj80";

            _ItemImageName = "UPC16".ToLower() + "-superenlarge";
            _ItemImagePath = "/SNEA/snea86/".ToLower().TrimStart('/');
            _GroupCode = "UPC16";

            _entityId = 1;
            _imageType = 0;
            if (_imageType > 0)
            {
                _key = _ItemImagePath + _ItemImageName + _imageType + ".jpg";
            }
            else
            {
                _key = _ItemImagePath + _ItemImageName + ".jpg";

            }
            _key = "/jwr/jwr8494/-superenlarge.jpg";
            _GroupCode = "JWR8494";
            _entityId = 63869;
            _ItemImageName = "jwr8494-superenlarge";
            _imageType = 0;
            _saveBase64Code(_key, _GroupCode, _entityId, _ItemImageName, _imageType, "");
        }

        private void _saveBase64Code(string Key, String _GroupCode, int _entityId, string _ItemImageName, int _ImageType, string _imageUpdate)
        {
            GetObjectRequest request = new GetObjectRequest();
            String _Bucket = "www.utsavsarees.org";
            request = new GetObjectRequest().WithBucketName(_Bucket).WithKey(Key);
            AmazonS3 s3Client = AWSClientFactory.CreateAmazonS3Client(AWSKeys.AWSAccessKey, AWSKeys.AWSSecretKey);
            byte[] imageArray = new byte[0];
            string base64ImageRepresentation = "";
            using (s3Client)
            {
                try
                {
                    using (GetObjectResponse response = s3Client.GetObject(request))
                    {
                        if (response.ContentLength > 25000)  // Greate than 25kb
                        {
                            imageArray = StreamToByteArray(response.ResponseStream);
                            if (imageArray != null & imageArray.Length > 0)
                            {
                                base64ImageRepresentation = Convert.ToBase64String(imageArray);
                                //using (StreamReader reader = new StreamReader(response.ResponseStream))
                                //{
                                //    string contents = reader.ReadToEnd();
                                //    //imageArray = contents;
                                //    Debug.WriteLine("Object - " + response.Key);
                                //    Debug.WriteLine(" Version Id - " + response.VersionId);
                                //    Debug.WriteLine(" Contents - " + contents);
                                //}
                                if (IsBase64String(base64ImageRepresentation))// If not exception is cought, then it is a base64 string
                                {
                                    DataSet ds = dal.InsertImageBase64Log(_GroupCode, _entityId, imageArray, _ImageType);
                                    if (ds != null && ds.Tables.Count > 0)
                                    {
                                        if (ds.Tables[0].Rows.Count > 0)
                                        {
                                            if (Convert.ToString(ds.Tables[0].Rows[0]["msg"]).ToLower() == "0")
                                            {
                                                dal.UpdateImageBase64Log(_GroupCode, _entityId, 6, _ImageType);
                                                if (_imageUpdate != "")
                                                {
                                                    //logger.Info("Update ImageBase64 ReadMsgToAws service  successfully Save: " + _GroupCode + _ImageType + "");
                                                    dal.UpdateImageStatus(_imageUpdate);
                                                }
                                                else
                                                {
                                                    //logger.Info("Insert ImageBase64 ReadMsgToAws service  successfully Save: " + _GroupCode + _ImageType + "");
                                                }
                                            }
                                            else
                                            {
                                                //logger.Info("ImageBase64 ReadMsgToAws service  Fail to save in db: " + _GroupCode + _ImageType + "");
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    //logger.Info("ImageBase64 ReadMsgToAws service  Fail to Read reason IsBase64String: " + _GroupCode + _ImageType + "");
                                    dal.UpdateImageBase64Log(_GroupCode, _entityId, 4, _ImageType);
                                }
                            }
                            else
                            {
                                //logger.Info("ImageBase64 ReadMsgToAws service  Fail Read reason imageArray null: " + _GroupCode + _ImageType + "");
                                dal.UpdateImageBase64Log(_GroupCode, _entityId, 4, _ImageType);
                            }
                            imageArray = null;
                        }
                        else
                        {
                            //logger.Info("ImageBase64 ReadMsgToAws service  lenght less than 25kb: " + _GroupCode + _ImageType + "");
                        }
                    }
                }
                catch (AmazonS3Exception ex)
                {
                    //logger.Error("ImageBase64 " + ex.StackTrace + " - " + ex.Message + _ItemImageName + "  |   " + Key);
                    dal.UpdateImageBase64Log(_GroupCode, _entityId, 5, _ImageType);
                    ReadMessagFromAwsAll();
                }
                catch (Exception ex)
                {

                }
            }
        }
        public static byte[] StreamToByteArray(Stream inputStream)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                inputStream.CopyTo(ms);
                return ms.ToArray();
            }
        }

    }
    public static class AWSKeys
    {
        public static string AWSAccessKey = "AKIAJMYZMTW6O7WEKEXA";
        public static string AWSSecretKey = "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";
    }

    public class MediaDal
    {
        public DataSet UpdateImageBase64Log(string group_code, int entity_id, int status, int imageType)
        {
            SQLConnection _connection = new SQLConnection();
            var Ds = new DataSet();
            // DataTable dt = new DataTable();
            try
            {
                if (!_connection.isConnected)
                {
                    _connection.ConnectMDM();
                    if (_connection.HasError()) { throw new UsfProcessException("Error in Connection: " + _connection.LastError); }
                }
                var _query = "update_encodeimage";
                var param = new SqlParameter[5];
                param[0] = new SqlParameter("@group_code", group_code);
                param[1] = new SqlParameter("@entity_id", entity_id);
                //param[2] = new SqlParameter("@hexstring", hexstring);
                param[3] = new SqlParameter("@status", status);
                param[4] = new SqlParameter("@image_Type", imageType);
                _connection.ExecuteProcedure(_query, "insert_encodeimage", ref Ds, ref param);
            }
            catch (UsfProcessException ex)
            {
                logger.Error("ImageBase64 " + ex.StackTrace + " - " + ex.Message);
            }
            catch (Exception ex)
            {
                logger.Error("ImageBase64 " + ex.StackTrace + " - " + ex.Message);
            }
            finally
            {
                if (_connection != null)
                {
                    _connection.Reset();
                    _connection = null;
                }
            }
            return Ds;
        }
    }
}