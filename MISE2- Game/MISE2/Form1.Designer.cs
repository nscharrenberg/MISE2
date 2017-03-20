namespace MISE2
{
    partial class gameFrm
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
            this.gamePic = new System.Windows.Forms.PictureBox();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gamePic)).BeginInit();
            this.SuspendLayout();
            // 
            // gamePic
            // 
            this.gamePic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gamePic.Location = new System.Drawing.Point(0, 0);
            this.gamePic.Name = "gamePic";
            this.gamePic.Size = new System.Drawing.Size(327, 305);
            this.gamePic.TabIndex = 0;
            this.gamePic.TabStop = false;
            this.gamePic.Paint += new System.Windows.Forms.PaintEventHandler(this.gamePic_Paint);
            // 
            // gameTimer
            // 
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // gameFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 305);
            this.Controls.Add(this.gamePic);
            this.Name = "gameFrm";
            this.Text = "MISE2";
            ((System.ComponentModel.ISupportInitialize)(this.gamePic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox gamePic;
        private System.Windows.Forms.Timer gameTimer;
    }
}

