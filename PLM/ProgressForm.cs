using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLM
{
    public partial class ProgressForm : Form
    {
        public string Message
        {
            set { this.LB_Processing.Text = value; }
        }
        public int ProgressValue
        {
            set { this.PG_form.Value = value; }
        }
        
        public EventHandler stopProgress;

        public ProgressForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            if (stopProgress != null)
            {
                stopProgress(sender, e);
            }
        }
    }
}
