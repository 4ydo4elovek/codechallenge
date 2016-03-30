using System.Collections.Generic;
using DataAccessLayer;

namespace ServiceLayer
{
    public class ClientNodeService : IClientNodeService
    {
        public IList<Entities.Node> GetNodes()
        {
            return NodesDAL.Get();
        }
    }
}
