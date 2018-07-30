using Arvato.PortalCandidatoAdmin.UI.Attributes;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace Arvato.PortalCandidatoAdmin.UI.Controllers
{
    [Authorize]
    [SessionTimeout]
    public class HomeController : Controller
    {

        public HomeController()
        {

        }

        public ActionResult Index()
        {
            var personPK = User.Identity.GetPersonPK();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}