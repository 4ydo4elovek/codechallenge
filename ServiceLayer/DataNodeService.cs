using System.Collections.Generic;
using DataAccessLayer;

namespace ServiceLayer
{
    public class DataNodeService : IDataNodeService
    {
        public void SaveNodes(IList<Entities.Node> nodes)
        {
            foreach (var node in nodes)
            {
                NodesDAL.AddOrUpdate(node);
            }
            foreach (var node in nodes)
            {
                foreach (var line in node.Lines)
                {
                    LinesDAL.AddOrUpdate(line);
                }
            }
        }
    }
}
