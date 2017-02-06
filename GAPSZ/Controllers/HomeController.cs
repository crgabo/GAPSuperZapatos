using System.Web.Mvc;

namespace ConsumeWebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Demo Application to apply for a job in Growth Acceleration Partners. This app shows how to interact between MVC and WebAPI (using RestSharp)";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Growth Acceleration Partners Super Zapatos.";

            return View();
        }
    }
}
