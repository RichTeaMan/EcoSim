using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    logicWorker.RunWorkerAsync();
                }
            }
        }


        private void WorldTimer_Tick(object sender, EventArgs e)
        {
            var position = WorldView.GetPositionAtMouseLocation();
            if (position != null)
            {
                var lines = new List<string>();
                lines.Add(string.Format("X: {0} Y: {1}", position.X, position.Y));
                lines.Add(string.Format("Creature: {0}", position.Creature != null));
                lines.Add(string.Format("Altitude: {0}", position.Altitude));
                lines.Add(string.Format("Has Water: {0}", position.HasWater));
                lines.Add(string.Format("Water Level: {0}", position.WaterLevel));
                lines.Add(string.Format("Total Altitude: {0}", position.TotalAltitude));

                infoBox.Lines = lines.ToArray();
            }
            else
            {
                infoBox.Text = "No position selected.";
            }

            lbl_Status.Text = string.Format("Frames Drawn: {0} Frames Painted: {1} World Tick: {2}", WorldView.FramesDrawn, WorldView.FramesPainted, WorldView.World.Tick);
        }

        private void WorldView_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void WorldView_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private async void logicWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!logicWorker.CancellationPending)
            {
                WorldView.World.Process();
                await Task.Delay(100);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            logicWorker.CancelAsync();
        }
    }
}
