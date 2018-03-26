using System.Collections;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WCF_Cache_Demo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPizzaService" in both code and config file together.
    [ServiceContract]
    public interface IPizzaService
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "GetAvailablePizzas", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        IEnumerable GetAvailablePizzas();
    }
}
