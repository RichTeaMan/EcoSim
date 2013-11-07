namespace EcoSim.UI
{
    partial class WorldCreateWorld
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.num_Width = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.num_Height = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.chk_WorldWrap = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Height)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.num_Width, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.num_Height, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chk_WorldWrap, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(296, 309);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Width";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // num_Width
            // 
            this.num_Width.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.num_Width.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.num_Width.Location = new System.Drawing.Point(136, 7);
            this.num_Width.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_Width.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.num_Width.Name = "num_Width";
            this.num_Width.Size = new System.Drawing.Size(75, 20);
            this.num_Width.TabIndex = 1;
            this.num_Width.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Height";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // num_Height
            // 
            this.num_Height.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.num_Height.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.num_Height.Location = new System.Drawing.Point(136, 37);
            this.num_Height.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_Height.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.num_Height.Name = "num_Height";
            this.num_Height.Size = new System.Drawing.Size(75, 20);
            this.num_Height.TabIndex = 3;
            this.num_Height.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 30);
            this.label3.TabIndex = 4;
            this.label3.Text = "World Wrap";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chk_WorldWrap
            // 
            this.chk_WorldWrap.AutoSize = true;
            this.chk_WorldWrap.Checked = true;
            this.chk_WorldWrap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_WorldWrap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chk_WorldWrap.Location = new System.Drawing.Point(136, 63);
            this.chk_WorldWrap.Name = "chk_WorldWrap";
            this.chk_WorldWrap.Size = new System.Drawing.Size(75, 24);
            this.chk_WorldWrap.TabIndex = 5;
            this.chk_WorldWrap.UseVisualStyleBackColor = true;
            // 
            // WorldCreateWorld
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "WorldCreateWorld";
            this.Size = new System.Drawing.Size(296, 309);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Height)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown num_Width;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown num_Height;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chk_WorldWrap;
    }
}
