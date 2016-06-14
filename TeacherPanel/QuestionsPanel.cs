using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace TeacherPanel
{
    public partial class QuestionsPanel : Form
    {
        private Form _parentForm;

        private List<Question> _questions;

        public QuestionsPanel(Form parentForm = null, int idUnit = 0)
        {
            InitializeComponent();
            _parentForm = parentForm;

            TypeQuestion.GetAll().ForEach(x => comboBoxQuestionType.Items.Add(x));
            Unit.GetAll().ForEach(x => comboBoxUnit.Items.Add(x));

            comboBoxQuestionType.SelectedIndex = 0;

            if (comboBoxUnit.Items.Count == 0) return;
            comboBoxUnit.SelectedIndex = 0;

            if (idUnit == 0) return;
            var index = 0;
            for (var i = 0; i < comboBoxUnit.Items.Count; i++)
                if (((Unit)comboBoxUnit.Items[i]).Id == idUnit)
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
                .Where(x => x.IdUnit == selectedUnit && x.Type.Id == selectedType).ToList();


            var i = 0;
            foreach (var item in _questions)
            {
                listView1.Items.Add(Convert.ToString(i + 1));
                listView1.Items[i].SubItems.Add(item.TextQuestion);
                var unit = new Unit {Id = item.IdUnit};
                unit.Load();
                listView1.Items[i].SubItems.Add(unit.Name);
                listView1.Items[i].SubItems.Add(item.Type.Name);
                i++;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var questionEditer = new QuestionEditer();
            questionEditer.ShowDialog();
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
                var questionEditer = new QuestionEditer(_questions[index], this);
                questionEditer.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Выделите нужный вапрос!", "Ошибка");
            }
        }
    }
}
