using System.Windows.Forms;

namespace AdminPanel
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void linkLabelGroup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var groupPanel = new GroupPanel();
            groupPanel.ShowDialog();
        }

        private void linkLabelAddGroup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var groupEditer = new GroupEditer();
            groupEditer.ShowDialog();
        }

        private void linkLabelStudent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var studentPanel = new StudentPanel();
            studentPanel.ShowDialog();
        }

        private void linkLabelAddStudent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var studentEditer = new StudentEditer();
            studentEditer.ShowDialog();
        }
    }
}
