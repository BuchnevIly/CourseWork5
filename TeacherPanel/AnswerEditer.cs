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
    public partial class AnswerEditer : Form
    {
        private readonly QuestionEditer _questionEditer;

        private List<Answer> _answers;

        private Answer _answer;

        public AnswerEditer(Question question, Form parentForm, Answer answer = null)
        {
            InitializeComponent();

            _questionEditer = (QuestionEditer)parentForm;
            _answers = question.Answers;

            _answer = answer ?? new Answer();

            checkBoxTrueAnswer.DataBindings.Add("Checked", _answer, "TrueAnswer");
            textBoxAnswer.DataBindings.Add("Text", _answer, "TextAnswer");

            if (question.Type.Id != 3)
                return;

            checkBoxTrueAnswer.Checked = true;
            checkBoxTrueAnswer.Enabled = false;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (_answer.Id == 0)
                _answers.Add(_answer);
            _questionEditer.UpdateAnswers();
            Close();
        }
    }
}
