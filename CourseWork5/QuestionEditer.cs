using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork5
{
    public partial class QuestionEditer : Form
    {
        SqlConnection cnn;

        public QuestionEditer(int id = -1)
        {
            InitializeComponent();
            string connetionString = "Data Source=DESKTOP-RD3DFVB;Initial Catalog=TestSystem;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            loadTypeQuestion();
            loadUnits();

            if (id != -1)
                for (int i = 0; i < cbUnit.Items.Count; i++)
                    if( ((ComboboxItem)cbUnit.Items[i]).Value == id) 
                        cbUnit.SelectedIndex = i;


            //Скрывает вкладки в tab control
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;
        }

        private void loadTypeQuestion()
        {
            SqlCommand sqlCom = new SqlCommand("get_all_type_question", cnn);
            sqlCom.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = sqlCom.ExecuteReader();
            while (reader.Read())
            {
                cbTypeQuestion.Items.Add(reader.GetValue(1).ToString());
            }

            reader.Close();

            if (cbTypeQuestion.Items.Count != 0)
                cbTypeQuestion.SelectedIndex = 0;
        }


        private void loadUnits()
        {
            SqlCommand sqlCom = new SqlCommand("get_all_unit", cnn);
            sqlCom.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = sqlCom.ExecuteReader();
            while (reader.Read())
            {
                
                var item = new ComboboxItem((int)reader.GetValue(0), 
                    reader.GetValue(1).ToString());
                cbUnit.Items.Add(item);
            }

            reader.Close();
        }


        public class ComboboxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public ComboboxItem(int Value, string Text)
            {
                this.Text = Text;
                this.Value = Value;
            }

            public override string ToString()
            {
                return Text;
            }
        }

    }
}
