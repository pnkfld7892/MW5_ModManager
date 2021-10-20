using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MW5_MM_Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MW5_MM_Core.Services
{
    public interface IMw5ModService
    {
        List<InstalledMod> GetInstalledMods();
    }
    public class Mw5ModService : IMw5ModService
    {
        public IConfiguration _config;

        public Mw5ModService(IConfiguration config)
        {
            _config = config;
        }

        public List<InstalledMod> GetInstalledMods()
        {
            var retList = new List<InstalledMod>();
            var root = _config.GetSection("mw5InstallLocation").Value;
            var jsonRaw = File.ReadAllText(Path.Combine(root,"MW5Mercs/Mods/modlist.json"));
            var parentObj = JObject.Parse(jsonRaw);

            foreach(var property in parentObj.Value<JObject>("modStatus").Properties())
            {
                var name = property.Name;
                var enabled = property.First().Value<bool>("bEnabled");

                var installedMod = new InstalledMod
                {
                    Name = name,
                    Enabled = enabled
                };

                retList.Add(installedMod);
            }

            return retList;


        }
    }
}
