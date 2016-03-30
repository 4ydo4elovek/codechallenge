using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetNodes()
        {
            return Json(NodesClient.GetNodes());
        }

        public ActionResult GetShortestPath(int from, int to)
        {
            return Json(AlgorithmClient.GetShortestPath(from, to));
        }
    }
}
