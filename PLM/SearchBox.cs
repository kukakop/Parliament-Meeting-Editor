using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace PLM
{
    public partial class SearchBox : Form
    {
        private ComboBox SearchComboBox;
        private Button buttonYes;
        private Button buttonNo;
        public string result_search;
        public SUGGEST intsuggestinfo;

        string URL = ConfigurationSettings.AppSettings["suggestorurl"];
        string token = ConfigurationSettings.AppSettings["Token"];


        //public static DialogResult ShowDialog(IWin32Window owner, string textsearch, SUGGEST suggestinfo)
        //{
        //    // Setting the DialogResult does not close the form, it just hides it. 
        //    // This is why I'm disposing it. see the link at the end of my answer for details.
        //    //using (var SearchBox = new SearchBox(textsearch))
        //    //{
        //    //    //NewConfirmBox.Location = new System.Drawing.Point(0, 0);
        //    //    return SearchBox.ShowDialog(owner).ToString();
        //    //}
        //    using (var SearchBox = new SearchBox(textsearch, suggestinfo))
        //    {
        //        //NewConfirmBox.Location = new System.Drawing.Point(0, 0);
        //        return SearchBox.ShowDialog(owner);
        //    }

        //}

        public SearchBox(string textsearch,SUGGEST suggestinfo)
        {
            InitializeComponent();
            TopMost = true;
            this.Text = "การแนะนำรายชื่อ";
            searchtext(textsearch, suggestinfo);

            //this.Deactivate += MyDeactivateHandler;


        }
        public void BoxOwner(Form SOwner)
        {
            this.Owner = SOwner;
        }
        private void searchtext(string textsearch, SUGGEST suggestinfo)
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
                suggestinfo = jss.Deserialize<SUGGEST>(result);


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
            this.Load += new System.EventHandler(this.NewMessageBox_Load);
            this.ResumeLayout(false);

        }


        public string message { get; set; }

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

        private void SearchComboBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchbybox(this.SearchComboBox.Text);
            }
        }
        protected void MyDeactivateHandler(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewMessageBox_Load(object sender, EventArgs e)
        {

            this.Activate();
        }
    }
}
