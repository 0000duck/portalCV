using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;
using System.Runtime.Serialization.Json;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Api2connect.Persistencia;
using qcode;
using objetos;
using qcoderegistroEventos;
using Api2connect.arvatoControl;
using System.Globalization;

namespace Api2connect
{
    /// <summary>
    /// Descripción breve de api2connect
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class api2connect : System.Web.Services.WebService
    {
        [WebMethod]
        public List<obtener_index_elementos_trabajo_Result> tiposElementosTrabajo()
        {
            using (Dev_PortalCandidatoEntities1 contexto = new Dev_PortalCandidatoEntities1())
            {
                return contexto.obtener_index_elementos_trabajo().ToList();
            }
        }

        [WebMethod]
        public List<obtener_detalle_elementos_trabajo_Result> ElementosTrabajo(int tipo)
        {
            using (Dev_PortalCandidatoEntities1 contexto = new Dev_PortalCandidatoEntities1())
            {
                return contexto.obtener_detalle_elementos_trabajo(tipo).ToList();
            }
        }

        [WebMethod]
        public List<obtener_perfiles_Result> perfiles()
        {
            using (Dev_PortalCandidatoEntities1 contexto = new Dev_PortalCandidatoEntities1())
            {
                return contexto.obtener_perfiles().ToList();
            }
        }
    }

}
