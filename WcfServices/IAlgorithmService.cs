using System.ServiceModel;

namespace WcfServices
{
    [ServiceContract]
    public interface IAlgorithmService
    {
        [OperationContract]
        Result GetShortestPath(int node1, int node2);
    }
}
