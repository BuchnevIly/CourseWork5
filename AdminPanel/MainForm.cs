using System.Windows.Forms;

namespace AdminPanel
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            var login = new Login();
            var dialogResult = login.ShowDialog();
            if (dialogResult != DialogResult.OK)
                Close();
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

        private void linkLabeTeacher_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var teachersPanel = new TeachersPanel();
            teachersPanel.ShowDialog();
        }

        private void linkLabelAddTeacher_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var teacherEditer = new TeacherEditer();
            teacherEditer.ShowDialog();
        }

        private void linkLabelChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var changePassword = new ChangePassword();
            changePassword.ShowDialog();
        }
    }
}
