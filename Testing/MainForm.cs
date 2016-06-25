using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;

namespace Testing
{
    public partial class MainForm : Form
    {
        public static Student Student;

        private List<Test> _tests;

        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            var login = new Login();
            var dialogResult = login.ShowDialog();
            if (dialogResult != DialogResult.OK)
            {
                Close();
                return;
            }
                
            _tests = Student.GetTest();
            labelName.Text = @"Здраствуйте, " + Student.LastName + @" " + Student.Name + @"!";
            UpdateList();
        }

        public static void LoginStudent(Student student)
        {
            Student = student;
        }

        private void UpdateList()
        {
            listView.Items.Clear();
            var i = 0;
            _tests.ForEach(x =>
            {
                listView.Items.Add(Convert.ToString(i + 1));
                listView.Items[i].SubItems.Add(x.Name);
                i++;
            });
        }

        private void linkLabelLogOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            Init();
            Show();
        }

        private void linkLabelChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var changePassword = new ChangePassword();
            changePassword.ShowDialog();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            try
            {
                var test = _tests[listView.SelectedIndices[0]];
                var testing = new Testing(test);
                testing.ShowDialog();
                UpdateList();
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show(@"Выбирете контрольную", @"Ошибка");
            }
        }
    }
}
