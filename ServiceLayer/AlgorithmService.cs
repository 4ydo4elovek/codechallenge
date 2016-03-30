using System.Collections.Generic;
using DataAccessLayer;

namespace ServiceLayer
{
    public class AlgorithmService : IAlgorithmService
    {
        public IList<int> GetShortestPath(int node1, int node2)
        {
            var nodes = NodesDAL.Get();

            var arr = new int[nodes.Count, nodes.Count];
            foreach (var node in nodes)
            {
                foreach (var line in node.Lines)
                {
                    if (line.NodeIdFrom != line.NodeIdTo)
                        arr[line.NodeIdTo - 1, line.NodeIdFrom - 1] = arr[line.NodeIdFrom - 1, line.NodeIdTo- 1] = 1;
                }
            }

            var algo = new DijkstrasAlgorithm.DijkstrasAlgorithm(arr);

            var path = algo.GetShortestPath(node1, node2);
            return path;
        }
    }
}
