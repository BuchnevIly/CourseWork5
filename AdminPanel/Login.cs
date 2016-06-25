using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using model;

namespace AdminPanel
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxPassword.Text != "")
                    Admin.Login(textBoxPassword.Text);
            }
            catch (SqlException exception)
            {
                labelException.Text = exception.Message;
                labelException.Visible = true;
            }

            DialogResult = DialogResult.OK;
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            labelException.Visible = false;
        }
    }
}
