using System.Data.SqlClient;
using System.Windows.Forms;
using model;

namespace Testing
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
            textBoxNewPassword.TextChanged += textBoxOldPassword_TextChanged;
        }

        private void textBoxOldPassword_TextChanged(object sender, System.EventArgs e)
        {
            labelException.Visible = false;
        }

        private void buttonChangePassword_Click(object sender, System.EventArgs e)
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
                MainForm.Student.ChangePassword(newPassword, oldPassword);
                Close();
            }
            catch (SqlException exception)
            {
                labelException.Text = exception.Message;
                labelException.Visible = true;
            }
        }
    }
}
