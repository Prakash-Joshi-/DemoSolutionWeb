using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF_Demo_WebForms
{
    public class Order
    {

        public string OrderID { get; set; }


        public string OrderDate { get; set; }


        public string ShippedDate { get; set; }


        public string ShipCountry { get; set; }


        public string OrderTotal { get; set; }
    }
}