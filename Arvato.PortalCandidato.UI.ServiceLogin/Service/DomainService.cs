using ServiceLogin.Dto;
using System.Collections.Generic;
using System.Net.Http;

namespace ServiceLogin.Service
{
    public class DomainService : ServiceBase
    {
        public IList<DomainDto> GetDomains()
        {
            var responseDomains = Client.GetAsync("Domains").Result;

            if (responseDomains.IsSuccessStatusCode)
                return responseDomains.Content.ReadAsAsync<List<DomainDto>>().Result;
            return null;
        }

        public DomainDto GetDomain(int id)
        {
            var response = Client.GetAsync($"Domains/{id}").Result;
            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<DomainDto>().Result;
            return null;
        }
    }
}
