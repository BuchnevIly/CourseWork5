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

namespace TeacherPanel
{
    public partial class Result : Form
    {
        private List<StudentsAnswer> _answers;

        public Result()
        {
            InitializeComponent();

            _answers = StudentsAnswer.GetAll();

            Test.GetAll().ForEach(x => comboBox.Items.Add(x));
            comboBox.SelectedIndex = 0;

            ShowResult();
        }

        private void ShowResult()
        {
            var test = (Test)comboBox.SelectedItem;
            var students = _answers.Select(x => x.Student.Id).Distinct().ToList();
            var i = 0;

            listView.Items.Clear();

            students.ForEach(y =>
            {
                var a = _answers.Where(x => x.Student.Id == y && x.TestQuestion.IdTest == test.Id).Count(x => x.IsTrue);
                var b = _answers.Count(x => x.Student.Id == y && x.TestQuestion.IdTest == test.Id);
                listView.Items.Add(Convert.ToString(i + 1));

                var student = new Student {Id = y};
                student.Load();

                listView.Items[i].SubItems.Add(student.Name + " " + student.LastName);
                listView.Items[i].SubItems.Add(a + " из " + b);
                i++;
            });
            
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowResult();
        }
    }
}
