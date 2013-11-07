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

        private Control OldPanel;
        private CreaturesCreateWorld Creatures;
        private FloraCreateWorld Flora;
        private WorldCreateWorld World;

        public CreateWorld()
        {
            InitializeComponent();

            if (DesignMode == false)
            {
                Creatures = new CreaturesCreateWorld();
                Flora = new FloraCreateWorld();
                World = new WorldCreateWorld();

                OldPanel = Creatures;
                SwitchPanel.Controls.Add(OldPanel);
            }
        }

        private void ListOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListOptions.SelectedItems.Count != 0)
            {
                SwitchPanel.Controls.Remove(OldPanel);
                switch (ListOptions.SelectedItems[0].Text)
                {
                    case "Creatures":
                        OldPanel = Creatures;
                        break;
                    case "Flora":
                        OldPanel = Flora;
                        break;
                    case "World":
                        OldPanel = World;
                        break;
                }
                SwitchPanel.Controls.Add(OldPanel);
            }
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            var newWorld = new World(World.WorldWidth, World.WorldHeight, World.WorldWrap);
            newWorld.InitialiseFlora(Flora.InitialCoverage);
            newWorld.InitialiseCreatures(Creatures.StartPopulation, Creatures.MaxPopulation);

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
