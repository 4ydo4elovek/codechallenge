using System.Collections.Generic;
using System.ServiceModel;
using Entities;

namespace ServiceLayer
{
    [ServiceContract]
    public interface IDataNodeService
    {
        [OperationContract]
        void SaveNodes(IList<Node> nodes);
    }
}
