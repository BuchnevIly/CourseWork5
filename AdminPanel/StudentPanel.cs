using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;

namespace AdminPanel
{
    public partial class StudentPanel : Form
    {
        private List<Student> _students;

        public StudentPanel()
        {
            InitializeComponent();
            comboBoxGroup.Items.Add("Все студенты");
            _students = Student.GetAll();
            Group.GetAll().ForEach(x => comboBoxGroup.Items.Add(x));
            comboBoxGroup.SelectedIndex = 0;
        }

        private void UpdateList()
        {
            listView.Items.Clear();

            if (comboBoxGroup.SelectedIndex == 0)
            {
                _students = Student.GetAll();
            }
            else
            {
                var group = (Group)comboBoxGroup.SelectedItem;
                _students = group.GetStudents();
            }
            
            var j = 0;
            _students.ForEach(x =>
            {
                listView.Items.Add(Convert.ToString(j + 1));
                listView.Items[j].SubItems.Add(x.LastName + " " + x.Name);
                listView.Items[j].SubItems.Add(x.Group.Name);
                j++;
            });

        }

        private void comboBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Group group = null;
            if (comboBoxGroup.SelectedIndex != 0)
                group = (Group)comboBoxGroup.SelectedItem;
            var studentEditer = new StudentEditer(group);
            var dialogResult = studentEditer.ShowDialog();
            if (dialogResult == DialogResult.OK)
                UpdateList();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var student = _students[listView.SelectedIndices[0]];
                student.Delete();
                UpdateList();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(@"Выделите нужного студента!", @"Ошибка");
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            try
            {
                var student = _students[listView.SelectedIndices[0]];
                var studentEditer = new StudentEditer(null, student);
                var dialogResult = studentEditer.ShowDialog();
                if (dialogResult == DialogResult.OK)
                    UpdateList();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(@"Выделите нужного студента!", @"Ошибка");
            }
        }
    }
}
