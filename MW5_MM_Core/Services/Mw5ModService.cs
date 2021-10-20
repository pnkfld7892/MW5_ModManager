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
        int WriteInstalledMods(List<InstalledMod> installedMods);
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

        public int WriteInstalledMods(List<InstalledMod> installedMods)
        {
            try
            {
                var jsonBuilder = new StringBuilder();
                jsonBuilder.Append("{");
                jsonBuilder.Append("\"modStatus\":{");
                for (int i = 0; i < installedMods.Count; i++)
                {
                    jsonBuilder.Append($"\"{installedMods[i].Name}\": {{");
                    jsonBuilder.Append($"\"bEnabled\": {installedMods[i].Enabled.ToString().ToLower()}");
                    jsonBuilder.Append("}");
                    if (i < installedMods.Count - 1)
                        jsonBuilder.Append(",");
                }

                jsonBuilder.Append("}");
                jsonBuilder.Append("}");
                var jsonRaw = jsonBuilder.ToString();
                var root = _config.GetSection("mw5InstallLocation").Value;

                File.WriteAllText(Path.Combine(root, "MW5Mercs/Mods/modlist.json"), jsonRaw);
                return 0;
            }
            catch(Exception ex)
            {
                //todo: log out this error when logger is hooked up
                return -1;
            }
        }
    }
}
