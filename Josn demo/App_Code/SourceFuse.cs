using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Josn_demo.App_Code
{
    public class WebItemWiseMeasurementValue
    {
        public string field_name { get; set; }
        public string isRequired { get; set; }
        public string minValue { get; set; }
        public string maxValue { get; set; }
    }

    public class Data
    {
        public string id { get; set; }
        public string itemcode { get; set; }
        public string webcid { get; set; }
        public List<WebItemWiseMeasurementValue> webItemWiseMeasurementValues { get; set; }
    }

    public class SourceFuseResponse
    {
        public SourceFuseResponse()
        {
            data = new Data();
        }
        public bool status { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }
}