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
using Model;

namespace Testing
{

    public partial class Login : Form
    {
        private Student _student;

        public Login()
        {
            InitializeComponent();
            _student = new Student();


            textBoxLogin.DataBindings.Add("Text", _student, "Id");
            textBoxPassword.DataBindings.Add("Text", _student, "Password");

            textBoxPassword.TextChanged += textBoxLogin_TextChanged;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                _student.Login();
                _student.Load();
                DialogResult = DialogResult.OK;
                MainForm.LoginStudent(_student);
                Close();
            }
            catch (SqlException exception)
            {
                labelException.Visible = true;
                labelException.Text = exception.Message;
            }
        }

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {
            labelException.Visible = false;
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = !checkBoxShowPassword.Checked;
        }
    }
}
