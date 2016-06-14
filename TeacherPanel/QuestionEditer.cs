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
    public partial class QuestionEditer : Form
    {
        private Question _question;

        private QuestionsPanel _parentForm;

        public QuestionEditer(Question question = null, Form parentForm = null)
        {
            InitializeComponent();
            _parentForm = (QuestionsPanel)parentForm;
            _question = question ?? new Question { IdTeacher = Teacher.GetAll().First().Id };

            TypeQuestion.GetAll().ForEach(x => comboBoxTypeQuestion.Items.Add(x));
            Unit.GetAll().ForEach(x => comboBoxUnit.Items.Add(x));

            comboBoxUnit.SelectedIndex = 0;
            comboBoxTypeQuestion.SelectedIndex = 0;

            if (question != null)
            {
                _question = question;
                var index = 0;
                while (((TypeQuestion)comboBoxTypeQuestion.Items[index]).Id != _question.Type.Id)
                    index++;
                comboBoxTypeQuestion.SelectedIndex = index;

                index = 0;
                while (((Unit)comboBoxUnit.Items[index]).Id != _question.IdUnit)
                    index++;
                comboBoxUnit.SelectedIndex = index;
            }

            textBoxQuestion.DataBindings.Add("Text", _question, "TextQuestion");
            comboBoxTypeQuestion.DataBindings.Add("SelectedItem", _question, "Type");



            UpdateAnswers();
        }

        private void buttonSaveQuestion_Click(object sender, EventArgs e)
        {
            switch (comboBoxTypeQuestion.SelectedIndex)
            {
                case 0:
                    if (_question.Answers.Count != 1)
                    {
                        MessageBox.Show("Неправильное число ответов", "Ошибка");
                        return;
                    }
                    break;
                case 1:
                    if (_question.Answers.Count < 2)
                    {
                        MessageBox.Show("Неправильное число ответов", "Ошибка");
                        return;
                    }
                    break;
                case 2:
                    if (_question.Answers.Count < 2)
                    {
                        MessageBox.Show("Неправильное число ответов", "Ошибка");
                        return;
                    }else if (_question.Answers.Where(x => x.TrueAnswer == true).ToList().Count != 1)
                    {
                        MessageBox.Show("Неправильное число верных ответов", "Ошибка");
                        return;
                    }
                    break;
            }

            _question.IdUnit = ((Unit) comboBoxUnit.SelectedItem).Id;
            if (_question.Id == 0)
            {
                _question.Save();
                _question.Answers.ForEach(x =>
                {
                    x.IdQuestion = _question.Id;
                    x.Save();
                });
            }
            else
            {
                _question.Update();
                _question.Answers.ForEach(x =>
                {
                    x.IdQuestion = _question.Id;
                    if (x.Id == 0) x.Save();
                    else x.Update();
                });
            }

            _parentForm?.UpdateList();
            Close();
        }

        private void buttonAddAnswer_Click(object sender, EventArgs e)
        {
            
            var answerEditer = new AnswerEditer(_question, this);
            answerEditer.ShowDialog();
        }

        public void UpdateAnswers()
        {
            listView1.Items.Clear();
            var i = 0;
            _question.Answers.ForEach(x =>
            {
                listView1.Items.Add(Convert.ToString(i + 1));
                listView1.Items[i].SubItems.Add(x.TextAnswer);
                listView1.Items[i].SubItems.Add(x.TrueAnswer ? "+": "-");
                i++;
            });
        }

        private void buttonAnswerChange_Click(object sender, EventArgs e)
        {
            try
            {
                var index = listView1.SelectedIndices[0];
                var answerEditer = new AnswerEditer(_question, this, _question.Answers[index]);
                answerEditer.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Выделите нужный ответ!", "Ошибка");
            }
        }
    }
}
