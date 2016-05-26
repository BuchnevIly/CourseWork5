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
    public partial class UnitEditer : Form
    {
        private SqlConnection cnn;

        private Form parentForm;

        private enum Type { Add, Save }

        private Type currentType = Type.Add;

        private int currentId;

        public UnitEditer(Form parentForm, int id = -1)
        {
            this.parentForm = parentForm;
            InitializeComponent();
            string connetionString = "Data Source=DESKTOP-RD3DFVB;Initial Catalog=TestSystem;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            if (id != -1)
            {
                currentId = id;

                var sqlCmd = new SqlCommand("load_unit", cnn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Clear();
                sqlCmd.Parameters.AddWithValue("@id", id);

                SqlParameter retval = new SqlParameter();
                retval.Direction = ParameterDirection.Output;
                retval.ParameterName = "@name";
                retval.Size = 50;
                retval.SqlDbType = SqlDbType.VarChar;
                sqlCmd.Parameters.Add(retval);
                sqlCmd.ExecuteNonQuery();

                tbNameUnit.Text = retval.Value.ToString();

                buttonDelete.Visible = true;
                buttonAddSave.Text = "Сохранить";
                currentType = Type.Save;
            }
        }

        private void save()
        {
            var sqlCmd = new SqlCommand("update_unit", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.AddWithValue("@id", currentId);
            sqlCmd.Parameters.AddWithValue("@name", tbNameUnit.Text);
            try
            {
                sqlCmd.ExecuteNonQuery();
                ((TeacherPanel)parentForm).SetAllUnit();
            }
            catch (Exception e)
            {
                labelError.Text = e.Message;
                labelError.Visible = true;
            }
        }

        private void add()
        {
            var sqlCmd = new SqlCommand("add_new_unit", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.AddWithValue("@name", tbNameUnit.Text);
            try
            {
                sqlCmd.ExecuteNonQuery();
                ((TeacherPanel)parentForm).SetAllUnit();
            }
            catch (Exception e)
            {
                labelError.Text = e.Message;
                labelError.Visible = true;
            }
        }

        private void buttonAddSave_Click(object sender, EventArgs e)
        {
            switch (currentType)
            {
                case Type.Save:
                    save();
                    break;
                case Type.Add:
                    add();
                    break;
            }
        }

        private void tbNameUnit_TextChanged(object sender, EventArgs e)
        {
            labelError.Visible = false;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var sqlCmd = new SqlCommand("delete_unit", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.AddWithValue("@id", currentId);
            try
            {
                sqlCmd.ExecuteNonQuery();
                ((TeacherPanel)parentForm).SetAllUnit();
                this.Close();
            }
            catch (Exception exeption)
            {
                labelError.Text = exeption.Message;
                labelError.Visible = true;
            }
        }
    }
}
