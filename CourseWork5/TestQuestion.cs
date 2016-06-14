using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork5
{
    class TestQuestion : Entity, IEntity
    {
        public int Id { get; set; } = 0;

        public Question Question { get; set; }

        public int IdTeacher { get; set; }

        public int IdTest { get; set; }

        public void Load()
        {
            if (Id != 0)
            {
                var sqlCmd = new SqlCommand("load_test_question", cnn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dataReader = sqlCmd.ExecuteReader();

                dataReader.Read();

                Id = (int)dataReader.GetValue(0);

                Question question = new Question();
                question.id = (int)dataReader.GetValue(2);
                question.Load();
                Question = question;

                IdTeacher = (int)dataReader.GetValue(3);
                IdTest = (int)dataReader.GetValue(1); 

                dataReader.Close();
            }
        }

        public void Save()
        {
            var sqlCmd = new SqlCommand("add_new_test_question", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.AddWithValue("@id_question", Question.id);
            sqlCmd.Parameters.AddWithValue("@id_teacher", IdTeacher);
            sqlCmd.Parameters.AddWithValue("@id_test", IdTest);

            SqlParameter retval = new SqlParameter();
            retval.Direction = ParameterDirection.Output;
            retval.ParameterName = "@id_test_question";
            retval.SqlDbType = SqlDbType.Int;
            sqlCmd.Parameters.Add(retval);
            sqlCmd.ExecuteNonQuery();

            Id = (int)retval.Value;
            sqlCmd.ExecuteNonQuery();
        }

        public void Update()
        {
            var sqlCmd = new SqlCommand("update_test_question", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.AddWithValue("@id_question", Question.id);
            sqlCmd.Parameters.AddWithValue("@id_teacher", IdTeacher);
            sqlCmd.Parameters.AddWithValue("@id_test", IdTest);
            sqlCmd.Parameters.AddWithValue("@id_test_question", Id);
            sqlCmd.ExecuteNonQuery();
        }

        public List<TestQuestion> GetAll()
        {
            var sqlCmd = new SqlCommand("get_all_test_question", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dataReader = sqlCmd.ExecuteReader();

            List<TestQuestion> list = new List<TestQuestion>();

            while (dataReader.Read())
            {
                TestQuestion testQuestion = new TestQuestion();

                Id = (int)dataReader.GetValue(0);

                Question question = new Question();
                question.id = (int)dataReader.GetValue(2);
                question.Load();
                Question = question;

                IdTeacher = (int)dataReader.GetValue(3);
                IdTest = (int)dataReader.GetValue(1);

                list.Add(testQuestion);
            }
            dataReader.Close();
            return list;
        }


    }
}
