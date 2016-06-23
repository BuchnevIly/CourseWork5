using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Model;

namespace AdminPanel
{
    public partial class TeacherEditer : Form
    {
        private readonly Teacher _teacher;

        public TeacherEditer(Teacher teacher = null)
        {
            InitializeComponent();

            buttonDelete.Visible = (teacher != null);

            _teacher = teacher ?? new Teacher();
            textBoxName.DataBindings.Add("Text", _teacher, "Name");
            textBoxLastName.DataBindings.Add("Text", _teacher, "LastName");
            textBoxLogin.DataBindings.Add("Text", _teacher, "Login");


            textBoxLastName.TextChanged += textBoxLogin_TextChanged;
            textBoxName.TextChanged += textBoxLogin_TextChanged;

        }

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {
            labelException.Visible = false;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_teacher.Id == 0)
                    _teacher.Save();
                else
                    _teacher.Update();
            }
            catch (SqlException exception)
            {
                labelException.Text = exception.Message;
                labelException.Visible = true;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            _teacher.Delete();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            _teacher.ResetPassword();
        }
    }
}
