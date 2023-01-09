using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Configuration;

namespace PLM
{
    public class Function
    {
        string URL = ConfigurationSettings.AppSettings["url"];
        //string WorkPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\Partii\";
        string WorkPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\" + ConfigurationSettings.AppSettings["Appname"] + @"\";
        


    }

}
