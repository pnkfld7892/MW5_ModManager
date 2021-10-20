using Microsoft.Extensions.Configuration;
using MW5_MM_Core.Services;
using Nexus_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5_MM_UI
{
    public interface IBaseClass 
    {
        public INexusApi NexusApi();
        public IConfiguration Configuration();
        public IMw5ModService Mw5ModService();
     
    }
    public class BaseClass : IBaseClass
    {
        private INexusApi _nexusApi;
        private IConfiguration _config;
        private IMw5ModService _mw5ModService;

        public BaseClass(INexusApi nexusApi, IConfiguration config, IMw5ModService mw5ModService)
        {
            _nexusApi = nexusApi;
            _config = config;
            _mw5ModService = mw5ModService;
        }

        public INexusApi NexusApi()
        {
            return _nexusApi;
        }

        public IConfiguration Configuration()
        {
            return _config;
        }

        public IMw5ModService Mw5ModService()
        {
            return _mw5ModService;
        }

        
    }
}
