using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ServiceLogin.Service
{
    public abstract class ServiceBase
    {
        public HttpClient Client = new HttpClient();

        protected ServiceBase()
        {
            Client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiURL"]);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
