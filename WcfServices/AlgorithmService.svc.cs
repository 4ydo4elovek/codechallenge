using System.Linq;
using DataAccessLayer;

namespace WcfServices
{
    public class AlgorithmService : IAlgorithmService
    {
        public Result GetShortestPath(int node1, int node2)
        {
            var nodes = NodesDAL.Get();

            var maxId = nodes.Max(i => i.Id);
            var arr = new int[maxId, maxId];
            foreach (var node in nodes)
            {
                foreach (var line in node.Lines)
                {
                    if (line.NodeIdFrom != line.NodeIdTo)
                        arr[line.NodeIdTo - 1, line.NodeIdFrom - 1] = arr[line.NodeIdFrom - 1, line.NodeIdTo - 1] = 1;
                }
            }

            var algo = new DijkstrasAlgorithm.DijkstrasAlgorithm(arr);

            var res = new Result();
            int length = 0;

            res.Nodes = algo.GetShortestPath(node1, node2, out length);

            res.Length = length != int.MaxValue ? length : -1;

            return res;
        }
    }
}
