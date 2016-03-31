using System.Collections.Generic;
using System.ServiceModel;
using Entities;

namespace WcfServices
{
    [ServiceContract]
    public interface IDataNodeService
    {
        [OperationContract]
        void SaveNodes(IList<Node> nodes);
    }
}
