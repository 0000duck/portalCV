using ServiceLogin.Dto;
using ServiceLogin.Service;
using System.Collections.Generic;
using System.Net.Http;


namespace ServiceLogin
{
    public class ServiceLogin : ServiceBase
    {
        public IList<DomainDto> GetDomains()
        {
            var responseDomains = Client.GetAsync("api/Domains").Result;

            if (responseDomains.IsSuccessStatusCode)
                return responseDomains.Content.ReadAsAsync<List<DomainDto>>().Result;
            return null;
        }

        public DomainDto GetDomain(int id)
        {
            var response = Client.GetAsync($"api/Domains/{id}").Result;
            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<DomainDto>().Result;
            return null;
        }
    }
}
