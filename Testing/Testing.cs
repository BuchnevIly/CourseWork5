using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace Testing
{
    public partial class Testing : Form
    {
        private readonly Test _test;

        private readonly List<TestQuestion> _testQuestions;

        private List<Answer> _answers;

        private readonly Random _random;

        private int _currentQuestion;

        public Testing(Test test)
        {
            InitializeComponent();

            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;

            _test = test;
            _random = new Random(DateTime.Now.Millisecond);
            _testQuestions = _test.GetTestQuestions().OrderBy(x => _random.Next()).ToList();

            SetQuestion(_testQuestions[0].Question);
        }

        private void SetQuestion(Question question)
        {
            textBoxQuesion.Text = question.TextQuestion;

            if (question.Image.Length != 0)
            {
                var ms = new MemoryStream(question.Image);
                pictureBox.Image = Image.FromStream(ms);
                ms.Close();
            }
            _answers = question.Answers.OrderBy(x => _random.Next()).ToList();
            var i = 0;

            switch (question.Type.Id)
            {
                case 1:
                    tabControl.SelectedTab = tabPage1;
                    listView.Items.Clear();
                    _answers.ForEach(x =>
                    {
                        listView.Items.Add("*");
                        listView.Items[i].SubItems.Add(x.TextAnswer);
                        i++;
                    });
                    break;
                case 2:
                    tabControl.SelectedTab = tabPage2;
                    checkedListBox1.Items.Clear();
                    _answers.ForEach(x => checkedListBox1.Items.Add(x.TextAnswer));
                    break;
                case 3:
                    tabControl.SelectedTab = tabPage2;
                    break;
            }
        }

        private void buttonAnswer_Click(object sender, EventArgs e)
        {
            var isTrue = false;
            switch (_testQuestions[_currentQuestion].Question.Type.Id)
            {
                case 1:
                    if (listView.SelectedItems.Count == 0)
                        return;

                    isTrue = _answers[listView.SelectedIndices[0]].TrueAnswer;
                    break;
                case 2:
                    isTrue = true;
                    if (checkedListBox1.CheckedIndices.Count != _answers.Count(x => x.TrueAnswer))
                        isTrue = false;
                    else
                        foreach (int checkedIndex in checkedListBox1.CheckedIndices)
                            if (!_answers[checkedIndex].TrueAnswer)
                                isTrue = false;
                    break;
                case 3:
                    isTrue = false;
                    break;
            }

            var studentsAnswer = new StudentsAnswer
            {
                Student = MainForm.Student,
                TestQuestion = _testQuestions[_currentQuestion],
                IsTrue = isTrue
            };

            studentsAnswer.Save();

            _currentQuestion++;
            if (_currentQuestion < _testQuestions.Count)
                SetQuestion(_testQuestions[_currentQuestion].Question);
            else
            {
                var studentsAnswers = StudentsAnswer.GetAll()
                    .Where(x => x.Student.Id == MainForm.Student.Id && x.TestQuestion.IdTest == _test.Id)
                    .ToList();

                MessageBox.Show(@"Ваш результат: " + studentsAnswers.Count(x => x.IsTrue) + @" из " + studentsAnswers.Count, @"Результат");
                Close();
            }
        }
    }
}
