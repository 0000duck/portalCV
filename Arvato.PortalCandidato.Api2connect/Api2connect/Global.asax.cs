using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Configuration;
using System.Configuration;

namespace ApiSiop
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

            // Código que se ejecuta al iniciarse la aplicación             
            string nombreNetBios = Environment.MachineName.ToString();
            string Dev_PortalCandidatoEntities = "";
          

            //switch (nombreNetBios.ToUpper())
            //{
            //    case "DESARROLLO-SIOP":
            //        //Pre-producción 10.20.0.164
            //        Dev_PortalCandidatoEntities = "metadata=res://*/Persistencia.ModelPortalCandidato.csdl|res://*/Persistencia.ModelPortalCandidato.ssdl|res://*/Persistencia.ModelPortalCandidato.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=10.20.56.184;initial catalog=Dev_PortalCandidato;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;";

            //      break;
            //    case "RPORSIOP":
            //        //Producción 10.20.0.170
            //        Dev_PortalCandidatoEntities = "metadata=res://*/Persistencia.ModelPortalCandidato.csdl|res://*/Persistencia.ModelPortalCandidato.ssdl|res://*/Persistencia.ModelPortalCandidato.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=10.20.56.184;initial catalog=Dev_PortalCandidato;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;";

            //        break;
            //    default:
            //        string servidor = "1";
            //        switch (servidor)
            //        {
            //            case "1":
            //                //Desarrollo
            //                Dev_PortalCandidatoEntities = "metadata=res://*/Persistencia.ModelPortalCandidato.csdl|res://*/Persistencia.ModelPortalCandidato.ssdl|res://*/Persistencia.ModelPortalCandidato.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=10.20.56.184;initial catalog=Dev_PortalCandidato;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;";

            //               break;
            //            case "2":
            //                //Preproducción
            //                Dev_PortalCandidatoEntities = "metadata=res://*/Persistencia.ModelPortalCandidato.csdl|res://*/Persistencia.ModelPortalCandidato.ssdl|res://*/Persistencia.ModelPortalCandidato.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=10.20.56.184;initial catalog=Dev_PortalCandidato;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;";

            //                break;
            //            case "3":
            //                //Producción
            //                Dev_PortalCandidatoEntities = "metadata=res://*/Persistencia.ModelPortalCandidato.csdl|res://*/Persistencia.ModelPortalCandidato.ssdl|res://*/Persistencia.ModelPortalCandidato.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=10.20.56.184;initial catalog=Dev_PortalCandidato;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;";

            //                break;
            //        }
            //        break;
            //}

            //var configuration = WebConfigurationManager.OpenWebConfiguration("~/"); // Se supone que te permite escribir

            //var section = (ConnectionStringsSection)configuration.GetSection("connectionStrings");
            //var section1 = (AppSettingsSection)configuration.GetSection("appSettings");

            ////No debemos cambiar nada si la cadena ya está cambiada
            //string cadena = section.ConnectionStrings["Dev_PortalCandidatoEntities"].ConnectionString.ToString(); //Recupero la cadena

            //if (cadena != Dev_PortalCandidatoEntities)
            //{
            //    section.ConnectionStrings["Dev_PortalCandidatoEntities"].ConnectionString = Dev_PortalCandidatoEntities;

            //    configuration.Save();
            //    System.Web.HttpRuntime.UnloadAppDomain();
            //}
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}