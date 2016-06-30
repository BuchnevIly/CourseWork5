using System.IO;
using System.Windows.Forms;

namespace TeacherPanel
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            var login = new Login();
            var result = login.ShowDialog();
            CenterToScreen();
            if (result != DialogResult.OK)
                Close();

            var currentDirectory = Directory.GetCurrentDirectory();
            var streamReader = new StreamReader(currentDirectory + @"\file\instruction.html");
            webBrowser1.DocumentText = streamReader.ReadToEnd();
            streamReader.Close();
            CenterToScreen();

        }

        private void linkLabelUnit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var unitPanel = new UnitPanel();
            unitPanel.ShowDialog();
        }

        private void linkLabelAddNewUnit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var addNewUnit = new UnitEditer();
            addNewUnit.ShowDialog();
        }

        private void linkLabelQuestion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var question = new QuestionsPanel();
            question.ShowDialog();
        }

        private void linkLabelAddNewQuestion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var questionEditer = new QuestionEditer();
            questionEditer.ShowDialog();
        }

        private void linkLabelTest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var testPanel = new TestPanel();
            testPanel.ShowDialog();
        }

        private void linkLabelStatistic_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var statistic = new Statistic();
            statistic.ShowDialog();
        }

        private void linkLabelAddTest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var testEditer = new TestEditer();
            testEditer.ShowDialog();
        }

        private void linkLabelResult_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var result = new Result();
            result.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
