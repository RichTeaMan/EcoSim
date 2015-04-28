using EcoSim.Logic;
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
    public partial class CreateWorld : Form
    {
        public bool StartSim { get; private set; }

        public World CreatedWorld { get; private set; }

        public CreateWorld()
        {
            InitializeComponent();
            StartSim = false;

            lbl_Status.Text = string.Empty;
        }

        private async void but_OK_Click(object sender, EventArgs e)
        {
            string buttonText = but_OK.Text;
            try
            {
                Enabled = false;
                but_OK.Text = "Loading...";
                Cursor = Cursors.WaitCursor; // WaitCursor reverts during await Task.Run. A bug in winforms?

                var former = worldCtrl.WorldFormer;
                await Task.Run(() =>
                {
                    UpdateStatus("Building World");
                    var newWorld = new World(worldCtrl.WorldWidth, worldCtrl.WorldHeight, worldCtrl.WorldWrap);
                    UpdateStatus("Terraforming World");
                    former.Generate(newWorld);

                    foreach (var i in Enumerable.Range(0, 500))
                    {
                        if (i % 100 == 0)
                            UpdateStatus("Simulating World: {0} ticks", i);
                        newWorld.Process();
                    }

                    UpdateStatus("Building Flora");
                    newWorld.InitialiseFlora(floraCtrl.InitialCoverage);
                    UpdateStatus("Building Creatures");
                    newWorld.InitialiseCreatures(creaturesCtrl.StartPopulation, creaturesCtrl.MaxPopulation);

                    UpdateStatus("Complete");
                    CreatedWorld = newWorld;
                });

                StartSim = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Enabled = true;
                but_OK.Text = buttonText;
                Cursor = Cursors.Default;
            }
        }

        private void UpdateStatus(string status, params object[] args)
        {
            var message = string.Format(status, args);
            
            lbl_Status.BeginInvoke((MethodInvoker) delegate { lbl_Status.Text = message; });
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
