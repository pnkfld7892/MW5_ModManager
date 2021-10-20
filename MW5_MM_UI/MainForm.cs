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
using MW5_MM_Core.Helpers;
using MW5_MM_Core.Services;

namespace MW5_MM_UI
{
    public partial class MainForm : Form
    {
        private string _mw5InstallLocation;
        private IBaseClass _base;
        public MainForm(IBaseClass _base)
        {
            InitializeComponent();
            this._base = _base;
            var bgColor = _base.Configuration().GetSection("BackgroundColor").Value;
            this.BackColor = Color.FromName(bgColor);
            _mw5InstallLocation = _base.Configuration().GetValue<string>("mw5InstallLocation");
            if(string.IsNullOrEmpty(_mw5InstallLocation))
            {
                _mw5InstallLocation = GetMW5_Location();
                ConfigurationHelper.AddOrUpdateAppSetting<string>("mw5InstallLocation", _mw5InstallLocation);
                _base.Configuration()["mw5InstallLocation"] = _mw5InstallLocation;
            }  
        }

        private static string GetMW5_Location()
        {
            //try to get epic location
            var epicProgramDataPath = $"{Environment.GetEnvironmentVariable("ProgramData")}\\Epic\\EpicGamesLauncher\\Data\\Manifests";
            var epicDirInfo = new DirectoryInfo(epicProgramDataPath);
            foreach (var file in epicDirInfo.EnumerateFiles().Where(x => x.Extension.Contains("item")))
            {
                var rawJson = File.ReadAllText(file.FullName);
                var manifest = JsonConvert.DeserializeObject<GameClient_Data.EpicGameManifest>(rawJson);
                if (manifest.DisplayName.Contains("MechWarrior 5"))
                    return Path.GetFullPath(manifest.InstallLocation);
            }
            //Todo: try to get steam location
            return null;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            gridInstalledMods.DataSource = _base.Mw5ModService().GetInstalledMods();
        }
    }
}
