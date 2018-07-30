using Arvato.PortalCandadato.Shared.DTO;
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
    public class RegionService :ServiceBase
    {


        public RegionService() : base()
        {
            Client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiPortalCandidato"]);

        }


        public async Task<IEnumerable<RegionDTO>> Get()
        {
            var response = Client.GetAsync("Region").Result;
            if (response.IsSuccessStatusCode)
            {
                return  await response.Content.ReadAsAsync<IEnumerable<RegionDTO>>();
            }
            return null;
        }


        public async Task<RegionDTO> Get(int id)
        {
            var response = Client.GetAsync($"Region/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<RegionDTO>();
                return result;
            }
            return null;
        }



        public async Task<Boolean> Update(RegionDTO region)
        {
           
            var JSregion = JsonConvert.SerializeObject(region);
            HttpContent content = new StringContent(JSregion);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response =  Client.PutAsync("Region", content).Result;
            return response.IsSuccessStatusCode;

        }



    }
}
