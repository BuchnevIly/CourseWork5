using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Model;

namespace TeacherPanel
{
    public partial class QuestionsPanel : Form
    {
        private List<Question> _questions;

        public QuestionsPanel(Unit unit = null)
        {
            InitializeComponent();

            TypeQuestion.GetAll().ForEach(x => comboBoxQuestionType.Items.Add(x));
            Unit.GetAll().ForEach(x => comboBoxUnit.Items.Add(x));

            comboBoxQuestionType.SelectedIndex = 0;

            if (comboBoxUnit.Items.Count != 0) 
                comboBoxUnit.SelectedIndex = 0;

            if (unit == null)
                return;

            var index = 0;
            for (var i = 0; i < comboBoxUnit.Items.Count; i++)
                if (((Unit)comboBoxUnit.Items[i]).Id == unit.Id)
                    index = i;

            comboBoxUnit.SelectedIndex = index;
            UpdateList();

        }

        public void UpdateList()
        {
            listView1.Items.Clear();

            if (comboBoxUnit.SelectedItem == null) return;
            var selectedUnit = ((Unit) comboBoxUnit.SelectedItem).Id;
            var selectedType = ((TypeQuestion) comboBoxQuestionType.SelectedItem).Id;

            _questions = Question.GetAll()
                .Where(x => x.Unit.Id == selectedUnit && x.Type.Id == selectedType).ToList();


            var i = 0;
            foreach (var item in _questions)
            {
                listView1.Items.Add(Convert.ToString(i + 1));
                listView1.Items[i].SubItems.Add(item.TextQuestion);
                var unit = new Unit {Id = item.Unit.Id};
                unit.Load();
                listView1.Items[i].SubItems.Add(unit.Name);
                listView1.Items[i].SubItems.Add(item.Type.Name);
                i++;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var questionEditer = new QuestionEditer();
            var dialogResult = questionEditer.ShowDialog();
            if (dialogResult == DialogResult.OK)
                UpdateList();
        }

        private void comboBoxUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void comboBoxQuestionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            try
            {
                var index = listView1.SelectedIndices[0];
                var questionEditer = new QuestionEditer(_questions[index]);
                var dialogResult = questionEditer.ShowDialog();
                if (dialogResult == DialogResult.OK)
                    UpdateList();
            }
            catch (ArgumentOutOfRangeException )
            {
                MessageBox.Show(@"Выделите нужный вапрос!", @"Ошибка");
            }
        }
    }
}
