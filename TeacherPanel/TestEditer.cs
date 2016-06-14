﻿using System;
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
    public partial class TestEditer : Form
    {
        private readonly List<Question> _allQuestions;

        private readonly List<Question> _testQuestions;

        private TestPanel _parentForm;

        private Test _test;

        public TestEditer(Form parentForm = null, Test test = null)
        {
            InitializeComponent();

            _allQuestions = Question.GetAll();

            _parentForm = (TestPanel)parentForm;

            if (test != null)
            {
                textBoxName.Text = test.Name;
                timePickerStart.Value = test.TestData;
                datePickerStart.Value = test.TestData; timePickerStart.Value = test.TestData;
                test.TestQuestions.ForEach(x => _testQuestions.Add(x.Question));
                _testQuestions.ForEach(x =>
                {
                    var index =_allQuestions.FindIndex((y) => y.Id == x.Id);
                    _allQuestions.RemoveAt(index);
                });
                UpdateLists();
                return;
            }

            _testQuestions = new List<Question>();
            UpdateLists();

        }

        public void UpdateLists()
        {
            _allQuestions.Sort((x, y) => x.IdUnit.CompareTo(y.IdUnit));
            _testQuestions.Sort((x, y) => x.IdUnit.CompareTo(y.IdUnit));

            listViewAllQueston.Items.Clear();
            var i = 0;
            _allQuestions.ForEach(x =>
            {
                listViewAllQueston.Items.Add(Convert.ToString(i + 1));
                listViewAllQueston.Items[i].SubItems.Add(x.TextQuestion);

                var unit = new Unit {Id = x.IdUnit};
                unit.Load();

                listViewAllQueston.Items[i].SubItems.Add(unit.Name);
                listViewAllQueston.Items[i].SubItems.Add(x.Type.Name);
                i++;
            });

            listViewTestQuestion.Items.Clear();
            i = 0;
            _testQuestions.ForEach(x =>
            {
                listViewTestQuestion.Items.Add(Convert.ToString(i + 1));
                listViewTestQuestion.Items[i].SubItems.Add(x.TextQuestion);

                var unit = new Unit { Id = x.IdUnit };
                unit.Load();

                listViewTestQuestion.Items[i].SubItems.Add(unit.Name);
                listViewTestQuestion.Items[i].SubItems.Add(x.Type.Name);
                i++;
            });
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                for (var i = listViewAllQueston.SelectedIndices.Count - 1; i >= 0; i--)
                    _testQuestions.Add(_allQuestions[listViewAllQueston.SelectedIndices[i]]);

                for (var i = listViewAllQueston.SelectedIndices.Count - 1; i >= 0; i--)
                    _allQuestions.RemoveAt(listViewAllQueston.SelectedIndices[i]);
            }
            catch (Exception)
            {
                MessageBox.Show("Выделите нужный вапрос!", "Ошибка");
            }
            UpdateLists();
        }

        private void OpenQuestion(ListView listView, IReadOnlyList<Question> questions)
        {
            try
            {
                var question = questions[listView.SelectedIndices[0]];
                var questionEditer = new QuestionEditer(question);
                questionEditer.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Выделите нужный вапрос!", "Ошибка");
            }
        }

        private void buttonOpenFromAllQuestion_Click(object sender, EventArgs e)
        {
            OpenQuestion(listViewAllQueston, _allQuestions);
        }

        private void buttonOpenFromTestQuestion_Click(object sender, EventArgs e)
        {
            OpenQuestion(listViewTestQuestion, _testQuestions);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "")
            {
                MessageBox.Show("Ошибка", "Поле с названием не должно быть пустым!");
                return;
            }

            if (_testQuestions.Count == 0)
            {
                MessageBox.Show("Ошибка", "В контрольой не могут отсутствовать вопросы!");
                return;
            }

            var startDateTime = new DateTime(datePickerStart.Value.Year, datePickerStart.Value.Month,
                datePickerStart.Value.Day, timePickerStart.Value.Hour, timePickerStart.Value.Minute,
                timePickerStart.Value.Second);

            var endDateTime = new DateTime(datePickerEnd.Value.Year, datePickerEnd.Value.Month,
                datePickerEnd.Value.Day, timePickerEnd.Value.Hour, timePickerEnd.Value.Minute,
                timePickerEnd.Value.Second);

            if (startDateTime >= endDateTime)
            {
                MessageBox.Show("Ошибка", "Начальная дата должна быть меньше конечной!");
                return;
            }

            var test = new Test {Name = textBoxName.Text, TestData = startDateTime};
            test.Save();

            _testQuestions.ForEach(x =>
            {
                var testQuestion = new TestQuestion
                {
                    IdTeacher = 1,
                    IdTest = test.Id,
                    Question = x
                };

                testQuestion.Save();
            });

            _parentForm.UpdateList();
        }

        private void buttonSetCurrentTime_Click(object sender, EventArgs e)
        {
            timePickerStart.Value = DateTime.Now;
            timePickerEnd.Value = DateTime.Now.AddHours(1);

            datePickerStart.Value = DateTime.Now;
            datePickerEnd.Value = DateTime.Now;
        }
    }
}