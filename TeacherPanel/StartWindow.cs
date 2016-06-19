using System.IO;
using System.Windows.Forms;

namespace TeacherPanel
{
    public partial class StartWindow : Form
    {
        public StartWindow()
        {
            InitializeComponent();
            var currentDirectory = Directory.GetCurrentDirectory();
            var streamReader = new StreamReader(currentDirectory + @"\file\startPage.html");
            webBrowser.DocumentText = streamReader.ReadToEnd();
            streamReader.Close();
            CenterToScreen();
        }
    }
}
