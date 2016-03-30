using System.Collections.Generic;
using System.ServiceModel;

namespace ServiceLayer
{
    [ServiceContract]
    public interface IAlgorithmService
    {
        [OperationContract]
        IList<int> GetShortestPath(int node1, int node2);
    }
}
