namespace EcoSim.UI
{
    partial class CreaturesCreateWorld
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
            this.label2 = new System.Windows.Forms.Label();
            this.num_StartPopulation = new System.Windows.Forms.NumericUpDown();
            this.num_MaxPopulation = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_StartPopulation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_MaxPopulation)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.5042F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.4958F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.num_StartPopulation, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.num_MaxPopulation, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(297, 309);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start Population";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Maximum Population";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // num_StartPopulation
            // 
            this.num_StartPopulation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.num_StartPopulation.Location = new System.Drawing.Point(146, 7);
            this.num_StartPopulation.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_StartPopulation.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_StartPopulation.Name = "num_StartPopulation";
            this.num_StartPopulation.Size = new System.Drawing.Size(88, 20);
            this.num_StartPopulation.TabIndex = 2;
            this.num_StartPopulation.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // num_MaxPopulation
            // 
            this.num_MaxPopulation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.num_MaxPopulation.Location = new System.Drawing.Point(146, 37);
            this.num_MaxPopulation.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_MaxPopulation.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_MaxPopulation.Name = "num_MaxPopulation";
            this.num_MaxPopulation.Size = new System.Drawing.Size(88, 20);
            this.num_MaxPopulation.TabIndex = 3;
            this.num_MaxPopulation.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // CreaturesCreateWorld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CreaturesCreateWorld";
            this.Size = new System.Drawing.Size(297, 309);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_StartPopulation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_MaxPopulation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown num_StartPopulation;
        private System.Windows.Forms.NumericUpDown num_MaxPopulation;
    }
}
