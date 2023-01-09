using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLM
{
    public partial  class NewConfirmBox : Form
    {
        private TextBox textBoxMessage;
        private Button buttonYes;
        private Button buttonNo;

        public static DialogResult ShowDialog(IWin32Window owner, string caption, string text)
        {
            // Setting the DialogResult does not close the form, it just hides it. 
            // This is why I'm disposing it. see the link at the end of my answer for details.
            using (var NewConfirmBox = new NewConfirmBox(caption, text))
            {
                //NewConfirmBox.Location = new System.Drawing.Point(0, 0);
                return NewConfirmBox.ShowDialog(owner);
            }
        }
        public  NewConfirmBox(string caption, string text)
        {
            InitializeComponent();
            this.Text = caption;
            this.textBoxMessage.AppendText(Environment.NewLine);
            this.textBoxMessage.AppendText(Environment.NewLine);
            this.textBoxMessage.AppendText(text);
            //this.textBoxMessage.Text =  message;

            this.Deactivate += MyDeactivateHandler;
            this.textBoxMessage.ReadOnly = true;
        }


        private void InitializeComponent()
        {
            this.buttonYes = new System.Windows.Forms.Button();
            this.buttonNo = new System.Windows.Forms.Button();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonYes
            // 
            this.buttonYes.Location = new System.Drawing.Point(25, 150);
            this.buttonYes.Name = "buttonYes";
            this.buttonYes.Size = new System.Drawing.Size(100, 40);
            this.buttonYes.TabIndex = 0;
            this.buttonYes.Text = "Yes";
            this.buttonYes.UseVisualStyleBackColor = true;
            this.buttonYes.Click += new System.EventHandler(this.buttonYes_Click);
            // 
            // buttonNo
            // 
            this.buttonNo.Location = new System.Drawing.Point(175, 150);
            this.buttonNo.Name = "buttonNo";
            this.buttonNo.Size = new System.Drawing.Size(100, 40);
            this.buttonNo.TabIndex = 0;
            this.buttonNo.Text = "No";
            this.buttonNo.UseVisualStyleBackColor = true;
            this.buttonNo.Click += new System.EventHandler(this.buttonNo_Click);
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Location = new System.Drawing.Point(0, 0);
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.ReadOnly = true;
            this.textBoxMessage.Size = new System.Drawing.Size(300, 150);
            this.textBoxMessage.TabIndex = 1;
            this.textBoxMessage.BorderStyle = BorderStyle.None;
            this.textBoxMessage.TextAlign = HorizontalAlignment.Center;
            this.textBoxMessage.BackColor = System.Drawing.Color.White;


            // 
            // NewMessageBox
            // 
            //this.ClientSize = new System.Drawing.Size(468, 236);
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.buttonYes);
            this.Controls.Add(this.buttonNo);

            this.ShowIcon = false;
            this.Name = "NewMessageBox";
            this.StartPosition =  FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.NewMessageBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        public string message { get; set; }

        private void buttonYes_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
        private void buttonNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        protected void MyDeactivateHandler(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewMessageBox_Load(object sender, EventArgs e)
        {
            
        }
    }
}
