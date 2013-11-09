namespace EcoSim.UI
{
    partial class WorldView
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
            this.components = new System.ComponentModel.Container();
            this.RefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // RefreshTimer
            // 
            this.RefreshTimer.Interval = 20;
            this.RefreshTimer.Tick += new System.EventHandler(this.RefreshTimer_Tick);
            // 
            // WorldView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Name = "WorldView";
            this.Size = new System.Drawing.Size(250, 125);
            this.Click += new System.EventHandler(this.WorldView_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WorldView_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.WorldView_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.WorldView_KeyUp);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WorldView_MouseMove);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.WorldView_PreviewKeyDown);
            this.Resize += new System.EventHandler(this.WorldView_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer RefreshTimer;
    }
}
