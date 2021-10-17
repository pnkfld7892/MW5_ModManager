using Microsoft.Extensions.Configuration;
using Nexus_Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace MW5_MM_UI
{
    public partial class Form1 : Form
    {
        private INexusApi _nexusApi;
        private IConfiguration _config;
        private Dictionary<string, bool> mw5ModList;
        private string _mw5InstallLocation;
        public Form1(INexusApi nexusApi, IConfiguration config)
        {
            InitializeComponent();
            _nexusApi = nexusApi;
            _config = config;
            var bgColor = _config.GetSection("BackgroundColor").Value;
            this.BackColor = Color.FromName(bgColor);
            _mw5InstallLocation = GetMW5_Location();
            textBox1.Text = _mw5InstallLocation ?? "Mw5 Not Found";
        }

        private string GetMW5_Location()
        {
            //try to get epic location
            var epicProgramDataPath = $"{Environment.GetEnvironmentVariable("ProgramData")}\\Epic\\EpicGamesLauncher\\Data\\Manifests";
            var epicDirInfo = new DirectoryInfo(epicProgramDataPath);
            foreach(var file in epicDirInfo.EnumerateFiles().Where(x => x.Extension.Contains("item")))
            {
                var rawJson = File.ReadAllText(file.FullName);
                var manifest = JsonConvert.DeserializeObject<GameClient_Data.EpicGameManifest>(rawJson);
                if (manifest.DisplayName.Contains("MechWarrior 5"))
                    return  Path.GetFullPath(manifest.InstallLocation);
            }
            //Todo: try to get steam location
            return null;
        }


    }
}
