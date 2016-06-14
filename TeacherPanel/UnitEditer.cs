using System;
using System.Windows.Forms;
using Model;

namespace TeacherPanel
{
    public partial class UnitEditer : Form
    {
        private readonly Form _parentForm;

        private readonly Unit _unit;

        private readonly bool _isSave = true;

        public UnitEditer(Form parentForm = null, int id = -1)
        {
            
            InitializeComponent();
            _unit = new Unit();
            _parentForm = parentForm;

            tbNameUnit.DataBindings.Add("Text", _unit, "Name");

            if (id == -1)
                return;

            buttonAddSave.Text = "Изменить";
            buttonDelete.Visible = true;

            _isSave = false;
            _unit.Id = id;
            _unit.Load();
        }

        private void buttonAddSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_isSave)
                    _unit.Save();
                else
                    _unit.Update();

                ((UnitPanel)_parentForm).UpdateList();
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
