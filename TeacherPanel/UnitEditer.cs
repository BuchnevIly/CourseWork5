using System;
using System.Windows.Forms;
using Model;

namespace TeacherPanel
{
    public partial class UnitEditer : Form
    {
        private readonly Unit _unit;

        private readonly bool _isSave = true;

        public UnitEditer(Unit unit = null)
        {
            InitializeComponent();

            _unit = unit ?? new Unit();
            tbNameUnit.DataBindings.Add("Text", _unit, "Name");

            if (_unit.Id == 0)
                return;

            _isSave = false;
            buttonAddSave.Text = @"Изменить";
            buttonDelete.Visible = true;
        }

        private void buttonAddSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_isSave) _unit.Save();
                else _unit.Update();

                DialogResult = DialogResult.OK;
                Close();
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
