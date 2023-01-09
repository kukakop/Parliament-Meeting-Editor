using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Windows.Forms.VisualStyles;

namespace PLM
{
    public class NewMessageBox : Form
    {
        private TextBox textBoxMessage;
        private Button buttonOK;

        public static DialogResult ShowDialog(IWin32Window owner, string title, string message)
        {
            // Setting the DialogResult does not close the form, it just hides it. 
            // This is why I'm disposing it. see the link at the end of my answer for details.
            using (var NewMessageBox = new NewMessageBox(title, message))
            {
                //NewConfirmBox.Location = new System.Drawing.Point(0, 0);
                return NewMessageBox.ShowDialog(owner);
            }
        }

        public NewMessageBox(string title, string message)
        {
            InitializeComponent();
            this.Text = title;
            this.textBoxMessage.AppendText(Environment.NewLine);
            this.textBoxMessage.AppendText(Environment.NewLine);
            this.textBoxMessage.AppendText(message);
            //this.textBoxMessage.Text =  message;

            this.Deactivate += MyDeactivateHandler;
            this.textBoxMessage.ReadOnly = true;
        }


        private void InitializeComponent()
        {
            this.buttonOK = new System.Windows.Forms.Button();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(100, 150);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 40);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
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
            this.textBoxMessage.TextAlign =  HorizontalAlignment.Center;
            this.textBoxMessage.BackColor= System.Drawing.Color.White;


            // 
            // NewMessageBox
            // 
            //this.ClientSize = new System.Drawing.Size(468, 236);
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.buttonOK);
            this.ShowIcon = false;
            this.Name = "NewMessageBox";
            this.Load += new System.EventHandler(this.NewMessageBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        public string message { get; set; }

        private void buttonOK_Click(object sender, EventArgs e)
        {
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
