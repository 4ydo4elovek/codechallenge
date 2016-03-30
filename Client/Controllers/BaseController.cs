using System.Web.Mvc;
using Client.NodeService;
using Client.AlgorithmClient;

namespace Client.Controllers
{
    public abstract class BaseController : Controller
    {
        protected ClientNodeServiceClient NodesClient = new ClientNodeServiceClient("BasicHttpBinding_IClientNodeService");

        protected AlgorithmServiceClient AlgorithmClient = new AlgorithmServiceClient("BasicHttpBinding_IAlgorithmService");
    }
}
