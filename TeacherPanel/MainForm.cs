using System;
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
        }

        private void buttonUnits_Click(object sender, EventArgs e)
        {

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
    }
}
