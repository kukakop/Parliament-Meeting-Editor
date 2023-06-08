namespace PLM
{
    partial class SplashScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            this.ScreenShot = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.PG_Panel_Run = new System.Windows.Forms.Panel();
            this.PG_Panel_Back = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ScreenShot)).BeginInit();
            this.SuspendLayout();
            // 
            // ScreenShot
            // 
            this.ScreenShot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScreenShot.Image = ((System.Drawing.Image)(resources.GetObject("ScreenShot.Image")));
            this.ScreenShot.InitialImage = ((System.Drawing.Image)(resources.GetObject("ScreenShot.InitialImage")));
            this.ScreenShot.Location = new System.Drawing.Point(0, 0);
            this.ScreenShot.Name = "ScreenShot";
            this.ScreenShot.Size = new System.Drawing.Size(800, 450);
            this.ScreenShot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ScreenShot.TabIndex = 3;
            this.ScreenShot.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(24, 397);
            this.progressBar1.MarqueeAnimationSpeed = 50;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(764, 29);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 4;
            this.progressBar1.Visible = false;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Kanit", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.LightCoral;
            this.label1.Location = new System.Drawing.Point(320, 363);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 33);
            this.label1.TabIndex = 5;
            this.label1.Text = "กำลังเปิดโปรแกรม";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PG_Panel_Run
            // 
            this.PG_Panel_Run.BackColor = System.Drawing.Color.SpringGreen;
            this.PG_Panel_Run.Location = new System.Drawing.Point(0, 432);
            this.PG_Panel_Run.Name = "PG_Panel_Run";
            this.PG_Panel_Run.Size = new System.Drawing.Size(23, 18);
            this.PG_Panel_Run.TabIndex = 6;
            // 
            // PG_Panel_Back
            // 
            this.PG_Panel_Back.Location = new System.Drawing.Point(-26, 432);
            this.PG_Panel_Back.Name = "PG_Panel_Back";
            this.PG_Panel_Back.Size = new System.Drawing.Size(826, 18);
            this.PG_Panel_Back.TabIndex = 7;
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.PG_Panel_Run);
            this.Controls.Add(this.PG_Panel_Back);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.ScreenShot);
            this.Name = "SplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreen";
            this.Load += new System.EventHandler(this.SplashScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ScreenShot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ScreenShot;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PG_Panel_Run;
        private System.Windows.Forms.Panel PG_Panel_Back;
    }
}