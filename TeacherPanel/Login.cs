﻿using System;
using System.Windows.Forms;
using Model;

namespace TeacherPanel
{
    public partial class Login : Form
    {
        private readonly Teacher _teacher;

        public Login()
        {
            InitializeComponent();
            _teacher = new Teacher();

            textBoxLogin.DataBindings.Add("Text", _teacher, "LoginName");
            textBoxPassword.DataBindings.Add("Text", _teacher, "Password");

            CenterToParent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                _teacher.Login();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception exaption)
            {
                MessageBox.Show(exaption.Message, @"Ошибка авторизации");
            }
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = !checkBoxShowPassword.Checked;
        }
    }
}
