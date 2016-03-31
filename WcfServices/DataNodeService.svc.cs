using System.Collections.Generic;
using DataAccessLayer;

namespace WcfServices
{
    public class DataNodeService : IDataNodeService
    {
        public void SaveNodes(IList<Entities.Node> nodes)
        {
            foreach (var node in nodes)
            {
                node.Id = NodesDAL.AddOrUpdate(node);
            }
            foreach (var node in nodes)
            {
                foreach (var line in node.Lines)
                {
                    line.NodeIdFrom = node.Id;
                    line.NodeIdTo = NodesDAL.Get(line.NodeIdToUnique).Id;
                    LinesDAL.AddOrUpdate(line);
                }
            }
        }
    }
}
