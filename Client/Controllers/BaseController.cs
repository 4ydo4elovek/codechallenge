using System.Web.Mvc;

namespace Client.Controllers
{
    public abstract class BaseController : Controller
    {
        protected WebNodeServiceClient.WebNodeServiceClient NodesClient = new WebNodeServiceClient.WebNodeServiceClient("BasicHttpBinding_IWebNodeService");

        protected AlgorithmServiceClient.AlgorithmServiceClient AlgorithmClient = new AlgorithmServiceClient.AlgorithmServiceClient("BasicHttpBinding_IAlgorithmService");
    }
}
