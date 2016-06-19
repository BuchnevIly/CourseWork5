using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;

namespace TeacherPanel
{
    public partial class AnswerEditer : Form
    {

        private readonly List<Answer> _answers;

        private readonly Answer _answer;

        public AnswerEditer(Question question,  Answer answer = null)
        {
            InitializeComponent();

            _answers = question.Answers;
            _answer = answer ?? new Answer();

            checkBoxTrueAnswer.DataBindings.Add("Checked", _answer, "TrueAnswer");
            textBoxAnswer.DataBindings.Add("Text", _answer, "TextAnswer");

            if (question.Type.Id != 3)
                return;

            _answer.TrueAnswer = true;
            checkBoxTrueAnswer.Enabled = false;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (_answer.Id == 0)
                _answers.Add(_answer);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
