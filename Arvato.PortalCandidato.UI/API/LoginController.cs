using ServiceLogin.Authentication;
using ServiceLogin.Dto;
using ServiceLogin.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Arvato.PortalCandidato.UI.API
{
    [Authorize]
    public class LoginController : ApiController
    {

        private readonly DomainService _domainService;

        public LoginController()
        {
            _domainService = new DomainService();
        }

        [Route("api/Login")]
        public bool Post([FromBody]pdiValidacionDTO validacionpdi)
        {
            var domain = _domainService.GetDomain(validacionpdi.idDominio);
            return ActiveDirectoryAuthentication.CheckUser(validacionpdi.UserName, validacionpdi.password, false, domain.AdIp, domain.Path, validacionpdi.personPK);
        }

        //[Route("api/Login/{idDominio}/{UserName}/{password}/{personPK}")]
        //public bool Get(int idDominio, string UserName, string password, int? personPK)
        //{
        //    var domain = _domainService.GetDomain(idDominio);
        //    return ActiveDirectoryAuthentication.CheckUser(UserName, password, false, domain.AdIp, domain.Path, personPK);
        //}
    }
}
