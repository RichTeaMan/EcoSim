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
    public partial class FloraCreateWorld : UserControl
    {
        public FloraCreateWorld()
        {
            InitializeComponent();
        }

        public int InitialCoverage
        {
            get { return Convert.ToInt32(num_InitialCoverage.Value); }
        }
    }
}
