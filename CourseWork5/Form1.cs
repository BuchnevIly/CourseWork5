using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork5
{
    public partial class TeacherPanel : Form
    {
        public TeacherPanel()
        {
            InitializeComponent();
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

            // -- Добавление списка разделов
            for (int i = 0; i < 10; i++)
            {
                TreeNode childNodeUnit = new TreeNode("тестовый раздел " + i);
                childNodeUnit.Tag = "Список_разделов";
                navigation.Nodes[0].Nodes.Add(childNodeUnit);
            }

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
                    switch (Convert.ToString(node.Tag))
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
    }
}
