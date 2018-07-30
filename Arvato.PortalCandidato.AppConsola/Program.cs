using Arvato.PortalCandidato.UI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvato.PortalCandidato.AppConsola
{
    class Program
    {
        static void Main(string[] args)
        {

            //Configurar la URL del API y de la carpeta donde se guardan los CV correctamente en el App.config.
            CandidateService C = new CandidateService();
            //Eliminamos los registros y CV de mas de 2 años
            C.DeleteCandidate2yaersOld();


            //Enviamos los email de los nuevos registros
            C.envioDeEmail();
            


        }
    }
}
