using Arvato.PortalCandadato.Shared.DTO;
using Arvato.PortalCandidato.UI.Service.clases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Arvato.PortalCandidato.UI.Service
{
    public class CandidateService :ServiceBase
    {

        public CandidateService() :base()
        {
            Client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiPortalCandidato"]);
        }
        public async Task<IEnumerable<CandidateDTO>> Get()
        {
            var response = Client.GetAsync("Candidate").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<IEnumerable<CandidateDTO>>();
                return result;
            }
            return null;
        }

        /// <summary>
        /// Envía el número de candidatos recibidos interesandose por las regiones
        /// en el último día a los correos configurados en dichas regiones
        /// </summary>
        /// <returns></returns>
        public async Task<string> envioDeEmail()
        {
            var responseC = Client.GetAsync("Candidate").Result;
            var responseR = Client.GetAsync("Region").Result;
            IEnumerable<CandidateDTO> resultC=null;

            var resultR = await responseR.Content.ReadAsAsync<IEnumerable<RegionDTO>>();
            var dia = new TimeSpan(24, 0, 0);
            if (responseC.IsSuccessStatusCode)
            {
                resultC = (from c in (await responseC.Content.ReadAsAsync<IEnumerable<CandidateDTO>>())
                           where DateTime.Now.Subtract(c.TimeIn).Days < 1
                           && !c.IsDelete
                           select c).ToList();

            }
            var correos = "";
            foreach (var region in resultR)
            {
                var numeroCV = (from c in resultC
                                where c.RegionsIds.Split(',').Contains(region.Id.ToString())
                                select c).ToList().Count;

                ///////////////////////////////////////////////
                //Aqui puedo enviar los email
                //

                var mensaje = "<div style='color:#0779b4;'><h2>Porta Candidato Arvato</h2><h3>CURRICULUMS</h3></div>" +
                              "<table cellpadding='10' style='border-collapse: collapse'>" +
                              "<tr style='background-color:#0779b4;'><th>DIA</th><th>Plataforma</th><th>Nº</th></tr>" +
                              "<tr style='background-color:#AAA;'><td>"+ DateTime.Now + "</td><td>"+ region.RegionName + "</td><td>"+ numeroCV + "</td></tr>" +
                              "</table>";

                if (numeroCV > 0)
                {
                    correos += mensaje + "\n";
                    var correo = new Mail("noreply.crmiberia@arvato.com", region.Email, mensaje, "Curriculum Portal Candidato", null);
                    correo.enviaMail();
                }

                ////////////////////////////////////////////////

            }

            return correos;
        }

        /// <summary>
        /// Elimina los candidatos que llevan en el registro mas de 2 años,
        /// Devuelve una lista de los candidatos que cumplen esta condicion y no se han eliminado
        /// </summary>
        /// <returns>lista no eliminados</returns>
        public async Task<IEnumerable<CandidateDTO>> DeleteCandidate2yaersOld()
        {
            var response = Client.GetAsync("Candidate").Result;
            var listaNoeliminados = new List<CandidateDTO>();
            IEnumerable<CandidateDTO> result =null;
            if (response.IsSuccessStatusCode)
            {
      
                result = (from c in (await response.Content.ReadAsAsync<IEnumerable<CandidateDTO>>())
                              where DateTime.Now.Subtract(c.TimeIn).Days > 730
                              select c).ToList();

                foreach (var item in result)
                {
                   if( !await this.Delete(item))
                    {
                        listaNoeliminados.Add(item);
                    }
                }
            }

            ///enviarme un correo de los que no han sido eliminados para ver que ha pasado
            return result;
        }



        public async Task<CandidateDTO> Get(int id)
        {
            var response = Client.GetAsync($"Candidate/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<CandidateDTO>();
                return result;
            }
            return null;
        }




        public async Task<Boolean> Insert(CandidateDTO candidato)
        {
            var JScandidato = JsonConvert.SerializeObject(candidato);
            HttpContent content = new StringContent(JScandidato);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");


            var response =  Client.PostAsync($"Candidate", content).Result;
            return  response.IsSuccessStatusCode;

            //if ( response.IsSuccessStatusCode)
            //{
            //    var a = JsonConvert.DeserializeObject<CandidateDTO>(JScandidato);
            //    return null;//

            //}
            //return null;
        }

        public async Task<Boolean> Update(CandidateDTO candidato)
        {

            var JScandidato = JsonConvert.SerializeObject(candidato);
            HttpContent content = new StringContent(JScandidato);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = Client.PutAsync("Candidate", content).Result;
            return response.IsSuccessStatusCode;
        }


        public async Task<Boolean> Delete(CandidateDTO candidato)
        {

            //var JScandidato = JsonConvert.SerializeObject(candidato);
            //HttpContent content = new StringContent(JScandidato);
            //content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            CvFileService CvFile = new CvFileService();
            var isdeleteFile = CvFile.deleteFtpFile(candidato.PathCV);
            if (isdeleteFile)
            {
               return  Client.DeleteAsync($"Candidate/{candidato.Id}").Result.IsSuccessStatusCode;
            }
            return isdeleteFile;

        }




        


    }
}

