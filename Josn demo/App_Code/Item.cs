using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Josn_demo.App_Code
{
    public class Item
    {
        public string itemcode { get; set; }
        public string webcid { get; set; }
        public List<WebItemWiseMeasurementValues> webItemWiseMeasurementValues { get; set; }
    }
    public class WebItemWiseMeasurementValues
    {
        public string field_name { get; set; }
        public string isRequired { get; set; }
        public string minValue { get; set; }
        public string maxValue { get; set; }
    }
}