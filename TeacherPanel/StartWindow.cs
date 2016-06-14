using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeacherPanel
{
    public partial class StartWindow : Form
    {
        public StartWindow()
        {
            InitializeComponent();
            string currentDirectory = Directory.GetCurrentDirectory();
            StreamReader streamReader = new StreamReader(currentDirectory + "\\file\\startPage.html");
            webBrowser.DocumentText = streamReader.ReadToEnd();
            streamReader.Close();

            CenterToScreen();
        }
    }
}
