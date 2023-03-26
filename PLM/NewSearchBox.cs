using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Threading;
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
        public string temp;
        static string URL = ConfigurationSettings.AppSettings["suggestorurl"];
        private ListBox ListSearch;
        private TextBox TxtSearch;
        static string token = ConfigurationSettings.AppSettings["Token"];
        public static string ShowDialog(string text, string caption)
        {


            using (var NewSearchBox = new NewSearchBox(text, caption))
            {
                NewSearchBox.TopMost = true;
                NewSearchBox.TopLevel = true;
                NewSearchBox.searchtext(text);
                //NewConfirmBox.Location = new System.Drawing.Point(0, 0);
                //return NewSearchBox.ShowDialog() == DialogResult.Yes ? NewSearchBox.SearchComboBox.Text : "";
                return NewSearchBox.ShowDialog() == DialogResult.Yes ? NewSearchBox.TxtSearch.Text : "";
            }

           
        }

        public NewSearchBox(string title, string message)
        {
            InitializeComponent();
            TopMost = true;

        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewSearchBox));
            this.buttonYes = new System.Windows.Forms.Button();
            this.buttonNo = new System.Windows.Forms.Button();
            this.SearchComboBox = new System.Windows.Forms.ComboBox();
            this.ListSearch = new System.Windows.Forms.ListBox();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonYes
            // 
            this.buttonYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.buttonYes.Location = new System.Drawing.Point(107, 350);
            this.buttonYes.Name = "buttonYes";
            this.buttonYes.Size = new System.Drawing.Size(100, 40);
            this.buttonYes.TabIndex = 0;
            this.buttonYes.Text = "เลือก";
            this.buttonYes.UseVisualStyleBackColor = true;
            this.buttonYes.Click += new System.EventHandler(this.buttonYes_Click);
            // 
            // buttonNo
            // 
            this.buttonNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.buttonNo.Location = new System.Drawing.Point(257, 350);
            this.buttonNo.Name = "buttonNo";
            this.buttonNo.Size = new System.Drawing.Size(100, 40);
            this.buttonNo.TabIndex = 0;
            this.buttonNo.Text = "ปิด";
            this.buttonNo.UseVisualStyleBackColor = true;
            this.buttonNo.Click += new System.EventHandler(this.buttonNo_Click);
            // 
            // SearchComboBox
            // 
            this.SearchComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.SearchComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchComboBox.Location = new System.Drawing.Point(6, 358);
            this.SearchComboBox.Name = "SearchComboBox";
            this.SearchComboBox.Size = new System.Drawing.Size(95, 45);
            this.SearchComboBox.TabIndex = 1;
            this.SearchComboBox.Visible = false;
            this.SearchComboBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchComboBox_KeyUp);
            // 
            // ListSearch
            // 
            this.ListSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListSearch.FormattingEnabled = true;
            this.ListSearch.ItemHeight = 17;
            this.ListSearch.Location = new System.Drawing.Point(28, 60);
            this.ListSearch.Name = "ListSearch";
            this.ListSearch.Size = new System.Drawing.Size(413, 276);
            this.ListSearch.TabIndex = 2;
            this.ListSearch.Click += new System.EventHandler(this.ListSearch_Click);
            this.ListSearch.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListSearch_MouseDoubleClick);
            // 
            // TxtSearch
            // 
            this.TxtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSearch.Location = new System.Drawing.Point(28, 34);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(413, 23);
            this.TxtSearch.TabIndex = 3;
            this.TxtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtSearch_KeyUp);
            // 
            // NewSearchBox
            // 
            this.AcceptButton = this.buttonYes;
            this.ClientSize = new System.Drawing.Size(468, 400);
            this.Controls.Add(this.TxtSearch);
            this.Controls.Add(this.ListSearch);
            this.Controls.Add(this.SearchComboBox);
            this.Controls.Add(this.buttonYes);
            this.Controls.Add(this.buttonNo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewSearchBox";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "แนะนำรายชื่อ";
            this.Load += new System.EventHandler(this.NewMessageBox_Load);
            this.Shown += new System.EventHandler(this.NewSearchBox_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void SearchComboBox_Click(object sender, EventArgs e)
        {
            result_search = SearchComboBox.Text;
            this.Close();
        }
        private void buttonYes_Click(object sender, EventArgs e)
        {
            result_search = TxtSearch.Text;
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
            this.ListSearch.Items.Clear();
            this.TxtSearch.Text = textsearch;

            //this.SearchComboBox.Items.Clear();
            //this.SearchComboBox.Items.Add(textsearch);
            string searchvalue = textsearch;

            if (searchvalue != "")
            {
                searchvalue = searchvalue.Replace("\b", ""); //Backspace(ascii code 08)
                searchvalue = searchvalue.Replace("\r", ""); //Carriage return
                searchvalue = searchvalue.Replace("\f", ""); //Form feed(ascii code 0C)
                searchvalue = searchvalue.Replace("\n", ""); //New line
                searchvalue = searchvalue.Replace("\t", ""); //Tab
                searchvalue = searchvalue.Replace("\"", ""); //Double quote
                searchvalue = searchvalue.Replace("\'", ""); //Single quote
                searchvalue = searchvalue.Replace("\\", ""); //Backslash
                searchvalue = searchvalue.Replace(" ", ""); //Space
                searchvalue = searchvalue.Replace(System.Environment.NewLine, "");

            }

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
                json += "\"input\":\"" + searchvalue + "\"";
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

            ListSearch.Items.Clear();
            foreach (var suggestinfodata in suggestinfo.result)
            {
                ListSearch.Items.Add(suggestinfodata);

            }
            ListSearch.Text = textsearch;
            //SearchComboBox.Items.Clear();
            //foreach (var suggestinfodata in suggestinfo.result)
            //{
            //    SearchComboBox.Items.Add(suggestinfodata);

            //}
            //SearchComboBox.Text = textsearch;

        }
        private void searchbybox(string textsearch)
        {
            //try
            //{
            this.ListSearch.Items.Clear();
            //this.TxtSearch.Text = textsearch;
            //this.SearchComboBox.Items.Clear();
            //this.SearchComboBox.Items.Add(textsearch);
            string searchvalue = textsearch;

            if (searchvalue != "")
            {
                searchvalue = searchvalue.Replace("\b", ""); //Backspace(ascii code 08)
                searchvalue = searchvalue.Replace("\r", ""); //Carriage return
                searchvalue = searchvalue.Replace("\f", ""); //Form feed(ascii code 0C)
                searchvalue = searchvalue.Replace("\n", ""); //New line
                searchvalue = searchvalue.Replace("\t", ""); //Tab
                searchvalue = searchvalue.Replace("\"", ""); //Double quote
                searchvalue = searchvalue.Replace("\'", ""); //Single quote
                searchvalue = searchvalue.Replace("\\", ""); //Backslash
                searchvalue = searchvalue.Replace(" ", ""); //Space
                searchvalue = searchvalue.Replace(System.Environment.NewLine, "");

            }

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
                json += "\"input\":\"" + searchvalue + "\"";
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

            ListSearch.Items.Clear();
            foreach (var suggestinfodata in intsuggestinfo.result)
            {
                ListSearch.Items.Add(suggestinfodata);

            }
            ListSearch.Text = textsearch;
            //SearchComboBox.Items.Clear();
            //foreach (var suggestinfodata in intsuggestinfo.result)
            //{
            //    SearchComboBox.Items.Add(suggestinfodata);

            //}
            //SearchComboBox.Text = textsearch;
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + e.Message);
            //}
        }

        private void NewSearchBox_Shown(object sender, EventArgs e)
        {
            //TopMost = true;
            //Thread.Sleep(200);
            //TopMost = false;
        }
        private void SearchComboBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            result_search = SearchComboBox.Text;
            this.Close();
        }

        private void ListSearch_Click(object sender, EventArgs e)
        {
            TxtSearch.Text = ListSearch.Text;
        }

        private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {

            //if (e.KeyCode == Keys.Enter)
            //{
                searchbybox(this.TxtSearch.Text);
            //}
        }

        private void ListSearch_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //TxtSearch.Text = ListSearch.Text;
            buttonYes.PerformClick();
        }

       



    }
}
