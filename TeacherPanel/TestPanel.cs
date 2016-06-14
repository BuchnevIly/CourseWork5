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
    public partial class TestPanel : Form
    {
        private List<Test> _tests;

        public TestPanel()
        {
            InitializeComponent();
            UpdateList();
        }

        public void UpdateList()
        {
            listView.Items.Clear();
            _tests = Test.GetAll();

            var i = 0;
            _tests.ForEach(x =>
            {
                listView.Items.Add(Convert.ToString(i + 1));
                listView.Items[i].SubItems.Add(x.Name);
                listView.Items[i].SubItems.Add(x.TestData.ToString("dd.MM.yy"));
                listView.Items[i].SubItems.Add(Convert.ToString(x.TestQuestions.Count));
                i++;
            });
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var testEditer = new TestEditer();
            testEditer.ShowDialog();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {

        }
    }
}
