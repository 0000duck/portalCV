using Arvato.PortalCandidatoAdmin.UI.analytics;
using Arvato.PortalCandidatoAdmin.UI.Models;
using Microsoft.AspNet.Identity;
using ServiceLogin;
using ServiceLogin.Authentication;
using ServiceLogin.Dto;
using ServiceLogin.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Arvato.PortalCandidatoAdmin.UI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly DomainService _domainService;
        private readonly UsuarioService _usuarioService;
       

        public AccountController()
        {
            _domainService = new DomainService();
            _usuarioService = new UsuarioService();

        }

        
        // GET: Domains
        [AllowAnonymous]
        public ActionResult Login()
        {
                ViewBag.Visible = false;
            ViewBag.domains = GetListDomains().ToList()
                .Select(t => new { id = t.Value, text = t.Text })
                .ToList();

            List<SelectListItem> idiomas = new List<SelectListItem>();

            idiomas.Add(
                new SelectListItem { Text = "Castellano", Value = "es-ES" }

                );
            idiomas.Add(
                new SelectListItem { Text = "English", Value = "en-GB" }
                );


            ViewBag.idiomas = idiomas;
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl, bool? Suplantar)
        {

            List<SelectListItem> idiomas = new List<SelectListItem>();
            List<DomainDto> lista = new List<DomainDto>();

            idiomas.Add(
                new SelectListItem { Text = "Castellano", Value = "es-ES" }

                );
            idiomas.Add(
                new SelectListItem { Text = "English", Value = "en-GB" }
                );


            ViewBag.idiomas = idiomas;



            if (!ModelState.IsValid)
            {
                ViewBag.Visible = false;
                ViewBag.domains = GetListDomains().ToList()
                  .Select(t => new
                  {
                      id = t.Value,
                      text = t.Text
                  })
                  .ToList();

                return View(model);
            }


            if (model.Domain != 0) lista.Add(_domainService.GetDomain(model.Domain));
            else
            {
                _domainService.GetDomains().ToList().ForEach(d =>
                {

                    var user = _usuarioService.Get(model.UserName, d.Path.Split('.')[0]);
                    if (user != null)
                    {
                        lista.Add(d);
                    }

                });
            }
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            var authService = new ActiveDirectoryAuthentication(authenticationManager);

            var domain = _domainService.GetDomain(model.Domain);

            if (lista.Count > 0 && lista.Count < 2)
            {
                var authenticationResult = authService.SignIn(model.UserName, model.Password, model.RememberMe, lista.First().AdIp, lista.First().Path, model.Idioma, Suplantar.HasValue);


                if (authenticationResult.IsSuccess)
                {
                    Session["Login"] = model;

                        try
                        {
                        using (analyticsSoapClient acceso = new analyticsSoapClient("analyticsSoap12"))
                        {
                            //var person = _serviceEstructura.GetEmpleado(authenticationResult.user.personPK);
                            //acceso.newAccess("ExcelenziaV4", "Acceso", 0, authenticationResult.user.usuarioNT, authenticationResult.user.dominio, authenticationResult.user.personPK, person.projectPk, person.projectLbl, person.subprojectPk, person.subprojectLbl, person.servicesPk, person.serviceLbl, Environment.MachineName.ToString());
                        }
                    }
                    catch (Exception e)
                    {
                       
                    }
                    // Me he logado correctamente
                   return RedirectToAction("Index", "Candidate");
          
                    //return RedirectToHome(returnUrl);
                }


                ModelState.AddModelError("", authenticationResult.ErrorMessage);
                ViewBag.Visible = false;
                ViewBag.domains = GetListDomains().ToList()
                  .Select(t => new
                  {
                      id = t.Value,
                      text = t.Text
                  })
                  .ToList();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Su usuario esta repetido en varias plataformas, por favor indique la correcta para iniciar sesion");
                ModelState.AddModelError("DomainText", "Inserte una plataforma");
                ViewBag.idiomas = idiomas;
                ViewBag.domains = lista.ToList()
                           .Select(x => new SelectListItem
                           {
                               Value = x.Id.ToString(),
                               Text = x.Name
                           }).Select(t => new { id = t.Value, text = t.Text })
                           .ToList();
                ViewBag.Visible = true;
                return View(model);
            }

                   return RedirectToAction("Index", "Candidate");

        }


        public ActionResult Logoff()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut(MyAuthentication.ApplicationCookie);

            return RedirectToAction("Login");
        }


        private ActionResult RedirectToHome(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            return RedirectToAction("Index", "Home");
        }

        private IEnumerable<SelectListItem> GetListDomains()
        {
            var domains = _domainService.GetDomains();
            return domains?.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });
        }
    }
}