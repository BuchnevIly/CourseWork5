﻿using System;
using System.Windows.Forms;

namespace CourseWork5
{
    public partial class UnitEditer : Form
    {
        private Form parentForm;

        private Unit unit;

        private bool isSave = true;

        public UnitEditer(Form parentForm, int id = -1)
        {
            this.parentForm = parentForm;
            InitializeComponent();
            unit = new Unit();

            tbNameUnit.DataBindings.Add("Text", unit, "Name", false, DataSourceUpdateMode.OnPropertyChanged);

            if (id == -1)
                return;

            isSave = false;
            buttonAddSave.Text = "Изменить";
            buttonDelete.Visible = true;
            unit.Id = id;
            unit.Load();
        }

        private void buttonAddSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (isSave)
                    unit.Save();
                else
                    unit.Update();
            }catch (Exception exeption)
            {
                labelError.Text = exeption.Message;
                labelError.Visible = true;
            }
          
        }

        private void tbNameUnit_TextChanged(object sender, EventArgs e)
        {
            labelError.Visible = false;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
