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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.num_Height = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.chk_WorldWrap = new System.Windows.Forms.CheckBox();
            this.num_Width = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.worldFormerList = new System.Windows.Forms.ListView();
            this.formerOptions = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.num_Height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Width)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Width";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Height";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // num_Height
            // 
            this.num_Height.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.num_Height.Location = new System.Drawing.Point(107, 33);
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
            this.label3.Location = new System.Drawing.Point(3, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "World Wrap";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chk_WorldWrap
            // 
            this.chk_WorldWrap.AutoSize = true;
            this.chk_WorldWrap.Checked = true;
            this.chk_WorldWrap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_WorldWrap.Location = new System.Drawing.Point(107, 63);
            this.chk_WorldWrap.Name = "chk_WorldWrap";
            this.chk_WorldWrap.Size = new System.Drawing.Size(15, 14);
            this.chk_WorldWrap.TabIndex = 5;
            this.chk_WorldWrap.UseVisualStyleBackColor = true;
            // 
            // num_Width
            // 
            this.num_Width.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.num_Width.Location = new System.Drawing.Point(107, 3);
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
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.23426F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.76574F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(500, 397);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(494, 118);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "World Options";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.31148F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.68852F));
            this.tableLayoutPanel3.Controls.Add(this.chk_WorldWrap, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.num_Width, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.num_Height, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(488, 99);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 127);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(494, 267);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Generation Options";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.worldFormerList, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.formerOptions, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(488, 248);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // worldFormerList
            // 
            this.worldFormerList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.worldFormerList.Location = new System.Drawing.Point(3, 3);
            this.worldFormerList.MultiSelect = false;
            this.worldFormerList.Name = "worldFormerList";
            this.worldFormerList.Size = new System.Drawing.Size(144, 242);
            this.worldFormerList.TabIndex = 0;
            this.worldFormerList.UseCompatibleStateImageBehavior = false;
            this.worldFormerList.View = System.Windows.Forms.View.List;
            this.worldFormerList.SelectedIndexChanged += new System.EventHandler(this.worldFormerList_SelectedIndexChanged);
            // 
            // formerOptions
            // 
            this.formerOptions.AutoScroll = true;
            this.formerOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formerOptions.Location = new System.Drawing.Point(153, 3);
            this.formerOptions.Name = "formerOptions";
            this.formerOptions.Size = new System.Drawing.Size(332, 242);
            this.formerOptions.TabIndex = 1;
            // 
            // WorldCreateWorld
            // 
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "WorldCreateWorld";
            this.Size = new System.Drawing.Size(500, 397);
            ((System.ComponentModel.ISupportInitialize)(this.num_Height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Width)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown num_Width;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown num_Height;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chk_WorldWrap;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView worldFormerList;
        private System.Windows.Forms.Panel formerOptions;
    }
}
