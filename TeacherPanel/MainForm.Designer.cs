namespace TeacherPanel
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.linkLabelTest = new System.Windows.Forms.LinkLabel();
            this.linkLabelStatistic = new System.Windows.Forms.LinkLabel();
            this.linkLabelAddNewUnit = new System.Windows.Forms.LinkLabel();
            this.linkLabelUnit = new System.Windows.Forms.LinkLabel();
            this.linkLabelQuestion = new System.Windows.Forms.LinkLabel();
            this.linkLabelAddNewQuestion = new System.Windows.Forms.LinkLabel();
            this.linkLabelAddTest = new System.Windows.Forms.LinkLabel();
            this.linkLabelResult = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(241, 31);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(451, 399);
            this.webBrowser1.TabIndex = 0;
            // 
            // linkLabelTest
            // 
            this.linkLabelTest.AutoSize = true;
            this.linkLabelTest.Location = new System.Drawing.Point(10, 20);
            this.linkLabelTest.Name = "linkLabelTest";
            this.linkLabelTest.Size = new System.Drawing.Size(115, 13);
            this.linkLabelTest.TabIndex = 4;
            this.linkLabelTest.TabStop = true;
            this.linkLabelTest.Text = "Контрольные работы";
            this.linkLabelTest.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelTest_LinkClicked);
            // 
            // linkLabelStatistic
            // 
            this.linkLabelStatistic.AutoSize = true;
            this.linkLabelStatistic.Location = new System.Drawing.Point(10, 69);
            this.linkLabelStatistic.Name = "linkLabelStatistic";
            this.linkLabelStatistic.Size = new System.Drawing.Size(65, 13);
            this.linkLabelStatistic.TabIndex = 5;
            this.linkLabelStatistic.TabStop = true;
            this.linkLabelStatistic.Text = "Статистика";
            this.linkLabelStatistic.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelStatistic_LinkClicked);
            // 
            // linkLabelAddNewUnit
            // 
            this.linkLabelAddNewUnit.AutoSize = true;
            this.linkLabelAddNewUnit.Location = new System.Drawing.Point(28, 106);
            this.linkLabelAddNewUnit.Name = "linkLabelAddNewUnit";
            this.linkLabelAddNewUnit.Size = new System.Drawing.Size(131, 13);
            this.linkLabelAddNewUnit.TabIndex = 7;
            this.linkLabelAddNewUnit.TabStop = true;
            this.linkLabelAddNewUnit.Text = "Добавить новый раздел";
            this.linkLabelAddNewUnit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAddNewUnit_LinkClicked);
            // 
            // linkLabelUnit
            // 
            this.linkLabelUnit.AutoSize = true;
            this.linkLabelUnit.Location = new System.Drawing.Point(10, 88);
            this.linkLabelUnit.Name = "linkLabelUnit";
            this.linkLabelUnit.Size = new System.Drawing.Size(55, 13);
            this.linkLabelUnit.TabIndex = 6;
            this.linkLabelUnit.TabStop = true;
            this.linkLabelUnit.Text = "Разделы ";
            this.linkLabelUnit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelUnit_LinkClicked);
            // 
            // linkLabelQuestion
            // 
            this.linkLabelQuestion.AutoSize = true;
            this.linkLabelQuestion.Location = new System.Drawing.Point(10, 124);
            this.linkLabelQuestion.Name = "linkLabelQuestion";
            this.linkLabelQuestion.Size = new System.Drawing.Size(52, 13);
            this.linkLabelQuestion.TabIndex = 8;
            this.linkLabelQuestion.TabStop = true;
            this.linkLabelQuestion.Text = "Вопросы";
            this.linkLabelQuestion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelQuestion_LinkClicked);
            // 
            // linkLabelAddNewQuestion
            // 
            this.linkLabelAddNewQuestion.AutoSize = true;
            this.linkLabelAddNewQuestion.Location = new System.Drawing.Point(28, 142);
            this.linkLabelAddNewQuestion.Name = "linkLabelAddNewQuestion";
            this.linkLabelAddNewQuestion.Size = new System.Drawing.Size(131, 13);
            this.linkLabelAddNewQuestion.TabIndex = 9;
            this.linkLabelAddNewQuestion.TabStop = true;
            this.linkLabelAddNewQuestion.Text = "Добавить новый вопрос";
            this.linkLabelAddNewQuestion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAddNewQuestion_LinkClicked);
            // 
            // linkLabelAddTest
            // 
            this.linkLabelAddTest.AutoSize = true;
            this.linkLabelAddTest.Location = new System.Drawing.Point(28, 36);
            this.linkLabelAddTest.Name = "linkLabelAddTest";
            this.linkLabelAddTest.Size = new System.Drawing.Size(160, 13);
            this.linkLabelAddTest.TabIndex = 10;
            this.linkLabelAddTest.TabStop = true;
            this.linkLabelAddTest.Text = "Добавить новую контрольную";
            this.linkLabelAddTest.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAddTest_LinkClicked);
            // 
            // linkLabelResult
            // 
            this.linkLabelResult.AutoSize = true;
            this.linkLabelResult.Location = new System.Drawing.Point(31, 53);
            this.linkLabelResult.Name = "linkLabelResult";
            this.linkLabelResult.Size = new System.Drawing.Size(67, 13);
            this.linkLabelResult.TabIndex = 11;
            this.linkLabelResult.TabStop = true;
            this.linkLabelResult.Text = "Результаты";
            this.linkLabelResult.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelResult_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkLabelResult);
            this.groupBox1.Controls.Add(this.linkLabelTest);
            this.groupBox1.Controls.Add(this.linkLabelAddTest);
            this.groupBox1.Controls.Add(this.linkLabelStatistic);
            this.groupBox1.Controls.Add(this.linkLabelAddNewQuestion);
            this.groupBox1.Controls.Add(this.linkLabelUnit);
            this.groupBox1.Controls.Add(this.linkLabelQuestion);
            this.groupBox1.Controls.Add(this.linkLabelAddNewUnit);
            this.groupBox1.Location = new System.Drawing.Point(12, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 183);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Навигация";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 459);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.webBrowser1);
            this.Name = "MainForm";
            this.Text = "Панель управления преподавателя";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.LinkLabel linkLabelTest;
        private System.Windows.Forms.LinkLabel linkLabelStatistic;
        private System.Windows.Forms.LinkLabel linkLabelAddNewUnit;
        private System.Windows.Forms.LinkLabel linkLabelUnit;
        private System.Windows.Forms.LinkLabel linkLabelQuestion;
        private System.Windows.Forms.LinkLabel linkLabelAddNewQuestion;
        private System.Windows.Forms.LinkLabel linkLabelAddTest;
        private System.Windows.Forms.LinkLabel linkLabelResult;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}