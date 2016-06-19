using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Model;
using System.IO;

namespace TeacherPanel
{
    public partial class QuestionEditer : Form
    {
        private readonly Question _question;

        public QuestionEditer(Question question = null)
        {
            InitializeComponent();

            _question = question ?? new Question { IdTeacher = Teacher.GetAll().First().Id };

            TypeQuestion.GetAll().ForEach(x => comboBoxTypeQuestion.Items.Add(x));
            Unit.GetAll().ForEach(x => comboBoxUnit.Items.Add(x));

            if (comboBoxUnit.Items.Count != 0)
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
                while (((Unit)comboBoxUnit.Items[index]).Id != _question.Unit.Id)
                    index++;
                comboBoxUnit.SelectedIndex = index;

                if (_question.Image.Length != 0)
                {
                    var ms = new MemoryStream(_question.Image);
                    pictureBox.Image = Image.FromStream(ms);
                    ms.Close();
                }
                
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
                        MessageBox.Show(@"Неправильное число ответов", @"Ошибка");
                        return;
                    }
                    break;
                case 1:
                    if (_question.Answers.Count < 2)
                    {
                        MessageBox.Show(@"Неправильное число ответов", @"Ошибка");
                        return;
                    }
                    break;
                case 2:
                    if (_question.Answers.Count < 2)
                    {
                        MessageBox.Show(@"Неправильное число ответов", @"Ошибка");
                        return;
                    }else if (_question.Answers.Where(x => x.TrueAnswer).ToList().Count != 1)
                    {
                        MessageBox.Show(@"Неправильное число верных ответов", @"Ошибка");
                        return;
                    }
                    break;
            }

            if (_question.Image == null) 
                _question.Image = new byte[0];

            _question.Unit = (Unit) comboBoxUnit.SelectedItem;
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

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonAddAnswer_Click(object sender, EventArgs e)
        {
            _question.Type = (TypeQuestion)comboBoxTypeQuestion.SelectedItem;
            _question.Unit = (Unit)comboBoxUnit.SelectedItem;
            var answerEditer = new AnswerEditer(_question);
            var dialogResult = answerEditer.ShowDialog();
            if (dialogResult == DialogResult.OK)
                UpdateAnswers();
        }

        public  void UpdateAnswers()
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
                var answerEditer = new AnswerEditer(_question, _question.Answers[index]);
                var dialogResult = answerEditer.ShowDialog();
                if (dialogResult == DialogResult.OK)
                    UpdateAnswers();
            }
            catch (ArgumentOutOfRangeException )
            {
                MessageBox.Show(@"Выделите нужный ответ!", @"Ошибка");
            }
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog
            {
                InitialDirectory = "C:/Picture/",
                Filter = @"All Files|*.*|JPEGs|*.jpg|Bitmaps|*.bmp|GIFs|*.gif",
                FilterIndex = 2
            };

            if (fileDialog.ShowDialog() != DialogResult.OK)
                return;

            pictureBox.Image = Image.FromFile(fileDialog.FileName);
            if (pictureBox.Image == null)
                return;

            var ms = new MemoryStream();
            pictureBox.Image.Save(ms, pictureBox.Image.RawFormat);
            _question.Image = ms.GetBuffer();
            ms.Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            pictureBox.Image = null;
            _question.Image = null;
        }
    }
}
