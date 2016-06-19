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
            this.buttonTest = new System.Windows.Forms.Button();
            this.buttonStatistic = new System.Windows.Forms.Button();
            this.buttonUnits = new System.Windows.Forms.Button();
            this.linkLabelTest = new System.Windows.Forms.LinkLabel();
            this.linkLabelStatistic = new System.Windows.Forms.LinkLabel();
            this.linkLabelAddNewUnit = new System.Windows.Forms.LinkLabel();
            this.linkLabelUnit = new System.Windows.Forms.LinkLabel();
            this.linkLabelQuestion = new System.Windows.Forms.LinkLabel();
            this.linkLabelAddNewQuestion = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(217, 31);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(474, 110);
            this.webBrowser1.TabIndex = 0;
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(318, 259);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(124, 47);
            this.buttonTest.TabIndex = 1;
            this.buttonTest.Text = "Контрольные работы";
            this.buttonTest.UseVisualStyleBackColor = true;
            // 
            // buttonStatistic
            // 
            this.buttonStatistic.Location = new System.Drawing.Point(318, 312);
            this.buttonStatistic.Name = "buttonStatistic";
            this.buttonStatistic.Size = new System.Drawing.Size(124, 47);
            this.buttonStatistic.TabIndex = 2;
            this.buttonStatistic.Text = "Статистика";
            this.buttonStatistic.UseVisualStyleBackColor = true;
            // 
            // buttonUnits
            // 
            this.buttonUnits.Location = new System.Drawing.Point(318, 365);
            this.buttonUnits.Name = "buttonUnits";
            this.buttonUnits.Size = new System.Drawing.Size(124, 47);
            this.buttonUnits.TabIndex = 3;
            this.buttonUnits.Text = "Разделы";
            this.buttonUnits.UseVisualStyleBackColor = true;
            this.buttonUnits.Click += new System.EventHandler(this.buttonUnits_Click);
            // 
            // linkLabelTest
            // 
            this.linkLabelTest.AutoSize = true;
            this.linkLabelTest.Location = new System.Drawing.Point(33, 31);
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
            this.linkLabelStatistic.Location = new System.Drawing.Point(33, 50);
            this.linkLabelStatistic.Name = "linkLabelStatistic";
            this.linkLabelStatistic.Size = new System.Drawing.Size(65, 13);
            this.linkLabelStatistic.TabIndex = 5;
            this.linkLabelStatistic.TabStop = true;
            this.linkLabelStatistic.Text = "Статистика";
            // 
            // linkLabelAddNewUnit
            // 
            this.linkLabelAddNewUnit.AutoSize = true;
            this.linkLabelAddNewUnit.Location = new System.Drawing.Point(51, 87);
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
            this.linkLabelUnit.Location = new System.Drawing.Point(33, 69);
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
            this.linkLabelQuestion.Location = new System.Drawing.Point(33, 105);
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
            this.linkLabelAddNewQuestion.Location = new System.Drawing.Point(51, 123);
            this.linkLabelAddNewQuestion.Name = "linkLabelAddNewQuestion";
            this.linkLabelAddNewQuestion.Size = new System.Drawing.Size(131, 13);
            this.linkLabelAddNewQuestion.TabIndex = 9;
            this.linkLabelAddNewQuestion.TabStop = true;
            this.linkLabelAddNewQuestion.Text = "Добавить новый вопрос";
            this.linkLabelAddNewQuestion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAddNewQuestion_LinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 459);
            this.Controls.Add(this.linkLabelAddNewQuestion);
            this.Controls.Add(this.linkLabelQuestion);
            this.Controls.Add(this.linkLabelAddNewUnit);
            this.Controls.Add(this.linkLabelUnit);
            this.Controls.Add(this.linkLabelStatistic);
            this.Controls.Add(this.linkLabelTest);
            this.Controls.Add(this.buttonUnits);
            this.Controls.Add(this.buttonStatistic);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.webBrowser1);
            this.Name = "MainForm";
            this.Text = "Панель управления преподавателя";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.Button buttonStatistic;
        private System.Windows.Forms.Button buttonUnits;
        private System.Windows.Forms.LinkLabel linkLabelTest;
        private System.Windows.Forms.LinkLabel linkLabelStatistic;
        private System.Windows.Forms.LinkLabel linkLabelAddNewUnit;
        private System.Windows.Forms.LinkLabel linkLabelUnit;
        private System.Windows.Forms.LinkLabel linkLabelQuestion;
        private System.Windows.Forms.LinkLabel linkLabelAddNewQuestion;
    }
}