using System.Collections.Generic;
using System.ServiceModel;

namespace WcfServices
{
    [ServiceContract]
    public interface IWebNodeService
    {
        [OperationContract]
        IList<Entities.Node> GetNodes();
    }
}
