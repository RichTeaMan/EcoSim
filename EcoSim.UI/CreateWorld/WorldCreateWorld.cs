using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EcoSim.Logic;

namespace EcoSim.UI
{
    public partial class WorldCreateWorld : UserControl
    {
        public WorldCreateWorld()
        {
            InitializeComponent();
            var iFormer = typeof(IWorldFormer);
            var formers = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => t.GetInterfaces().Contains(iFormer) && !t.IsInterface)
                .ToArray();

            foreach (var former in formers)
            {
                try
                {
                    var formerInstance = (IWorldFormer)former.GetConstructor(Type.EmptyTypes).Invoke(null);
                    var listItem = new ListViewItem(former.Name) { Tag = formerInstance };
                    worldFormerList.Items.Add(listItem);
                }
                catch // should log this. TODO.
                { }
            }

            worldFormerList.Items[0].Selected = true;
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

        /// <summary>
        /// Gets the currently selected IWorldFormer with the assigned parameters.
        /// </summary>
        /// <returns></returns>
        public IWorldFormer WorldFormer
        {
            get
            {
                if (worldFormerList.SelectedItems.Count > 0)
                {
                    return worldFormerList.SelectedItems[0].Tag as IWorldFormer;
                }
                return null;
            }
        }

        private void CreateFormerOptions(IWorldFormer former)
        {
            var table = new TableLayoutPanel();
            table.Dock = DockStyle.Fill;
            table.Location = new Point(0, 0);

            Label lbl_Summary = new Label();
            lbl_Summary.Text = former.Summary;
            lbl_Summary.Dock = DockStyle.Fill;
            table.Controls.Add(lbl_Summary, 0, 0);
            table.SetColumnSpan(lbl_Summary, 2);

            int rowCount = 1;
            foreach (var prop in former.GetType().GetProperties().Where(p => p.Name != "Summary"))
            {
                Control valueCtrl = null;
                if (prop.PropertyType == typeof(int) || prop.PropertyType == typeof(short))
                {
                    NumericUpDown num = new NumericUpDown();
                    num.DecimalPlaces = 0;
                    num.DataBindings.Add("Value", former, prop.Name);
                    valueCtrl = num;
                }
                else if (prop.PropertyType == typeof(double))
                {
                    NumericUpDown num = new NumericUpDown();
                    num.DecimalPlaces = 2;
                    num.DataBindings.Add("Value", former, prop.Name);
                    valueCtrl = num;
                }
                else if (prop.PropertyType == typeof(string))
                {
                    TextBox tb = new TextBox();
                    tb.DataBindings.Add("Text", former, prop.Name);
                    valueCtrl = tb;
                }
                if (valueCtrl != null)
                {
                    valueCtrl.Enabled = prop.CanWrite;
                    table.RowStyles.Add(new RowStyle());//(SizeType.Absolute, 30F));
                    var lbl = new Label();
                    lbl.AutoSize = false;
                    lbl.Location = new Point(0, 5);
                    lbl.Text = prop.Name;
                    
                    table.Controls.Add(lbl, 0, rowCount);
                    lbl.Location = new Point(0, 5);
                    
                    table.Controls.Add(valueCtrl, 1, rowCount);
                    valueCtrl.Location = new Point(0, 0);
                    rowCount++;
                }
            }
            formerOptions.Controls.Clear();
            formerOptions.Controls.Add(table);
            table.Dock = DockStyle.Fill;
            table.Location = new Point(0, 0);
        }

        private void worldFormerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (worldFormerList.SelectedItems.Count > 0)
            {
                var worldFormer = WorldFormer;
                if (worldFormer != null)
                    CreateFormerOptions(worldFormer);
            }
        }

    }
}
