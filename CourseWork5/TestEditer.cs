using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork5
{
    public partial class TestEditer : Form
    {
        public TestEditer()
        {
            InitializeComponent();
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.CustomFormat = "hh:mm";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
        }
    }
}
