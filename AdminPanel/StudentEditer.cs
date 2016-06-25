using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Model;

namespace AdminPanel
{
    public partial class StudentEditer : Form
    {
        private readonly Student _student;

        private readonly bool _save;

        public StudentEditer(Group group = null, Student student = null)
        {
            InitializeComponent();
            _student = student ?? new Student();
            _save = (student == null);
            buttonDelete.Visible = (student == null);

            textBoxName.DataBindings.Add("Text", _student, "Name");
            textBoxLastName.DataBindings.Add("Text", _student, "LastName");
            textBoxNum.DataBindings.Add("Text", _student, "Id");

            Group.GetAll().ForEach(x => comboBoxGroup.Items.Add(x));
            comboBoxGroup.SelectedIndex = 1;

            if (student != null)
                foreach (var item in comboBoxGroup.Items)
                    if (((Group)item).Id == student.Group.Id)
                    {
                        comboBoxGroup.SelectedItem = item;
                        return;
                    }

            if (group != null) 
                foreach (var item in comboBoxGroup.Items)
                    if (((Group) item).Id == group.Id)
                    {
                        comboBoxGroup.SelectedItem = item;
                        return;
                    }

            
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                _student.Group = (Group) comboBoxGroup.SelectedItem;
                if (_save)
                    _student.Save();
                else 
                    _student.Update();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (SqlException exception)
            {
                labelExeption.Text = exception.Message;
                labelExeption.Visible = true;
            }
        }

        private void textBoxNum_TextChanged(object sender, EventArgs e)
        {
            labelExeption.Visible = false;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            _student.Delete();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
