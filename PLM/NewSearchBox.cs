using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace PLM
{
    public partial class NewSearchBox : Form
    {
        private ComboBox SearchComboBox;
        private Button buttonYes;
        private Button buttonNo;
        public string result_search;
        public SUGGEST intsuggestinfo;


        static string URL = ConfigurationSettings.AppSettings["suggestorurl"];
        static string token = ConfigurationSettings.AppSettings["Token"];
        public static string ShowDialog(string text, string caption)
        {
            //Form prompt = new Form()
            //{
            //    Width = 500,
            //    Height = 500,
            //    FormBorderStyle = FormBorderStyle.FixedDialog,
            //    Text = caption,
            //    StartPosition = FormStartPosition.CenterScreen
            //};

            //Button buttonYes = new Button()
            //{
            //    Left = 107
            //    ,Top = 350
            //    ,Width = 100
            //    ,Height = 40
            //    , TabIndex = 0
            //    , Text = "Yes"
            //    , UseVisualStyleBackColor = true
            ////,buttonYes.Click += new System.EventHandler(this.buttonYes_Click);
            //};

            //Button buttonNo = new Button()
            //{
            //    Left = 257
            //    ,
            //    Top = 350
            //    ,
            //    Width = 100
            //    ,
            //    Height = 40                
            //    ,TabIndex = 0
            //    ,Text = "No"
            //    ,UseVisualStyleBackColor = true
            //    //,Click += new System.EventHandler(this.buttonNo_Click)
            // };

            //ComboBox SearchComboBox = new ComboBox() 
            //{ 
            //    DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            //    ,Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)))
            //    ,Location = new System.Drawing.Point(29, 36)
            //    ,Size = new System.Drawing.Size(411, 300)
            //    ,TabIndex = 1
            ////         this.SearchComboBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchComboBox_KeyUp);
            ////this.SearchComboBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SearchComboBox_Click);
            //};
            //prompt.Controls.Add(SearchComboBox);
            //SearchComboBox.Text = text;
            //buttonYes.Click += (sender, e) => { prompt.Close(); };
            //prompt.Controls.Add(buttonYes);
            //buttonNo.Click += (sender, e) => { prompt.Close(); };
            //prompt.Controls.Add(buttonNo);

            //Button buttonYes = new Button()
            //Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            //TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            //Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            //confirmation.Click += (sender, e) => { prompt.Close(); };
            //prompt.Controls.Add(textBox);
            //prompt.Controls.Add(confirmation);
            //prompt.Controls.Add(textLabel);
            //prompt.AcceptButton = confirmation;
             

            using (var NewSearchBox = new NewSearchBox(text, caption))
            {
                NewSearchBox.searchtext(text);
                //NewConfirmBox.Location = new System.Drawing.Point(0, 0);
                return NewSearchBox.ShowDialog() == DialogResult.Yes ? NewSearchBox.SearchComboBox.Text : "";
            }

           
        }

        public NewSearchBox(string title, string message)
        {
            InitializeComponent();
            //TopMost = true;
            //    this.Text = title;
            //    this.textBoxMessage.AppendText(Environment.NewLine);
            //    this.textBoxMessage.AppendText(Environment.NewLine);
            //    this.textBoxMessage.AppendText(message);
            //    //this.textBoxMessage.Text =  message;

            //    this.Deactivate += MyDeactivateHandler;
            //    this.textBoxMessage.ReadOnly = true;
        }

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // NewSearchBox
        //    // 
        //    this.ClientSize = new System.Drawing.Size(484, 461);
        //    this.Name = "NewSearchBox";
        //    this.ResumeLayout(false);

        //}
        private void InitializeComponent()
        {
            this.buttonYes = new System.Windows.Forms.Button();
            this.buttonNo = new System.Windows.Forms.Button();
            this.SearchComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonYes
            // 
            this.buttonYes.Location = new System.Drawing.Point(107, 350);
            this.buttonYes.Name = "buttonYes";
            this.buttonYes.Size = new System.Drawing.Size(100, 40);
            this.buttonYes.TabIndex = 0;
            this.buttonYes.Text = "Yes";
            this.buttonYes.DialogResult = DialogResult.Yes;
            this.buttonYes.UseVisualStyleBackColor = true;
            this.buttonYes.Click += new System.EventHandler(this.buttonYes_Click);
            // 
            // buttonNo
            // 
            this.buttonNo.Location = new System.Drawing.Point(257, 350);
            this.buttonNo.Name = "buttonNo";
            this.buttonNo.Size = new System.Drawing.Size(100, 40);
            this.buttonNo.TabIndex = 0;
            this.buttonNo.Text = "No";
            this.buttonNo.DialogResult = DialogResult.No;
            this.buttonNo.UseVisualStyleBackColor = true;
            this.buttonNo.Click += new System.EventHandler(this.buttonNo_Click);
            // 
            // SearchComboBox
            // 
            this.SearchComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.SearchComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchComboBox.Location = new System.Drawing.Point(29, 36);
            this.SearchComboBox.Name = "SearchComboBox";
            this.SearchComboBox.Size = new System.Drawing.Size(411, 300);
            this.SearchComboBox.TabIndex = 1;
            this.SearchComboBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchComboBox_KeyUp);
            this.SearchComboBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SearchComboBox_Click);
            // 
            // SearchBox
            // 
            this.AcceptButton = this.buttonYes;
            this.ClientSize = new System.Drawing.Size(468, 400);
            this.Controls.Add(this.SearchComboBox);
            this.Controls.Add(this.buttonYes);
            this.Controls.Add(this.buttonNo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchBox";
            this.ShowIcon = false;
            this.TopMost = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.NewMessageBox_Load);
            this.ResumeLayout(false);

        }
        private void SearchComboBox_Click(object sender, EventArgs e)
        {
            result_search = SearchComboBox.Text;
            this.Close();
        }
        private void buttonYes_Click(object sender, EventArgs e)
        {
            result_search = SearchComboBox.Text;
            this.Close();
        }
        private void buttonNo_Click(object sender, EventArgs e)
        {
            result_search = "";
            this.Close();
        }


        protected void MyDeactivateHandler(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SearchComboBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchbybox(this.SearchComboBox.Text);
            }
        }
        private void NewMessageBox_Load(object sender, EventArgs e)
        {

            this.Activate();
        }
        private void searchtext(string textsearch)
        {
            //try
            //{
            this.SearchComboBox.Items.Clear();
            this.SearchComboBox.Items.Add(textsearch);

            String UrlPhP;
            UrlPhP = URL + "suggester/api/v1/suggest";

            WebRequest myRequest = WebRequest.Create(UrlPhP);
            myRequest.ContentType = "application/json";
            myRequest.Method = "POST";
            myRequest.Headers.Add("x-access-token", token);
            using (var streamWriter = new StreamWriter(myRequest.GetRequestStream()))
            {
                //textsearch = "ประยุทธ";
                string json = "{";
                json += "\"input\":\"" + textsearch + "\"";
                json += "}";

                streamWriter.Write(json);
            }
            WebResponse myResponse = myRequest.GetResponse();

            StreamReader sr = new StreamReader(myResponse.GetResponseStream(),
System.Text.Encoding.UTF8);
            string result = sr.ReadToEnd();

            JavaScriptSerializer jss = new JavaScriptSerializer();
            SUGGEST suggestinfo = jss.Deserialize<SUGGEST>(result);


            sr.Close();
            myResponse.Close();

            SearchComboBox.Items.Clear();
            foreach (var suggestinfodata in suggestinfo.result)
            {
                SearchComboBox.Items.Add(suggestinfodata);

            }
            SearchComboBox.Text = textsearch;
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e.Message);
            //}
        }
        private void searchbybox(string textsearch)
        {
            //try
            //{
            this.SearchComboBox.Items.Clear();
            this.SearchComboBox.Items.Add(textsearch);

            String UrlPhP;
            UrlPhP = URL + "suggester/api/v1/suggest";

            WebRequest myRequest = WebRequest.Create(UrlPhP);
            myRequest.ContentType = "application/json";
            myRequest.Method = "POST";
            myRequest.Headers.Add("x-access-token", token);
            using (var streamWriter = new StreamWriter(myRequest.GetRequestStream()))
            {
                //textsearch = "ประยุทธ";
                string json = "{";
                json += "\"input\":\"" + textsearch + "\"";
                json += "}";

                streamWriter.Write(json);
            }
            WebResponse myResponse = myRequest.GetResponse();

            StreamReader sr = new StreamReader(myResponse.GetResponseStream(),
System.Text.Encoding.UTF8);
            string result = sr.ReadToEnd();

            JavaScriptSerializer jss = new JavaScriptSerializer();
            intsuggestinfo = jss.Deserialize<SUGGEST>(result);


            sr.Close();
            myResponse.Close();

            SearchComboBox.Items.Clear();
            foreach (var suggestinfodata in intsuggestinfo.result)
            {
                SearchComboBox.Items.Add(suggestinfodata);

            }
            SearchComboBox.Text = textsearch;
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e.Message);
            //}
        }
    }
}
