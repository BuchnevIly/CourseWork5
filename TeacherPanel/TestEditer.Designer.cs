namespace TeacherPanel
{
    partial class TestEditer
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
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonSetCurrentTime = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.datePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.timePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.datePickerStart = new System.Windows.Forms.DateTimePicker();
            this.timePickerStart = new System.Windows.Forms.DateTimePicker();
            this.listViewAllQueston = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewTestQuestion = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.buttonOpenFromTestQuestion = new System.Windows.Forms.Button();
            this.buttonOpenFromAllQuestion = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listViewGroup = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(219, 200);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(33, 23);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "▲";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(180, 200);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(33, 23);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "▼";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Дата и время начала контрольной";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 32);
            this.label2.TabIndex = 8;
            this.label2.Text = "Дата и время окончания контрольной";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(12, 381);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonSetCurrentTime
            // 
            this.buttonSetCurrentTime.Location = new System.Drawing.Point(11, 223);
            this.buttonSetCurrentTime.Name = "buttonSetCurrentTime";
            this.buttonSetCurrentTime.Size = new System.Drawing.Size(183, 23);
            this.buttonSetCurrentTime.TabIndex = 11;
            this.buttonSetCurrentTime.Text = "Установить текущую дату";
            this.buttonSetCurrentTime.UseVisualStyleBackColor = true;
            this.buttonSetCurrentTime.Click += new System.EventHandler(this.buttonSetCurrentTime_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Все вопросы";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.datePickerEnd);
            this.groupBox1.Controls.Add(this.timePickerEnd);
            this.groupBox1.Controls.Add(this.datePickerStart);
            this.groupBox1.Controls.Add(this.timePickerStart);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonSetCurrentTime);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 272);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Период выполнения";
            // 
            // datePickerEnd
            // 
            this.datePickerEnd.Location = new System.Drawing.Point(11, 197);
            this.datePickerEnd.Name = "datePickerEnd";
            this.datePickerEnd.Size = new System.Drawing.Size(183, 20);
            this.datePickerEnd.TabIndex = 15;
            // 
            // timePickerEnd
            // 
            this.timePickerEnd.CustomFormat = "";
            this.timePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePickerEnd.Location = new System.Drawing.Point(11, 171);
            this.timePickerEnd.Name = "timePickerEnd";
            this.timePickerEnd.ShowUpDown = true;
            this.timePickerEnd.Size = new System.Drawing.Size(76, 20);
            this.timePickerEnd.TabIndex = 14;
            // 
            // datePickerStart
            // 
            this.datePickerStart.Location = new System.Drawing.Point(11, 89);
            this.datePickerStart.Name = "datePickerStart";
            this.datePickerStart.Size = new System.Drawing.Size(183, 20);
            this.datePickerStart.TabIndex = 13;
            // 
            // timePickerStart
            // 
            this.timePickerStart.CustomFormat = "";
            this.timePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePickerStart.Location = new System.Drawing.Point(11, 63);
            this.timePickerStart.Name = "timePickerStart";
            this.timePickerStart.ShowUpDown = true;
            this.timePickerStart.Size = new System.Drawing.Size(76, 20);
            this.timePickerStart.TabIndex = 12;
            // 
            // listViewAllQueston
            // 
            this.listViewAllQueston.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listViewAllQueston.FullRowSelect = true;
            this.listViewAllQueston.GridLines = true;
            this.listViewAllQueston.Location = new System.Drawing.Point(16, 34);
            this.listViewAllQueston.Name = "listViewAllQueston";
            this.listViewAllQueston.Size = new System.Drawing.Size(367, 160);
            this.listViewAllQueston.TabIndex = 14;
            this.listViewAllQueston.UseCompatibleStateImageBehavior = false;
            this.listViewAllQueston.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "№";
            this.columnHeader1.Width = 31;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Вопрос";
            this.columnHeader2.Width = 154;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Раздел";
            this.columnHeader3.Width = 101;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Тип";
            this.columnHeader4.Width = 76;
            // 
            // listViewTestQuestion
            // 
            this.listViewTestQuestion.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.listViewTestQuestion.FullRowSelect = true;
            this.listViewTestQuestion.GridLines = true;
            this.listViewTestQuestion.Location = new System.Drawing.Point(16, 229);
            this.listViewTestQuestion.Name = "listViewTestQuestion";
            this.listViewTestQuestion.Size = new System.Drawing.Size(367, 132);
            this.listViewTestQuestion.TabIndex = 15;
            this.listViewTestQuestion.UseCompatibleStateImageBehavior = false;
            this.listViewTestQuestion.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "№";
            this.columnHeader5.Width = 31;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Вопрос";
            this.columnHeader6.Width = 151;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Раздел";
            this.columnHeader7.Width = 101;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Тип";
            this.columnHeader8.Width = 76;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Вопросы на контрольную";
            // 
            // buttonOpenFromTestQuestion
            // 
            this.buttonOpenFromTestQuestion.Location = new System.Drawing.Point(308, 367);
            this.buttonOpenFromTestQuestion.Name = "buttonOpenFromTestQuestion";
            this.buttonOpenFromTestQuestion.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenFromTestQuestion.TabIndex = 17;
            this.buttonOpenFromTestQuestion.Text = "Открыть";
            this.buttonOpenFromTestQuestion.UseVisualStyleBackColor = true;
            this.buttonOpenFromTestQuestion.Click += new System.EventHandler(this.buttonOpenFromTestQuestion_Click);
            // 
            // buttonOpenFromAllQuestion
            // 
            this.buttonOpenFromAllQuestion.Location = new System.Drawing.Point(308, 200);
            this.buttonOpenFromAllQuestion.Name = "buttonOpenFromAllQuestion";
            this.buttonOpenFromAllQuestion.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenFromAllQuestion.TabIndex = 18;
            this.buttonOpenFromAllQuestion.Text = "Открыть";
            this.buttonOpenFromAllQuestion.UseVisualStyleBackColor = true;
            this.buttonOpenFromAllQuestion.Click += new System.EventHandler(this.buttonOpenFromAllQuestion_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listViewAllQueston);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.buttonOpenFromAllQuestion);
            this.groupBox2.Controls.Add(this.listViewTestQuestion);
            this.groupBox2.Controls.Add(this.buttonAdd);
            this.groupBox2.Controls.Add(this.buttonDelete);
            this.groupBox2.Controls.Add(this.buttonOpenFromTestQuestion);
            this.groupBox2.Location = new System.Drawing.Point(218, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 401);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Вопросы";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxName);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 73);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Контрольная";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(14, 34);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(180, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Название онтрольной";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listViewGroup);
            this.groupBox4.Location = new System.Drawing.Point(624, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(400, 403);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Группы";
            // 
            // listViewGroup
            // 
            this.listViewGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10});
            this.listViewGroup.FullRowSelect = true;
            this.listViewGroup.GridLines = true;
            this.listViewGroup.Location = new System.Drawing.Point(16, 34);
            this.listViewGroup.Name = "listViewGroup";
            this.listViewGroup.Size = new System.Drawing.Size(367, 356);
            this.listViewGroup.TabIndex = 14;
            this.listViewGroup.UseCompatibleStateImageBehavior = false;
            this.listViewGroup.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "№";
            this.columnHeader9.Width = 31;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Группа";
            this.columnHeader10.Width = 154;
            // 
            // TestEditer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 427);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonSave);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1041, 466);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1041, 466);
            this.Name = "TestEditer";
            this.Text = "Редактор контрольной";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonSetCurrentTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker timePickerStart;
        private System.Windows.Forms.DateTimePicker datePickerEnd;
        private System.Windows.Forms.DateTimePicker timePickerEnd;
        private System.Windows.Forms.DateTimePicker datePickerStart;
        private System.Windows.Forms.ListView listViewAllQueston;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView listViewTestQuestion;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonOpenFromTestQuestion;
        private System.Windows.Forms.Button buttonOpenFromAllQuestion;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListView listViewGroup;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
    }
}