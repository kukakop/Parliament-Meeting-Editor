namespace PLM
{
    partial class ProgressForm
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
            this.PG_form = new System.Windows.Forms.ProgressBar();
            this.LB_Processing = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PG_form
            // 
            this.PG_form.Location = new System.Drawing.Point(64, 41);
            this.PG_form.Name = "PG_form";
            this.PG_form.Size = new System.Drawing.Size(342, 36);
            this.PG_form.TabIndex = 0;
            // 
            // LB_Processing
            // 
            this.LB_Processing.AutoSize = true;
            this.LB_Processing.Location = new System.Drawing.Point(211, 54);
            this.LB_Processing.Name = "LB_Processing";
            this.LB_Processing.Size = new System.Drawing.Size(72, 13);
            this.LB_Processing.TabIndex = 1;
            this.LB_Processing.Text = "กำลังทำงาน .. ";
            this.LB_Processing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(192, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(456, 132);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LB_Processing);
            this.Controls.Add(this.PG_form);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgressForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "บันทึกข้อมูล";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar PG_form;
        private System.Windows.Forms.Label LB_Processing;
        private System.Windows.Forms.Button button1;
    }
}