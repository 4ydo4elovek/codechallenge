using System.Linq;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class HomeController : BaseController
    {
        private static WebNodeServiceClient.Node[] Nodes;

        public ActionResult Index()
        {
            Nodes = NodesClient.GetNodes();
            return View();
        }

        public ActionResult GetNodes()
        {
            return Json(Nodes);
        }

        public ActionResult GetShortestPath(int from, int to)
        {
            var res = AlgorithmClient.GetShortestPath(from, to);
            return Json(new 
            {
                length = res.Length,
                nodes = res.Nodes.Select(n => Nodes.FirstOrDefault(item => item.Idk__BackingField == n)).ToArray()
            }
        );
        }
    }
}
