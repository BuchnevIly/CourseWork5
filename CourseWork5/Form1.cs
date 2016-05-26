using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork5
{
    public partial class TeacherPanel : Form
    {
        private SqlConnection cnn;

        public TeacherPanel()
        {
            InitializeComponent();

            string connetionString = "Data Source=DESKTOP-RD3DFVB;Initial Catalog=TestSystem;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
        }

        // -- Добавление списка разделов
        public void SetAllUnit()
        {
            var sqlCmd = new SqlCommand("get_all_unit", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dataReader = sqlCmd.ExecuteReader();

            navigation.Nodes[0].Nodes.Clear();

            while (dataReader.Read())
            {
                int id = (int)dataReader.GetValue(0);
                string unitName = dataReader.GetValue(1).ToString();
                TreeNode childNodeUnit = new TreeNode(unitName);
                childNodeUnit.Tag = "Список_разделов " + id;
                navigation.Nodes[0].Nodes.Add(childNodeUnit);
            }

            dataReader.Close();
        }



        private void TeacherPanel_Load(object sender, EventArgs e)
        {
            //Создание списка в бокавом меню
            navigation.BeginUpdate();

            TreeNode nodeUnit = new TreeNode("Разделы");
            nodeUnit.Tag = "Разделы";

            TreeNode nodeTest = new TreeNode("Контрольные");
            nodeTest.Tag = "Контрольные";

            TreeNode nodeGroup = new TreeNode("Группы");
            nodeGroup.Tag = "Группы";

            navigation.Nodes.Add(nodeUnit);
            navigation.Nodes.Add(nodeTest);
            navigation.Nodes.Add(nodeGroup);

            SetAllUnit();

            
            


            // -- Добавление списка контрольных
            for (int i = 0; i < 10; i++)
            {
                TreeNode childNodeTest = new TreeNode("тестовая контрольная " + i);
                childNodeTest.Tag = "Список_контрольных";
                navigation.Nodes[1].Nodes.Add(childNodeTest);
            }

            // -- Добавление списка групп
            for (int i = 0; i < 10; i++)
            {
                TreeNode childNodeGroup = new TreeNode("тестовая группа " + i);
                childNodeGroup.Tag = "Пользователь";
                navigation.Nodes[2].Nodes.Add(childNodeGroup);
            }
            navigation.EndUpdate();


            //Список вопросов
            for (int i = 0; i < 10; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = "Вопрос " + i;
                listView1.Items.Add(lvi);
            }

            webBrowser1.DocumentText = "<h1> Вопрос 1 </h1> <p> Вопрос Вопрос Вопрос Вопрос </p>";
                
        }

        private void navigation_MouseUp(object sender, MouseEventArgs e)
        {
            // Если нажата правая кнопка мышки
            if (e.Button == MouseButtons.Right)
            {

                Point p = new Point(e.X, e.Y);
                TreeNode node = navigation.GetNodeAt(p);
                
                if (node != null)
                {
                    navigation.SelectedNode = node;
                    string tag = node.Tag.ToString().Split(' ')[0];
                    switch (Convert.ToString(tag))
                    {
                        case "Разделы":
                            contextMenuStripUnit.Show(navigation, p);
                            break;
                        case "Список_разделов":
                            contextMenuStripUnitChild.Show(navigation, p);
                            break;
                        case "Группы":
                            contextMenuStripGroup.Show(navigation, p);
                            break;
                        case "Контрольные":
                            contextMenuStripTest.Show(navigation, p);
                            break;
                        case "Пользователь":
                            contextMenuStripUser.Show(navigation, p);
                            break;
                        case "Список_контрольных":
                            contextMenuStripTestChild.Show(navigation, p);
                            break;
                    }
                }
            }
        }

        private void linkLabelAddNewElemen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QuestionEditer questionEditer = new QuestionEditer();
            questionEditer.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void новыйРазделToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UnitEditer unitEditer = new UnitEditer(this);
            unitEditer.Show();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuestionEditer questionEditer = new QuestionEditer();
            questionEditer.Show();
        }

        private void изменитьРазделToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(navigation.SelectedNode.Tag.ToString().Split(' ')[1]);
            UnitEditer unitEditer = new UnitEditer(this, id);
            unitEditer.Show();
        }

        private void добавитьНовуюКонтрольнуюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestEditer testEditer = new TestEditer();
            testEditer.Show();
        }

        private void добавитьВопросToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuestionEditer questionEditer = new QuestionEditer();
            questionEditer.Show();
        }

        private void удалиьРазделToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(navigation.SelectedNode.Tag.ToString().Split(' ')[1]);
            var sqlCmd = new SqlCommand("delete_unit", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.AddWithValue("@id", id);
            try
            {
                sqlCmd.ExecuteNonQuery();
                SetAllUnit();
            }
            catch (Exception exeption)
            {
                MessageBox.Show("Ошибка при удалении", exeption.Message,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void новыйРазделToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnitEditer unitEditer = new UnitEditer(this);
            unitEditer.Show();
        }

        private void списокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            navigation.CollapseAll();
            navigation.Nodes[0].Expand();
        }
    }
}
