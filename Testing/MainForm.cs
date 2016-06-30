using System;
using System.Collections.Generic;
using System.IO;
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
            if (!Init())
                return;

            var currentDirectory = Directory.GetCurrentDirectory();
            var streamReader = new StreamReader(currentDirectory + @"\file\instruction.html");
            webBrowser1.DocumentText = streamReader.ReadToEnd();
            streamReader.Close();
            CenterToScreen();
        }

        private bool Init()
        {
            var login = new Login();
            var dialogResult = login.ShowDialog();
            if (dialogResult != DialogResult.OK)
            {
                Show();
                Close();
                return false;
            }
                
            labelName.Text = @"Здраствуйте, " + Student.LastName + @" " + Student.Name + @"!";
            UpdateList();
            return true;
        }

        public static void LoginStudent(Student student)
        {
            Student = student;
        }

        private void UpdateList()
        {
            _tests = Student.GetTest();
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
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(@"Выбирете контрольную", @"Ошибка");
            }
        }
    }
}
