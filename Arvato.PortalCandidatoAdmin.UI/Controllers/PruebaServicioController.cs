using Arvato.PortalCandidato.UI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;


namespace Arvato.PortalCandidatoAdmin.UI.Controllers
{
    [Authorize]
    public class PruebaServicioController : Controller
    {
        // GET: PruebaServicio

        CandidateService _serviceCandidate;

        public PruebaServicioController()
        {
            _serviceCandidate = new CandidateService();
        }

        public ActionResult Index()
        {
            if (!(User.Identity.GetUsuarioNT().Equals("jpvicente")))
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.error = TempData["error"];
            return View();
        }

        public async Task<string> Correo()
        {
            if (!(User.Identity.GetUsuarioNT().Equals("jpvicente")))
            {
                return "Su usuario no tiene permisos para ejecutar esta acción";
            }

            return await _serviceCandidate.envioDeEmail();


        }

        public async Task<string> Delete()
        {

            string pathCv = System.Configuration.ConfigurationManager.AppSettings["pathCv"];
            if (!(User.Identity.GetUsuarioNT().Equals("jpvicente")))
            {
                return "Su usuario no tiene permisos para ejecutar esta acción";
            }
            return String.Format("Han sido eliminados {0} candidatos", (await _serviceCandidate.DeleteCandidate2yaersOld()).Count());


        }



    }
}