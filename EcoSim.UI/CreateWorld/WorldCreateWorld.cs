using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EcoSim.UI
{
    public partial class WorldCreateWorld : UserControl
    {
        public WorldCreateWorld()
        {
            InitializeComponent();
        }

        public int WorldWidth
        {
            get { return Convert.ToInt32(num_Width.Value); }
        }

        public int WorldHeight
        {
            get { return Convert.ToInt32(num_Height.Value); }
        }

        public bool WorldWrap
        {
            get { return chk_WorldWrap.Checked; }
        }
    }
}
