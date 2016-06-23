using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Model;


namespace AdminPanel
{
    public partial class GroupEditer : Form
    {
        private readonly Group _group;

        public GroupEditer(Group group = null)
        {
            InitializeComponent();
            _group = group ?? new Group();

            textBox.DataBindings.Add("Text", _group, "Name");
            buttonDelete.Visible = group != null;
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            labelException.Visible = false;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_group.Id == 0)
                    _group.Save();
                else
                    _group.Update();

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (SqlException exception)
            {
                labelException.Visible = true;
                labelException.Text = exception.Message;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            _group.Delete();
        }
    }
}
