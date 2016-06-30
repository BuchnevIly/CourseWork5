namespace AdminPanel
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.linkLabelGroup = new System.Windows.Forms.LinkLabel();
            this.linkLabelAddGroup = new System.Windows.Forms.LinkLabel();
            this.linkLabelStudent = new System.Windows.Forms.LinkLabel();
            this.linkLabelAddStudent = new System.Windows.Forms.LinkLabel();
            this.linkLabeTeacher = new System.Windows.Forms.LinkLabel();
            this.linkLabelAddTeacher = new System.Windows.Forms.LinkLabel();
            this.linkLabelChangePassword = new System.Windows.Forms.LinkLabel();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // linkLabelGroup
            // 
            this.linkLabelGroup.AutoSize = true;
            this.linkLabelGroup.Location = new System.Drawing.Point(10, 28);
            this.linkLabelGroup.Name = "linkLabelGroup";
            this.linkLabelGroup.Size = new System.Drawing.Size(44, 13);
            this.linkLabelGroup.TabIndex = 0;
            this.linkLabelGroup.TabStop = true;
            this.linkLabelGroup.Text = "Группы";
            this.linkLabelGroup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGroup_LinkClicked);
            // 
            // linkLabelAddGroup
            // 
            this.linkLabelAddGroup.AutoSize = true;
            this.linkLabelAddGroup.Location = new System.Drawing.Point(26, 44);
            this.linkLabelAddGroup.Name = "linkLabelAddGroup";
            this.linkLabelAddGroup.Size = new System.Drawing.Size(93, 13);
            this.linkLabelAddGroup.TabIndex = 1;
            this.linkLabelAddGroup.TabStop = true;
            this.linkLabelAddGroup.Text = "Добавить группу";
            this.linkLabelAddGroup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAddGroup_LinkClicked);
            // 
            // linkLabelStudent
            // 
            this.linkLabelStudent.AutoSize = true;
            this.linkLabelStudent.Location = new System.Drawing.Point(10, 60);
            this.linkLabelStudent.Name = "linkLabelStudent";
            this.linkLabelStudent.Size = new System.Drawing.Size(55, 13);
            this.linkLabelStudent.TabIndex = 2;
            this.linkLabelStudent.TabStop = true;
            this.linkLabelStudent.Text = "Студенты";
            this.linkLabelStudent.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelStudent_LinkClicked);
            // 
            // linkLabelAddStudent
            // 
            this.linkLabelAddStudent.AutoSize = true;
            this.linkLabelAddStudent.Location = new System.Drawing.Point(26, 76);
            this.linkLabelAddStudent.Name = "linkLabelAddStudent";
            this.linkLabelAddStudent.Size = new System.Drawing.Size(105, 13);
            this.linkLabelAddStudent.TabIndex = 3;
            this.linkLabelAddStudent.TabStop = true;
            this.linkLabelAddStudent.Text = "Добавить студента";
            this.linkLabelAddStudent.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAddStudent_LinkClicked);
            // 
            // linkLabeTeacher
            // 
            this.linkLabeTeacher.AutoSize = true;
            this.linkLabeTeacher.Location = new System.Drawing.Point(10, 92);
            this.linkLabeTeacher.Name = "linkLabeTeacher";
            this.linkLabeTeacher.Size = new System.Drawing.Size(86, 13);
            this.linkLabeTeacher.TabIndex = 4;
            this.linkLabeTeacher.TabStop = true;
            this.linkLabeTeacher.Text = "Преподаватели";
            this.linkLabeTeacher.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabeTeacher_LinkClicked);
            // 
            // linkLabelAddTeacher
            // 
            this.linkLabelAddTeacher.AutoSize = true;
            this.linkLabelAddTeacher.Location = new System.Drawing.Point(26, 107);
            this.linkLabelAddTeacher.Name = "linkLabelAddTeacher";
            this.linkLabelAddTeacher.Size = new System.Drawing.Size(137, 13);
            this.linkLabelAddTeacher.TabIndex = 5;
            this.linkLabelAddTeacher.TabStop = true;
            this.linkLabelAddTeacher.Text = "Добавить преподавателя";
            this.linkLabelAddTeacher.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAddTeacher_LinkClicked);
            // 
            // linkLabelChangePassword
            // 
            this.linkLabelChangePassword.AutoSize = true;
            this.linkLabelChangePassword.Location = new System.Drawing.Point(10, 122);
            this.linkLabelChangePassword.Name = "linkLabelChangePassword";
            this.linkLabelChangePassword.Size = new System.Drawing.Size(90, 13);
            this.linkLabelChangePassword.TabIndex = 6;
            this.linkLabelChangePassword.TabStop = true;
            this.linkLabelChangePassword.Text = "Сменить пароль";
            this.linkLabelChangePassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelChangePassword_LinkClicked);
            // 
            // webBrowser
            // 
            this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser.Location = new System.Drawing.Point(194, 12);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(392, 405);
            this.webBrowser.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkLabelAddStudent);
            this.groupBox1.Controls.Add(this.linkLabelGroup);
            this.groupBox1.Controls.Add(this.linkLabelChangePassword);
            this.groupBox1.Controls.Add(this.linkLabelAddGroup);
            this.groupBox1.Controls.Add(this.linkLabelAddTeacher);
            this.groupBox1.Controls.Add(this.linkLabelStudent);
            this.groupBox1.Controls.Add(this.linkLabeTeacher);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 158);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Навигация";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 429);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.webBrowser);
            this.Name = "MainForm";
            this.Text = "Панель администратора";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabelGroup;
        private System.Windows.Forms.LinkLabel linkLabelAddGroup;
        private System.Windows.Forms.LinkLabel linkLabelStudent;
        private System.Windows.Forms.LinkLabel linkLabelAddStudent;
        private System.Windows.Forms.LinkLabel linkLabeTeacher;
        private System.Windows.Forms.LinkLabel linkLabelAddTeacher;
        private System.Windows.Forms.LinkLabel linkLabelChangePassword;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}