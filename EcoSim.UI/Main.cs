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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            WorldView.MouseWheel += new MouseEventHandler(WorldView_MouseWheel);
        }

        void WorldView_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                WorldView.ViewScale -= 0.1;
            else if (e.Delta < 0)
                WorldView.ViewScale += 0.1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Creature.CreateCreatures(10, 400);

        }

        private void setupSimulationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (CreateWorld createWorld = new CreateWorld())
            {
                createWorld.ShowDialog();
                if (createWorld.StartSim)
                {
                    WorldTimer.Start();
                    WorldView.BeginDraw(createWorld.CreatedWorld);
                }
            }
        }


        private void WorldTimer_Tick(object sender, EventArgs e)
        {
            WorldView.World.Process();
            
            var Position = WorldView.GetPositionAtMouseLocation();
            if (Position != null)
                lblAltitude.Text = String.Format("Altitude: {0}", Position.Altitude);
            else
                lblAltitude.Text = "Altitude: NA";
            
            lblAltitude.Text += Environment.NewLine + String.Format("Coordinates: {0}, {1}", WorldView.XCoordinate, WorldView.YCoordinate);
        }

        private void WorldView_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void WorldView_MouseClick(object sender, MouseEventArgs e)
        {
            
        }
    }
}
