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
            var unitEditer = new UnitEditer(this);
            unitEditer.ShowDialog();
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
                listView.Items[i].SubItems.Add(Convert.ToString(unit.Questions.Count));
                i++;
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            try
            {
                var index = listView.SelectedIndices[0];
                var questionPanel = new QuestionsPanel(this, _units[index].Id);
                questionPanel.ShowDialog();
            }
            catch (Exception)
            {
                var questionPanel = new QuestionsPanel(this);
                questionPanel.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var index = listView.SelectedIndices[0];
                var unitEditer = new UnitEditer(this, _units[index].Id);
                unitEditer.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Выделите нужный раздел!", "Ошибка");
            }
        }
    }
}
