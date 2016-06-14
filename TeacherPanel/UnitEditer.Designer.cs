namespace TeacherPanel
{
    partial class UnitEditer
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
            this.tbNameUnit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.buttonAddSave = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbNameUnit
            // 
            this.tbNameUnit.Location = new System.Drawing.Point(110, 12);
            this.tbNameUnit.Name = "tbNameUnit";
            this.tbNameUnit.Size = new System.Drawing.Size(187, 20);
            this.tbNameUnit.TabIndex = 0;
            this.tbNameUnit.TextChanged += new System.EventHandler(this.tbNameUnit_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Название раздела";
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(113, 36);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(187, 13);
            this.labelError.TabIndex = 2;
            this.labelError.Text = "* это название раздела уже занято";
            this.labelError.Visible = false;
            // 
            // buttonAddSave
            // 
            this.buttonAddSave.Location = new System.Drawing.Point(222, 55);
            this.buttonAddSave.Name = "buttonAddSave";
            this.buttonAddSave.Size = new System.Drawing.Size(75, 23);
            this.buttonAddSave.TabIndex = 3;
            this.buttonAddSave.Text = "Добавить";
            this.buttonAddSave.UseVisualStyleBackColor = true;
            this.buttonAddSave.Click += new System.EventHandler(this.buttonAddSave_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(141, 55);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Visible = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // UnitEditer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 91);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAddSave);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbNameUnit);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(330, 130);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(330, 130);
            this.Name = "UnitEditer";
            this.Text = " Добавление раздела";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbNameUnit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Button buttonAddSave;
        private System.Windows.Forms.Button buttonDelete;
    }
}