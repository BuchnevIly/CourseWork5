using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork5
{
    class StudentsAnswer : Entity, IEntity
    {
        public int Id { get; set; } = 0;

        public TestQuestion TestQuestion { get; set; }

        public Student Student { get; set; }

        public DateTime DateAnswer { get; set; }

        public void Load()
        {
            if (Id == 0)
                return;
            
            var sqlCmd = new SqlCommand("get_student_answer", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dataReader = sqlCmd.ExecuteReader();
            dataReader.Read();

            Id = (int)dataReader.GetValue(0);

            TestQuestion testQuestion = new TestQuestion();
            testQuestion.Id = (int)dataReader.GetValue(1);
            testQuestion.Load();
            TestQuestion = testQuestion;

            Student stutent = new Student();
            stutent.Id = (int)dataReader.GetValue(2);
            stutent.Load();
            Student = stutent;

            DateAnswer = (DateTime)dataReader.GetValue(3);

            dataReader.Close();
        }

        public void Save()
        {
            var sqlCmd = new SqlCommand("add_new_student_answer", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.AddWithValue("@id_question", TestQuestion.Id);
            sqlCmd.Parameters.AddWithValue("@id_student", Student.Id);
            sqlCmd.Parameters.AddWithValue("@date_answer", DateAnswer);

            SqlParameter retval = new SqlParameter();
            retval.Direction = ParameterDirection.Output;
            retval.ParameterName = "@id_student_answer";
            retval.SqlDbType = SqlDbType.Int;
            sqlCmd.Parameters.Add(retval);
            sqlCmd.ExecuteNonQuery();

            
            sqlCmd.ExecuteNonQuery();

            Id = (int)retval.Value;
        }

        public void Update()
        {
            var sqlCmd = new SqlCommand("update_student_answer", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.AddWithValue("@id_question", TestQuestion.Id);
            sqlCmd.Parameters.AddWithValue("@id_student_answer", Id);
            sqlCmd.Parameters.AddWithValue("@id_student", Student.Id);
            sqlCmd.Parameters.AddWithValue("@date_answer", DateAnswer);
            sqlCmd.ExecuteNonQuery();
        }

        public List<StudentsAnswer> GetAll()
        {
            List<StudentsAnswer> studentAnswers = new List<StudentsAnswer>();

            var sqlCmd = new SqlCommand("get_student_answer", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dataReader = sqlCmd.ExecuteReader();


            while (dataReader.Read())
            {              
                TestQuestion testQuestion = new TestQuestion();
                testQuestion.Id = (int)dataReader.GetValue(1);
                testQuestion.Load();

                Student stutent = new Student();
                stutent.Id = (int)dataReader.GetValue(2);
                stutent.Load();

                StudentsAnswer studentsAnswer = new StudentsAnswer();
                studentsAnswer.Id = (int)dataReader.GetValue(0);
                studentsAnswer.TestQuestion = testQuestion;
                studentsAnswer.Student = stutent;
                studentsAnswer.DateAnswer = (DateTime)dataReader.GetValue(3);

                studentAnswers.Add(studentsAnswer);
            }
    
            dataReader.Close();
            return studentAnswers;            
        }
    }
}
