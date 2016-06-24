using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace AdminPanel
{
    public partial class TeachersPanel : Form
    {
        private List<Teacher> _teachers;

        public TeachersPanel()
        {
            InitializeComponent();
            UpdateList();
        }

        private void UpdateList()
        {
            _teachers = Teacher.GetAll();
            listView.Items.Clear();

            var i = 0;
            _teachers.ForEach(x =>
            {
                listView.Items.Add(Convert.ToString(i + 1));
                listView.Items[i].SubItems.Add(x.Name + " " + x.LastName);
                i++;
            });
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var teacher = _teachers[listView.SelectedIndices[0]];
                teacher.Delete();
                UpdateList();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(@"Выделите нужного преподавателя!", @"Ошибка");
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            try
            {
                var teacher = _teachers[listView.SelectedIndices[0]];
                var teacherEditer = new TeacherEditer(teacher);
                var dialogResult = teacherEditer.ShowDialog();
                if (dialogResult == DialogResult.OK)
                    UpdateList();
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show(@"Выделите нужного преподвтеля", @"Ошибка");
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var teacherEditer = new TeacherEditer();
            var dialogResult = teacherEditer.ShowDialog();
            if (dialogResult == DialogResult.OK)
                UpdateList();
        }
    }
}
