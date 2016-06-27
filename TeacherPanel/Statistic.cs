using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Model;

namespace TeacherPanel
{
    public partial class Statistic : Form
    {
        private List<Unit> _units;

        private List<StudentsAnswer> _answers;

        public Statistic()
        {
            InitializeComponent();

            _units = Unit.GetAll();
            _answers = StudentsAnswer.GetAll();

            DrowChart();
        }

        private void DrowChart()
        {


            var list = new List<double>();
            _units.ForEach(x =>
            {
                double a = _answers
                    .Where(y => y.TestQuestion.Question.Unit.Id == x.Id && 
                        y.DateAnswer > dateTimePicker1.Value &&
                        y.DateAnswer < dateTimePicker2.Value)
                    .Count(y => y.IsTrue);
                double b = _answers
                    .Count(y => y.TestQuestion.Question.Unit.Id == x.Id &&
                        y.DateAnswer > dateTimePicker1.Value &&
                        y.DateAnswer < dateTimePicker2.Value);

                list.Add(a / b * 100);
            });

            var seriesArray = _units.Select(x => x.Name).ToArray();
            var pointsArray = list.ToArray();


            chart.Titles.Add("Статистика по разделам");
            chart.Series.Clear();

            for (var i = 0; i < seriesArray.Length; i++)
            {
                var series = chart.Series.Add(seriesArray[i]);
                series.Points.Add(pointsArray[i]);
            }
        }

        private void buttonShow_Click(object sender, System.EventArgs e)
        {
            DrowChart();
        }
    }
}
