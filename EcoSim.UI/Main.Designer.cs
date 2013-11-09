namespace EcoSim.UI
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupSimulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WorldTimer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.WorldView = new EcoSim.UI.WorldView();
            this.lblAltitude = new System.Windows.Forms.Label();
            this.lbl_frameInfo = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(760, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupSimulationToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // setupSimulationToolStripMenuItem
            // 
            this.setupSimulationToolStripMenuItem.Name = "setupSimulationToolStripMenuItem";
            this.setupSimulationToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.setupSimulationToolStripMenuItem.Text = "Setup Simulation";
            this.setupSimulationToolStripMenuItem.Click += new System.EventHandler(this.setupSimulationToolStripMenuItem_Click);
            // 
            // WorldTimer
            // 
            this.WorldTimer.Tick += new System.EventHandler(this.WorldTimer_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.47369F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.52632F));
            this.tableLayoutPanel1.Controls.Add(this.WorldView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblAltitude, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(760, 447);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // WorldView
            // 
            this.WorldView.AllowNavigation = true;
            this.WorldView.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.WorldView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorldView.Location = new System.Drawing.Point(3, 3);
            this.WorldView.Name = "WorldView";
            this.WorldView.Size = new System.Drawing.Size(597, 441);
            this.WorldView.TabIndex = 1;
            this.WorldView.ViewScale = 1D;
            this.WorldView.XCoordinate = 0;
            this.WorldView.YCoordinate = 0;
            this.WorldView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.WorldView_MouseClick);
            this.WorldView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WorldView_MouseMove);
            // 
            // lblAltitude
            // 
            this.lblAltitude.AutoSize = true;
            this.lblAltitude.Location = new System.Drawing.Point(606, 0);
            this.lblAltitude.Name = "lblAltitude";
            this.lblAltitude.Size = new System.Drawing.Size(42, 13);
            this.lblAltitude.TabIndex = 2;
            this.lblAltitude.Text = "Altitude";
            // 
            // lbl_frameInfo
            // 
            this.lbl_frameInfo.AutoSize = true;
            this.lbl_frameInfo.Location = new System.Drawing.Point(645, 0);
            this.lbl_frameInfo.Name = "lbl_frameInfo";
            this.lbl_frameInfo.Size = new System.Drawing.Size(19, 13);
            this.lbl_frameInfo.TabIndex = 3;
            this.lbl_frameInfo.Text = "----";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 471);
            this.Controls.Add(this.lbl_frameInfo);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupSimulationToolStripMenuItem;
        private System.Windows.Forms.Timer WorldTimer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private WorldView WorldView;
        private System.Windows.Forms.Label lblAltitude;
        private System.Windows.Forms.Label lbl_frameInfo;


    }
}

