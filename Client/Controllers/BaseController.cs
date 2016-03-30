using System.Web.Mvc;
using Client.ClientNodeService;
using Client.AlgorithmClient;

namespace Client.Controllers
{
    public abstract class BaseController : Controller
    {
        protected ClientNodeServiceClient NodesClient = new ClientNodeServiceClient("BasicHttpBinding_IClientNodeService");

        protected AlgorithmServiceClient AlgorithmClient = new AlgorithmServiceClient("BasicHttpBinding_IAlgorithmService");
    }
}
