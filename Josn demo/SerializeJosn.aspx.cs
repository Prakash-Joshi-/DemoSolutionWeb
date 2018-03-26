using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Josn_demo.App_Code;
using System.Net.Http;
using System.Configuration;
using System.Net.Http.Headers;

namespace Josn_demo
{
    public partial class SerializeJosn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["SourcefuseSaveWebItemMeasurement"]);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            HttpResponseMessage response = new HttpResponseMessage();

            // checking for itemcode existance in UDesign Web Item Wise Measurement
            response = client.GetAsync("ZETQ3er").Result;
            var result = response.Content.ReadAsStringAsync().Result;
            //var content = new StringContent(itemJson.ToString(), Encoding.UTF8, "application/json");
            SourceFuseResponse sfResponse = new SourceFuseResponse();
            sfResponse = JsonConvert.DeserializeObject<SourceFuseResponse>(result);

            //WebItemWiseMeasurementValue webItemWiseMeasurementValues = new WebItemWiseMeasurementValue();
            #region POST WebItemWiseMeasurementValue
            var postInput = @"{
                                 'itemcode' : 'ABC1234',
                                 'webcid' : 1,
                                 'webItemWiseMeasurementValues' : [
                                 {
                                       'field_name' : 'aroundbust',
                                       'isRequired' : 1,
                                       'minValue' : 28,
                                       'maxValue' : 66
                                 },{
                                      'field_name' : 'aroundabovewaist',
                                      'isRequired' : 1,
                                      'minValue' : 20,
                                      'maxValue' : 30
                                 }
                                 ]
                              }";
            Data postInput1 = JsonConvert.DeserializeObject<Data>(postInput);

            Data postInput2 = new Data();
            postInput2.itemcode = "ABC1234";
            postInput2.webcid = "1";
            WebItemWiseMeasurementValue value = new WebItemWiseMeasurementValue();
            value.field_name = "aroundbust";
            value.isRequired = "1";
            value.minValue = "28";
            value.maxValue = "66";
            List<WebItemWiseMeasurementValue> webItemWiseMeasurementValue = new List<WebItemWiseMeasurementValue>();
            webItemWiseMeasurementValue.Add(value);
            postInput2.webItemWiseMeasurementValues = webItemWiseMeasurementValue;

            var postInput3 = JsonConvert.SerializeObject(postInput2);
            postInput2 = new Data();
            postInput2 = JsonConvert.DeserializeObject<Data>(postInput3);

            var postOutput = @"{
                                    'status': true,
                                    'message': 'Measurement saved successfully',
                                    'data':    {
                                       'id': 304782,
                                       'itemcode': 'ABC1234',
                                       'webcid': 1
                                    }
                               }";
            SourceFuseResponse postOutput1 = JsonConvert.DeserializeObject<SourceFuseResponse>(postOutput);
            #endregion

            #region PUT WebItemWiseMeasurementValue
            var putInput = @"{
                                 'itemcode' : 'ABC1234',
                                 'webcid' : 2,
                                 'webItemWiseMeasurementValues' : [
                                 {
                                       'field_name' : 'aroundbust',
                                       'isRequired' : 1,
                                       'minValue' : 28,
                                       'maxValue' : 66
                                 },{
                                      'field_name' : 'aroundabovewaist',
                                      'isRequired' : 1,
                                      'minValue' : 20,
                                      'maxValue' : 30
                                 }
                                 ]
                              }";
            Data putInput1 = JsonConvert.DeserializeObject<Data>(putInput);

            var putOutput = @"{
                                   'status': true,
                                   'message': 'Measurement updated successfully',
                                   'data':    {
                                      'itemcode': 'ABC1234',
                                      'webcid': 2
                                   }
                              }";
            SourceFuseResponse putOutput1 = JsonConvert.DeserializeObject<SourceFuseResponse>(putOutput);
            #endregion

            #region DELETE WebItemWiseMeasurementValue
            var deleteOutput = @"{
                                   'status': true,
                                   'message': 'Web measurement deleted successfully'
                                }";
            SourceFuseResponse deleteOutput1 = JsonConvert.DeserializeObject<SourceFuseResponse>(deleteOutput);
            #endregion

            #region GET WebItemWiseMeasurementValue
            var getOutput =@"{
                              'status': true,
                              'message': 'Successfully Fetch webcategory Detail',
                              'data': [
                                {
                                  'id': 304884,
                                  'itemcode': 'TestCode23',
                                  'webcid': 1,
                                  'webItemWiseMeasurementValues': [
                                    {
                                      'field_name': 'aroundbust',
                                      'isRequired': true,
                                      'minValue': 28,
                                      'maxValue': 66
                                    },
                                    {
                                      'field_name': 'aroundabovewaist',
                                      'isRequired': true,
                                      'minValue': 20,
                                      'maxValue': 30
                                    }
                                  ]
                                }
                              ]
                            }";
            SourceFuseResponse getOutput1 = JsonConvert.DeserializeObject<SourceFuseResponse>(getOutput);

            var getOutput2 = @"{
                                  'status': false,
                                  'message': 'Invalid webmeasurement itemcode'
                                }";
            SourceFuseResponse getOutput3 = JsonConvert.DeserializeObject<SourceFuseResponse>(getOutput2);
            #endregion



            // http://stackoverflow.com/questions/6507889/how-to-ignore-a-property-in-class-if-null-using-json-net
            WebItemWiseMeasurementValues values = new WebItemWiseMeasurementValues();
            values.field_name = "aroundbust";
            values.isRequired = "";
            values.maxValue = "";
            values.minValue = "";
            List<WebItemWiseMeasurementValues> webItemWiseMeasurementValues = new List<WebItemWiseMeasurementValues>();
            webItemWiseMeasurementValues.Add(values);
            Item item = new Item();
            item.itemcode = "";
            item.webcid = "";
            if (webItemWiseMeasurementValues != null)
                item.webItemWiseMeasurementValues = webItemWiseMeasurementValues;


            string itemJson = new JavaScriptSerializer().Serialize(item);

            values = new WebItemWiseMeasurementValues();
            item = new Item();
            values.field_name = "aroundbust";
            values.isRequired = null;
            values.maxValue = null;
            values.minValue = null;
            item.itemcode = "";
            item.webcid = "";
            itemJson = new JavaScriptSerializer().Serialize(item);
            //http://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_NullValueHandling.htm
            itemJson = JsonConvert.SerializeObject(item, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            JsonSerializer _jsonWriter = new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore
            };


            item = new Item();
            item.itemcode = "";
            item.webcid = "";
            itemJson = new JavaScriptSerializer().Serialize(item);

            itemJson = JsonConvert.SerializeObject(item, Newtonsoft.Json.Formatting.None,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore
                            });

        }
    }

    //public class Item
    //{
    //    public string itemcode { get; set; }
    //    public string webcid { get; set; }
    //    public List<WebItemWiseMeasurementValues> webItemWiseMeasurementValues { get; set; }
    //}
    //public class WebItemWiseMeasurementValues
    //{
    //    public string field_name { get; set; }
    //    public string isRequired { get; set; }
    //    public string minValue { get; set; }
    //    public string maxValue { get; set; }
    //}
    // http://www.newtonsoft.com/json/help/html/JsonPropertyPropertyLevelSetting.htm
}