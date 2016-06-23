using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;

namespace AdminPanel
{
    public partial class GroupPanel : Form
    {
        private List<Group> _group;

        public GroupPanel()
        {
            InitializeComponent();
            UpdateList();
        }

        private void UpdateList()
        {
            _group = Group.GetAll();

            listView.Items.Clear();
            var i = 0;
            _group.ForEach(x =>
            {
                listView.Items.Add(Convert.ToString(i + 1));
                listView.Items[i].SubItems.Add(x.Name);
                listView.Items[i].SubItems.Add(Convert.ToString(x.GetStudents().Count));
                i++;
            });
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var groupEditer = new GroupEditer();
            var dialogResult = groupEditer.ShowDialog();
            if (dialogResult == DialogResult.OK)
                UpdateList();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            try
            {
                var group = _group[listView.SelectedIndices[0]];
                var groupEditer = new GroupEditer(group);
                var dialogResult = groupEditer.ShowDialog();
                if (dialogResult == DialogResult.OK)
                    UpdateList();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(@"Выделите нужную группу!", @"Ошибка");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var group = _group[listView.SelectedIndices[0]];
                group.Delete();
                MessageBox.Show(@"Группа удалена", @"Успех");
                UpdateList();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(@"Выделите нужную группу!", @"Ошибка");
            }
        }
    }
}
