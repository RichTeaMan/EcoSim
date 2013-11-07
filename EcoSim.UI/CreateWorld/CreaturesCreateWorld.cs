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
    public partial class CreaturesCreateWorld : UserControl
    {
        public CreaturesCreateWorld()
        {
            InitializeComponent();
        }

        public int StartPopulation
        {
            get { return Convert.ToInt32(num_StartPopulation.Value); }
        }

        public int MaxPopulation
        {
            get{ return Convert.ToInt32(num_MaxPopulation.Value);}
        }
    }
}
