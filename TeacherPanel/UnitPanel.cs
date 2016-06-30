using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;

namespace TeacherPanel
{
    public partial class UnitPanel : Form
    {
        private List<Unit> _units;

        public UnitPanel()
        {
            InitializeComponent();
            UpdateList();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var unitEditer = new UnitEditer();
            unitEditer.ShowDialog();
            UpdateList();
        }

        public void UpdateList()
        {
            _units = Unit.GetAll();

            listView.Items.Clear();

            var i = 0;
            foreach (var unit in _units)
            {
                listView.Items.Add(Convert.ToString(i + 1));
                listView.Items[i].SubItems.Add(unit.Name);
                listView.Items[i].SubItems.Add(Convert.ToString(unit.GetQuestions().Count));
                i++;
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            try
            {
                var index = listView.SelectedIndices[0];
                var questionPanel = new QuestionsPanel(_units[index]);
                questionPanel.ShowDialog();
                UpdateList();
            }
            catch (ArgumentOutOfRangeException )
            {
                var questionPanel = new QuestionsPanel();
                var dialogResult = questionPanel.ShowDialog();
                UpdateList();
                if (dialogResult == DialogResult.OK)
                    UpdateList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var index = listView.SelectedIndices[0];
                var unitEditer = new UnitEditer(_units[index]);
                var dialogResult = unitEditer.ShowDialog();
                UpdateList();
                if (dialogResult == DialogResult.OK)
                    UpdateList();
            }
            catch (ArgumentOutOfRangeException )
            {
                MessageBox.Show(@"Выделите нужный раздел!", @"Ошибка");
            }
        }
    }
}
