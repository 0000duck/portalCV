using Arvato.PortalCandadato.Shared.DTO;
using Arvato.PortalCandidato.UI.Service;
using ServiceLogin.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Arvato.PortalCandidatoAdmin.UI.Controllers
{
    [Authorize]
    public class CandidateController : Controller
    {

        CandidateService _serviceCandidate;
        RegionService _serviceRegion;
        CvFileService _serviceCV;
        UsuarioDTO usuario;
        public CandidateController()
        {
           _serviceCandidate = new CandidateService();
            _serviceRegion = new RegionService();
            _serviceCV = new CvFileService();
        }
        // GET: Candidate
        public async Task<ActionResult> Index()
        {
          
            if (!(User.Identity.GetEsAdmin() || User.Identity.GetEsTecnico()))
            {
                TempData["permisos"] = "No tienes permisos para acceder.";
                return RedirectToAction("Login", "Account");
            }


                var candidatos =  await _serviceCandidate.Get();
                var listaRegiones = await _serviceRegion.Get();
        
                List<CandidateDTO> lCandidatos = new List<CandidateDTO>();

            if (candidatos != null)
            {
                foreach (var c in candidatos)
                {
                    var regiones = c.RegionsIds.Split(',');
                    List<string> ListaStrRegion=new List<string>();
                    
                    foreach (var r in regiones)
                    {
                        var regi = listaRegiones.Where(region => region.Id.ToString() == r).FirstOrDefault();
                        ListaStrRegion.Add(regi.RegionName);
                    }
                    c.RegionsIds = string.Join(", " ,ListaStrRegion);
                    if (!c.IsDelete) { lCandidatos.Add(c); };
                }
            }
                //////////////

                List<SelectListItem> listaRegion = new List<SelectListItem>();
          
                    foreach (var item in listaRegiones)
                    {
                        var selecItem = new SelectListItem();
                        selecItem.Text = item.RegionName;
                        selecItem.Value = item.Id.ToString();
                        listaRegion.Add(selecItem);
                    }
                    ViewBag.regiones = listaRegion;
            ViewBag.error = TempData["error"];
                //////////////
                //return RedirectToAction("Index", "PruebaServicio");
            return View(lCandidatos);

         
        }

        public async Task<ActionResult> Delete(int id)
        {

            if (!(User.Identity.GetEsAdmin() || User.Identity.GetEsTecnico()))
            {
                TempData["permisos"] = Resources.Language.no_permisos;
                return RedirectToAction("Login", "Account");
            }

            var candidato = (await _serviceCandidate.Get(id));

            // lo borro de forma logica:
            candidato.IsDelete = true;
            candidato.TimeDelete = DateTime.Now;

            var res = await _serviceCandidate.Update(candidato);
            if (!res)
            {
                TempData["error"] =Resources.Language.error_datos;

            }

            return RedirectToAction("Index");

        }

        public async Task<FileResult> Descarga(int id)
        {

            if (!(User.Identity.GetEsAdmin() || User.Identity.GetEsTecnico()))
            {

                return null;// RedirectToAction("Login", "Account");
            }
            string texto;
            // comprobar si está borrado
            var candidato = (await _serviceCandidate.Get(id));
            if (candidato.IsDelete)
            {
                texto = "Registro de candidato eliminado";
                return File(Encoding.ASCII.GetBytes(texto), "text/plain", "error.txt");
            }

            // Registrar que ha sido leido
            candidato.User = User.Identity.GetUsuarioNT();
            candidato.IsRead = true;
            candidato.TimeRead = DateTime.Now;
            _serviceCandidate.Update(candidato);


           // return _serviceCV.getFtpFile(candidato.PathCV);


            var archivoNombre = candidato.PathCV.Split('.');
            var extension = archivoNombre[archivoNombre.Length - 1];

            string pathCv = System.Configuration.ConfigurationManager.AppSettings["pathCv"];

            //comprobamos que elarchivo existe

            if (System.IO.File.Exists(pathCv + candidato.PathCV.Replace(extension, "pdf")))
            {

                //if(extension=="doc" || extension == "docx")
                //{
                //    return File(pathCv + candidato.PathCV, "application/msword");
                //}
                //if (extension == "pdf" )
                //{
                return File(pathCv + candidato.PathCV.Replace(extension, "pdf"), "application/pdf");
                //}
                //if (extension == "txt")
                //{
                //    return File(pathCv + candidato.PathCV, "text/plain");
                //}

            }
            else {
                texto = "Archivo con extension No váilda";
                return File(Encoding.ASCII.GetBytes(texto), "text/plain", "error.txt");
            }
        }


       
    }

}
