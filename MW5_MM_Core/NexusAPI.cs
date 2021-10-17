using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Nexus_Core
{
    public interface INexusApi
    {
        public string GetBaseUrl();
    }
    public class NexusAPI : INexusApi
    {
        private IConfiguration _config;
        private HttpClient _httpClient;

        public NexusAPI(IHttpClientFactory httpClientFacotry, IConfiguration config)
        {
            _httpClient = httpClientFacotry.CreateClient("nexusApi");
            _config = config;
        }

        public string GetBaseUrl()
        {
            return _httpClient.BaseAddress.AbsoluteUri;
        }
    }
}
