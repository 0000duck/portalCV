using ServiceLogin.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace Microsoft.AspNet.Identity
{
    public static class IdentityExtension
    {
        public static int GetPersonPK(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst("UserId");

            if (claim == null)
                return 0;

            return int.Parse(claim.Value);
        }


        public static int GetServicePK(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst("servicePK");

            if (claim == null)
                return 0;

            return int.Parse(claim.Value);
        }



        public static bool GetEsCDE(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst("esCDE");

            if (claim == null)
                return false;

            return bool.Parse(claim.Value);
        }



        public static bool GetEsEstructura(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst("esEstructura");

            if (claim == null)
                return false;

            return bool.Parse(claim.Value);
        }


        public static bool GetEsCalidad(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst("esCalidad");

            if (claim == null)
                return false;

            return bool.Parse(claim.Value);
        }



        public static int GetPlataformaPK(this IIdentity identity)
        {

            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst("SiteId");

            if (claim == null)
                return 0;

            return int.Parse(claim.Value);
        }



        public static string GetDominio(this IIdentity identity)
        {

            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst("dominio");

            if (claim == null)
                return "";

            return claim.Value;
        }



        public static string GetUsuarioNT(this IIdentity identity)
        {

            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst("usuarioNT");

            if (claim == null)
                return "";

            return claim.Value;
        }


        public static string GetIdioma(this IIdentity identity)
        {

            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst("idioma");

            if (claim == null)
                return "";

            return claim.Value;
        }

    }
}