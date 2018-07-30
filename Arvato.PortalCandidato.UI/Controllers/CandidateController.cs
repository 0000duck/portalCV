using Arvato.PortalCandadato.Shared.DTO;
using Arvato.PortalCandidato.UI.Service;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Office.Interop.Word;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;

namespace Arvato.PortalCandidato.UI.Controllers
{
    
    public class CandidateController : Controller
    {

        CandidateService _serviceCandidate;
        RegionService _serviceRegion;
        CvFileService _serviceFile;

        public CandidateController()
        {
            _serviceCandidate = new CandidateService();
            _serviceRegion = new RegionService();
            _serviceFile = new CvFileService();
        }



        // GET: Candidate
        public async Task<ActionResult> Create(string Idioma)
        {
            // tengo que enviar el combo de las regiones:
            var regiones = await _serviceRegion.Get();
            List<SelectListItem> listaRegion = new List<SelectListItem>();
            foreach (var item in regiones)
            {
                listaRegion.Add(
                    new SelectListItem()
                    {
                        Text = item.RegionName,
                        Value = item.Id.ToString()
                    });
            }
            ViewBag.idiomaSelecionado = Idioma == null ? "es-ES" : Idioma;

            ViewBag.idiomas = new List<SelectListItem>(){
                new SelectListItem(){Text="Español",Value="es-ES",Selected=Idioma=="es-ES"},
                new SelectListItem(){Text="English",Value="en-GB",Selected=Idioma=="en-GB"}
            };

            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(ViewBag.idiomaSelecionado);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(ViewBag.idiomaSelecionado);
            ViewBag.Title = "Portal Candidato";
            ViewBag.regiones = listaRegion;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateIdioma(string Idioma)
        {
            // tengo que enviar el combo de las regiones:
            var regiones = await _serviceRegion.Get();
            List<SelectListItem> listaRegion = new List<SelectListItem>();
            foreach (var item in regiones)
            {
                listaRegion.Add(
                    new SelectListItem()
                    {
                        Text = item.RegionName,
                        Value = item.Id.ToString()
                    });
            }

            ViewBag.idiomaSelecionado = Idioma == null ? "es-ES" : Idioma;

            ViewBag.idiomas = new List<SelectListItem>(){
                new SelectListItem(){Text="Español",Value="es-ES",Selected=Idioma=="es-ES"},
                new SelectListItem(){Text="English",Value="en-GB",Selected=Idioma=="en-GB"}
            };

            ViewBag.Title = "Portal Candidato";
            ViewBag.regiones = listaRegion;
            return RedirectToAction("Create", new { Idioma = Idioma });
        }

        // POST: Default/Create
        [HttpPost]
        //public async Task<ActionResult> Create(CandidateDTO candiadato , string Idioma)
        public async Task<string> Create(CandidateDTO candidato, string Idioma)

        {
            // capche google
            var response = HttpContext.Request.Form["g-recaptcha-response"];
                string secretKey = "6LdhDmMUAAAAAOX9iW9kD9JbUIUqh-Ze68wxMwM1";
                var client = new WebClient();
                // get captcha verification result
                var verificationResultJson = client.DownloadString(string.Format
                    ("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}",
                        secretKey, response));
                // convert json to object
                var verificationResult  = JsonConvert.DeserializeObject<ResponseCaptcha>(verificationResultJson);
                // process verification result
                if (!verificationResult.success)
                {

                    return "KO";
                }

     /*
        // Los idiomas
            ViewBag.idiomaSelecionado = Idioma == null ? "es-ES" : Idioma;
            ViewBag.idiomas = new List<SelectListItem>(){
                new SelectListItem(){Text="Español",Value="es-ES",Selected=Idioma=="es-ES"},
                new SelectListItem(){Text="English",Value="en-GB",Selected=Idioma=="en-GB"}
            };
     
            // tengo que enviar el combo de las regiones:
            var regiones = await _serviceRegion.Get();
            List<SelectListItem> listaRegion = new List<SelectListItem>();
            foreach (var item in regiones)
            {
                listaRegion.Add(
                    new SelectListItem()
                    {
                        Text = item.RegionName,
                        Value = item.Id.ToString()
                    });
            }
            ViewBag.Title = "Portal Candidato";
            ViewBag.regiones = listaRegion;
     */
            // para recoger el archivo
            var file = Request.Files["archivo"];
            var fileName = file.FileName.Split('\\');
            var nombre = fileName[fileName.Length - 1];
            candidato.PathCV = fileName[fileName.Length - 1];
            string value = System.Configuration.ConfigurationManager.AppSettings["tiposPermitidos"];
            string pathCv = System.Configuration.ConfigurationManager.AppSettings["pathCv"];




            var tiposPermitidos = value.Split(';');
            var extension = Path.GetExtension(file.FileName);
            if (!tiposPermitidos.Contains(extension))
            {
                return "KO";
            }
            var fecha = DateTime.Now;
            var nombreCV = candidato.Email + "_" + fecha.ToString("yyyyMMddhhmmss") + fecha.Millisecond.ToString();
            //string pathServer = Path.Combine(Server.MapPath("~/Repositorio/"), nombreCV + extension);
            string pathServer = pathCv + nombre;




            // configuramos el candidato
            candidato.RegionsIds = Request.Form["Regiones"];
            candidato.PathCV = nombreCV + extension;
            candidato.TimeIn = fecha;
            candidato.User = "WEB";

            try
            {   //Copio en el servidor con el nombre original
                file.SaveAs(pathServer);

                if (extension == ".doc" || extension == ".docx")
                {
                    Application word = new Application();
                    Document doc = word.Documents.Open(pathServer);
                    doc.Activate();
                    doc.SaveAs2(pathCv + nombreCV+".pdf", WdSaveFormat.wdFormatPDF);
                    doc.Close();


                }
                // si ya es PDF
                else {
                    //Ruta de donde lo dejo
                    file.SaveAs(pathCv+nombreCV + extension);
                }
                //Solo se guarda como pdf
                _serviceFile.moveFileToFtp(pathCv + nombreCV+ ".pdf");

               if(await _serviceCandidate.Insert(candidato))
                {
                // return RedirectToAction("Create");
                return "OK";
                }
                return "KO";

            }
            catch (Exception e)
            {
                // Delete the file after uploading
                if (System.IO.File.Exists(pathCv + extension))
                {
                    System.IO.File.Delete(pathCv + extension);
                }
                //ViewBag.error = "Se ha producido un error al guardar los datos. Vuelva a intentarlo";
                return "KO excepcion";
            }
            finally
            {
                // lo elimino del
                System.IO.File.Delete(pathServer);
            }

        }
    }

    public class ResponseCaptcha
    {
      public  bool success;
      public DateTime challenge_ts;
      public string hostname;
    }
}