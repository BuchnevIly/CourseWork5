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
            pictureBox1.Image = Properties.Resources.login;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxPassword.Text != "")
                {
                    var admin = new Admin();
                    admin.Login(textBoxPassword.Text);
                }
                
                DialogResult = DialogResult.OK;
            }
            catch (SqlException exception)
            {
                labelException.Text = exception.Message;
                labelException.Visible = true;
            }

            
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            labelException.Visible = false;
        }
    }
}
