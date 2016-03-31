using System.Collections.Generic;
using DataAccessLayer;

namespace WcfServices
{
    public class WebNodeService : IWebNodeService
    {
        public IList<Entities.Node> GetNodes()
        {
            return NodesDAL.Get();
        }
    }
}
