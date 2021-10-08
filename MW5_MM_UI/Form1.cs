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

namespace MW5_MM_UI
{
    public partial class Form1 : Form
    {
        private INexusApi _nexusApi;
        public Form1(INexusApi nexusApi)
        {
            InitializeComponent();
            _nexusApi = nexusApi;
        }

    }
}
