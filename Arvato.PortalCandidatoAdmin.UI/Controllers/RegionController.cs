using Arvato.PortalCandadato.Shared.DTO;
using Arvato.PortalCandidato.UI.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Arvato.PortalCandidatoAdmin.UI.Controllers
{
    [Authorize]
    public class RegionController : Controller
    {

        RegionService _serviceRegion;
        public RegionController()
        {
            _serviceRegion = new RegionService();
        }

        // GET: Region
        public async Task<ActionResult> Index()
        {
            if (!(User.Identity.GetEsAdmin()) || User.Identity.GetUsuarioNT() == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View(await _serviceRegion.Get());
        }

        public async Task<ActionResult> Edit(int id)
        {
            if (!(User.Identity.GetEsAdmin()) || User.Identity.GetUsuarioNT()==null)
            {
                return RedirectToAction("Login", "Account");
            }
            var region = (await _serviceRegion.Get()).Where(x => x.Id == id).FirstOrDefault();

            return View(region);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(RegionDTO region)
        {


            if (!(User.Identity.GetEsAdmin()))
            {
                return RedirectToAction("Login", "Account");
            }
            region.User = User.Identity.GetUsuarioNT(); ;
            if (!ModelState.IsValid)
            {
                ViewBag.error = "Revise los campos";
                return View(region);
            }
            var res = await _serviceRegion.Update(region);
           if (!res)
            {
                ViewBag.error = "Error al actualizar los datos, Vuelva a intentarlos";

                return View(region);
            }
            
            return RedirectToAction("Index");
           
        }

    }

}