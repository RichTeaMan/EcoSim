namespace EcoSim.UI
{
    partial class CreateWorld
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.but_OK = new System.Windows.Forms.Button();
            this.but_Cancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_Creatures = new System.Windows.Forms.TabPage();
            this.creaturesCtrl = new EcoSim.UI.CreaturesCreateWorld();
            this.tab_Flora = new System.Windows.Forms.TabPage();
            this.floraCtrl = new EcoSim.UI.FloraCreateWorld();
            this.tab_World = new System.Windows.Forms.TabPage();
            this.worldCtrl = new EcoSim.UI.WorldCreateWorld();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tab_Creatures.SuspendLayout();
            this.tab_Flora.SuspendLayout();
            this.tab_World.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(477, 418);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.44566F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.55435F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel2.Controls.Add(this.but_OK, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.but_Cancel, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 387);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(471, 28);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // but_OK
            // 
            this.but_OK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.but_OK.Location = new System.Drawing.Point(302, 3);
            this.but_OK.Name = "but_OK";
            this.but_OK.Size = new System.Drawing.Size(81, 22);
            this.but_OK.TabIndex = 0;
            this.but_OK.Text = "OK";
            this.but_OK.UseVisualStyleBackColor = true;
            this.but_OK.Click += new System.EventHandler(this.but_OK_Click);
            // 
            // but_Cancel
            // 
            this.but_Cancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.but_Cancel.Location = new System.Drawing.Point(389, 3);
            this.but_Cancel.Name = "but_Cancel";
            this.but_Cancel.Size = new System.Drawing.Size(79, 22);
            this.but_Cancel.TabIndex = 1;
            this.but_Cancel.Text = "Cancel";
            this.but_Cancel.UseVisualStyleBackColor = true;
            this.but_Cancel.Click += new System.EventHandler(this.but_Cancel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_World);
            this.tabControl1.Controls.Add(this.tab_Creatures);
            this.tabControl1.Controls.Add(this.tab_Flora);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(471, 378);
            this.tabControl1.TabIndex = 3;
            // 
            // tab_Creatures
            // 
            this.tab_Creatures.Controls.Add(this.creaturesCtrl);
            this.tab_Creatures.Location = new System.Drawing.Point(4, 22);
            this.tab_Creatures.Name = "tab_Creatures";
            this.tab_Creatures.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Creatures.Size = new System.Drawing.Size(442, 283);
            this.tab_Creatures.TabIndex = 0;
            this.tab_Creatures.Text = "Creatures";
            this.tab_Creatures.UseVisualStyleBackColor = true;
            // 
            // creaturesCtrl
            // 
            this.creaturesCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.creaturesCtrl.Location = new System.Drawing.Point(3, 3);
            this.creaturesCtrl.Name = "creaturesCtrl";
            this.creaturesCtrl.Size = new System.Drawing.Size(436, 277);
            this.creaturesCtrl.TabIndex = 0;
            // 
            // tab_Flora
            // 
            this.tab_Flora.Controls.Add(this.floraCtrl);
            this.tab_Flora.Location = new System.Drawing.Point(4, 22);
            this.tab_Flora.Name = "tab_Flora";
            this.tab_Flora.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Flora.Size = new System.Drawing.Size(442, 283);
            this.tab_Flora.TabIndex = 1;
            this.tab_Flora.Text = "Flora";
            this.tab_Flora.UseVisualStyleBackColor = true;
            // 
            // floraCtrl
            // 
            this.floraCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.floraCtrl.Location = new System.Drawing.Point(3, 3);
            this.floraCtrl.Name = "floraCtrl";
            this.floraCtrl.Size = new System.Drawing.Size(436, 277);
            this.floraCtrl.TabIndex = 0;
            // 
            // tab_World
            // 
            this.tab_World.Controls.Add(this.worldCtrl);
            this.tab_World.Location = new System.Drawing.Point(4, 22);
            this.tab_World.Name = "tab_World";
            this.tab_World.Size = new System.Drawing.Size(463, 352);
            this.tab_World.TabIndex = 2;
            this.tab_World.Text = "World";
            this.tab_World.UseVisualStyleBackColor = true;
            // 
            // worldCtrl
            // 
            this.worldCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.worldCtrl.Location = new System.Drawing.Point(0, 0);
            this.worldCtrl.Name = "worldCtrl";
            this.worldCtrl.Size = new System.Drawing.Size(463, 352);
            this.worldCtrl.TabIndex = 0;
            // 
            // CreateWorld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 418);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CreateWorld";
            this.Text = "CreateWorld";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tab_Creatures.ResumeLayout(false);
            this.tab_Flora.ResumeLayout(false);
            this.tab_World.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button but_OK;
        private System.Windows.Forms.Button but_Cancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_Creatures;
        private System.Windows.Forms.TabPage tab_Flora;
        private System.Windows.Forms.TabPage tab_World;
        private CreaturesCreateWorld creaturesCtrl;
        private FloraCreateWorld floraCtrl;
        private WorldCreateWorld worldCtrl;
    }
}