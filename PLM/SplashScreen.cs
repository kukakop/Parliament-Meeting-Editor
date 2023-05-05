using Microsoft.Office.Interop.Word;
using System;
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

        private void progressBar1_Click(object sender, System.EventArgs e)
        {

        }
        public void Progress(decimal perc)
        {
           decimal perc_Dec = (perc / 100);
           decimal Width_dec = PG_Panel_Back.Width;
           decimal Run_Dec = Width_dec * perc_Dec;
           Run_Dec = Math.Round(Run_Dec, 0);
            PG_Panel_Run.Width = int.Parse(Run_Dec.ToString());

        }

        public void ProgressRun(decimal perc)
        {
            decimal perc_Dec = (perc / 100);
            decimal Width_dec = PG_Panel_Back.Width;
            decimal Run_Dec = Width_dec * perc_Dec;
            Run_Dec = Math.Round(Run_Dec, 0);
            //PG_Panel_Run.Width = int.Parse(Run_Dec.ToString());

        }
    }
}
