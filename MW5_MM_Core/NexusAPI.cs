using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_Core
{
    public interface INexusApi
    {

    }
    public class NexusAPI : INexusApi
    {
        private IConfiguration _config;
    }
}
