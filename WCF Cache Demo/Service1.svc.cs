using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;
using ServiceLayer;
namespace WCF_Cache_Demo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1 : IService1
    {
        public string GetData(string itemCode)
        {
            try
            {
                DataRepository dr = new DataRepository();
                return dr.GetStringData(itemCode);
                //return string.Format("You entered: {0}", value);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }


        public IEnumerable GetEmployee()
        {
            return new Employee().GetEmployee();
        }
    }
    public class DataRepository
    {
        public IEnumerable GetPizzas()
        {
            Thread.Sleep(10000);

            return new List<string>() { "Hawaii", "Pepperoni", "Bolognaise" };
        }
        public string GetStringData()
        {
            return "Caching in WCF Services NEW NEW:";
        }
        public string GetStringData(string itemCode)
        {
            switch (itemCode)
            {
                case "JVK425":
                    return "JVK425asdas";
                case "kgb2313":
                    return "kgb2313asda";
                default:
                    return "";
            }
        }
    }
}
