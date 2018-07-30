using ServiceLogin.Dto;
using System.Collections.Generic;
using System.Net.Http;

namespace ServiceLogin.Service
{
    public class UsuarioService : ServiceBase
    {
        public UsuarioDTO Get(string username, string domain)
        {
            var response = Client.GetAsync($"Usuario/{username}/{domain}/32").Result;
            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<UsuarioDTO>().Result;
            return null;
        }
        //public IList<AgentDto> GetAgentsCol(int id)
        //{
        //    var response = Client.GetAsync($"api/Agents/Col/{id}").Result;
        //    if (response.IsSuccessStatusCode)
        //        return response.Content.ReadAsAsync<IList<AgentDto>>().Result;
        //    return null;
        //}

        //public AgentDto GetAgent(int id)
        //{
        //    var response = Client.GetAsync($"api/Agents/{id}").Result;
        //    if (response.IsSuccessStatusCode)
        //        return response.Content.ReadAsAsync<AgentDto>().Result;
        //    return null;
        //}

        //public AgentDto GetAgent(string userNt)
        //{
        //    var response = Client.GetAsync($"api/Agents/UserNT/{userNt}").Result;
        //    if (response.IsSuccessStatusCode)
        //        return response.Content.ReadAsAsync<AgentDto>().Result;
        //    return null;
        //}

        //public AreaDto PutAgent(AgentDto agent)
        //{
        //    var response = Client.PutAsJsonAsync($"api/Agents/{agent.Id}", agent).Result;
        //    if (response.IsSuccessStatusCode)
        //        return response.Content.ReadAsAsync<AreaDto>().Result;
        //    return null;
        //}
    }
}
