using EcoSim.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EcoSim.UI
{
    public partial class CreateWorld : Form
    {
        public bool StartSim = false;

        public World CreatedWorld { get; private set; }

        public CreateWorld()
        {
            InitializeComponent();
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            var newWorld = new World(worldCtrl.WorldWidth, worldCtrl.WorldHeight, worldCtrl.WorldWrap);
            newWorld.InitialiseFlora(floraCtrl.InitialCoverage);
            newWorld.InitialiseCreatures(creaturesCtrl.StartPopulation, creaturesCtrl.MaxPopulation);

            CreatedWorld = newWorld;

            StartSim = true;
            this.Close();
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
