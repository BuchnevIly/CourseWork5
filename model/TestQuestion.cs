using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Model
{
    public class TestQuestion : Entity, IEntity
    {
        public int Id { get; set; } 

        public Question Question { get; set; }

        public int IdTeacher { get; set; }

        public int IdTest { get; set; }

        public void Load()
        {
            if (Id == 0)
                return;
            var sqlCmd = new SqlCommand("load_test_question", cnn) {CommandType = CommandType.StoredProcedure};
            var dataReader = sqlCmd.ExecuteReader();

            dataReader.Read();

            Id = (int)dataReader.GetValue(0);

            var question = new Question {Id = (int) dataReader.GetValue(2)};
            question.Load();
            Question = question;

            IdTeacher = (int)dataReader.GetValue(3);
            IdTest = (int)dataReader.GetValue(1); 

            dataReader.Close();
        }

        public void Save()
        {
            var sqlCmd = new SqlCommand("add_new_test_question", cnn) {CommandType = CommandType.StoredProcedure};
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.AddWithValue("@id_question", Question.Id);
            sqlCmd.Parameters.AddWithValue("@id_teacher", IdTeacher);
            sqlCmd.Parameters.AddWithValue("@id_test", IdTest);

            var retval = new SqlParameter
            {
                Direction = ParameterDirection.Output,
                ParameterName = "@id_test_question",
                SqlDbType = SqlDbType.Int
            };
            sqlCmd.Parameters.Add(retval);
            sqlCmd.ExecuteNonQuery();

            Id = (int)retval.Value;
        }

        public void Update()
        {
            var sqlCmd = new SqlCommand("update_test_question", cnn) {CommandType = CommandType.StoredProcedure};
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.AddWithValue("@id_question", Question.Id);
            sqlCmd.Parameters.AddWithValue("@id_teacher", IdTeacher);
            sqlCmd.Parameters.AddWithValue("@id_test", IdTest);
            sqlCmd.Parameters.AddWithValue("@id_test_question", Id);
            sqlCmd.ExecuteNonQuery();
        }

        public void Delete()
        {
            var sqlCmd = new SqlCommand("delete_test_question", cnn) { CommandType = CommandType.StoredProcedure };
            sqlCmd.Parameters.AddWithValue("@id_test_question", Id);
            sqlCmd.ExecuteNonQuery();
        }

        public static List<TestQuestion> GetAll()
        {
            var sqlCmd = new SqlCommand("get_all_test_question", cnn) {CommandType = CommandType.StoredProcedure};
            var dataReader = sqlCmd.ExecuteReader();

            var list = new List<TestQuestion>();

            while (dataReader.Read())
            {
                var question = new Question { Id = (int)dataReader.GetValue(2) };
                question.Load();
                var testQuestion = new TestQuestion
                {
                    Id = (int)dataReader.GetValue(0),
                    Question = question,
                    IdTeacher = (int)dataReader.GetValue(3),
                    IdTest = (int)dataReader.GetValue(1)
                };
                list.Add(testQuestion);
            }
            dataReader.Close();
            return list;
        }


    }
}
