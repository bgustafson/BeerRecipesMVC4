using System.Web.Mvc;

namespace ShipCompliantMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Beerclopedia, where real homebrewers get their answers.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Beerclopedia is a dictionary of user submitted beer recipes and other information related to homebrewing.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Beerclopedia to get more information on contributing or marketing opportunities.";

            return View();
        }
    }
}
