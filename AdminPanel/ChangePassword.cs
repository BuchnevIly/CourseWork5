using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using model;

namespace AdminPanel
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
            textBoxNewPassword.TextChanged += textBoxOldPassword_TextChanged;
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            var oldPassword = textBoxOldPassword.Text;
            var newPassword = textBoxNewPassword.Text;

            if (oldPassword == "" || newPassword == "")
            {
                labelException.Text = @"Поля не должны быть пусты!";
                labelException.Visible = true;
                return;
            }
                
            try
            {
                Admin.ChangePassword(newPassword, oldPassword);
                Close();
            }
            catch (SqlException exception)
            {
                labelException.Text = exception.Message;
                labelException.Visible = true;
            }
            
        }

        private void textBoxOldPassword_TextChanged(object sender, EventArgs e)
        {
            labelException.Visible = false;
        }
    }
}
