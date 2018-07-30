using Microsoft.Owin.Security;
using System;
using System.DirectoryServices.AccountManagement;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLogin.Service;
using ServiceLogin.Dto;
using System.Security.Claims;

namespace ServiceLogin.Authentication
{
    public class ActiveDirectoryAuthentication
    {
        private readonly IAuthenticationManager _authenticationManager;


        private readonly int[] perfilescd = { 12, 257, 55, 486, 135, 29 };

        public ActiveDirectoryAuthentication(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }

        public AuthenticationResult SignIn(string username, string password, bool rememberMe, string ip, string domain, string idioma, bool suplantar)
        {
            //#if DEBUG
            //var authenticationType = ContextType.Machine;
            //var principalContext = new PrincipalContext(authenticationType);
            //var user = $"{username}";
            //#else
            var authenticationType = ContextType.Domain;

            var principalContext = new PrincipalContext(authenticationType);

            var user = $"{username}{domain}";
            if (suplantar) user = "siop@csmad";

            if (ip != null && ip != "" && ip != "0.0.0.0")
            {


                principalContext = new PrincipalContext(authenticationType, ip);

            }
            else
            {
                user += ".arvato.iberia";

                principalContext = new PrincipalContext(authenticationType, domain.Replace("@", "").Split('.')[0]);
            }

            //#endif
#if DEBUG
            bool isAuthenticated = false;
#else
            bool isAuthenticated = false; //por defecto a true para pruebas
#endif
            //bool isAuthenticated = true;

            UserPrincipal userPrincipal = null;

            try
            {
                if (!isAuthenticated)
                {
                    isAuthenticated = principalContext.ValidateCredentials(user, password, ContextOptions.Negotiate);
                }
                if (isAuthenticated)
                    userPrincipal = UserPrincipal.FindByIdentity(principalContext, user);
            }
            catch (Exception)
            {
                //isAuthenticated = false;
                userPrincipal = null;
            }

            if (!isAuthenticated) //||   userPrincipal == null
                return new AuthenticationResult("Username or Password is not correct");

            //if (userPrincipal.IsAccountLockedOut())
            //    return new AuthenticationResult("Your account is locked.");

            //if (userPrincipal.Enabled.HasValue == false)
            //    return new AuthenticationResult("Your account is disabled");

            var usuarioService = new UsuarioService();
            var usuario = usuarioService.Get(username, domain.Split('.')[0]);


            if (usuario == null)
                return new AuthenticationResult("User not authorized");
            usuario.idioma = idioma;//cambiar esto
            var identity = CreateIdentity(userPrincipal, usuario, user);

            _authenticationManager.SignOut(MyAuthentication.ApplicationCookie);
            _authenticationManager.SignIn(new AuthenticationProperties { IsPersistent = rememberMe }, identity);

            return new AuthenticationResult() { user = usuario };
        }

        public static Boolean CheckUser(string username, string password, bool rememberMe, string ip, string domain, int? personPK = 0)
        {
            //#if DEBUG
            //var authenticationType = ContextType.Machine;
            //var principalContext = new PrincipalContext(authenticationType);
            //var user = $"{username}";
            //#else
            var authenticationType = ContextType.Domain;

            var usuarioService = new UsuarioService();

            var principalContext = new PrincipalContext(authenticationType);



            var user = $"{username}{domain}";


            if (ip != null && ip != "" && ip != "0.0.0.0")
            {
                principalContext = new PrincipalContext(authenticationType, ip);
            }
            else
            {
                user += ".arvato.iberia";
                principalContext = new PrincipalContext(authenticationType, domain.Replace("@", "").Split('.')[0]);
            }

            //#endif

            bool isAuthenticated = false; //por defecto a true para pruebas validacion TM

            try
            {
                if (!isAuthenticated)
                {
                    isAuthenticated = principalContext.ValidateCredentials(user, password, ContextOptions.Negotiate);
                }

                //if (isAuthenticated) //solo para pruebas
                if (isAuthenticated && (usuarioService.Get(username, domain.Split('.')[0]).personPK == personPK))
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception e)
            {
                return false;
            }
        }



        private ClaimsIdentity CreateIdentity(UserPrincipal userPrincipal, UsuarioDTO usuario, string user)
        {
            var identity = new ClaimsIdentity(MyAuthentication.ApplicationCookie, ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            identity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "Active Directory"));

            if (userPrincipal != null)
            {
                identity.AddClaim(new Claim(ClaimTypes.Name, userPrincipal.DisplayName));
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userPrincipal.SamAccountName));
            }
            else

            {
                identity.AddClaim(new Claim(ClaimTypes.Name, usuario.nombreCompleto));// userPrincipal.DisplayName));
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user));//  userPrincipal.SamAccountName));
            }


            identity.AddClaim(new Claim(ClaimTypes.Role, usuario.categoria));
            identity.AddClaim(new Claim("SiteId", usuario.plataformaPk.ToString()));
            identity.AddClaim(new Claim("UserId", usuario.personPK.ToString()));
            identity.AddClaim(new Claim("esAdmin", (usuario.perfiles.Where(x => x == 1).Count() > 0).ToString()));
            identity.AddClaim(new Claim("esTecnico", (usuario.perfiles.Where(x => x == 2).Count() > 0).ToString()));
            identity.AddClaim(new Claim("esCDE", (perfilescd.Contains(usuario.servicesPk).ToString())));
            identity.AddClaim(new Claim("dominio", (usuario.dominio)));
            identity.AddClaim(new Claim("usuarioNT", (usuario.usuarioNT)));
            identity.AddClaim(new Claim("servicePK", usuario.servicesPk.ToString()));
            identity.AddClaim(new Claim("idioma", usuario.idioma));

            //identity.AddClaim(new Claim("AgentMail", agent.Email.ToString()));
            //if (!string.IsNullOrEmpty(userPrincipal.EmailAddress))
            //	identity.AddClaim(new Claim(ClaimTypes.Email, userPrincipal.EmailAddress));
            return identity;
        }

        public class AuthenticationResult
        {
            public AuthenticationResult(string errorMessage = null)
            {
                ErrorMessage = errorMessage;
            }

            public UsuarioDTO user { get; set; }

            public string ErrorMessage { get; }
            public bool IsSuccess => string.IsNullOrEmpty(ErrorMessage);
        }
    }
}
