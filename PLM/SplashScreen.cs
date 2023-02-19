using Microsoft.Office.Interop.Word;
using System.Configuration;
using System.Windows.Forms;

namespace PLM
{
    public partial class SplashScreen : Form
    {

        string Apptitle = ConfigurationSettings.AppSettings["Apptitle"];
        public SplashScreen()
        {
            TopMost = true;
            InitializeComponent();
            this.Text = Apptitle;
        }

        private void SplashScreen_Load(object sender, System.EventArgs e)
        {
            FormMain formMain = new FormMain(this);
            formMain.Show();
        }
    }
}
