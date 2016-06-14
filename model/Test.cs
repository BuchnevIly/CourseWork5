using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Test : Entity , IEntity
    {
        public int Id { get; set; } = 0;

        public string Name { get; set; }

        public DateTime TestData { get; set; }

        public List<TestQuestion> TestQuestions { get; set; }

        public void Load()
        {
            if (Id == 0)
                return;

            var sqlCmd = new SqlCommand("load_test", cnn) {CommandType = CommandType.StoredProcedure};
            var dataReader = sqlCmd.ExecuteReader();

            dataReader.Read();

            Id = (int)dataReader.GetValue(0);
            Name = dataReader.GetValue(1).ToString();
            TestData = (DateTime)dataReader.GetValue(3);
            dataReader.Close();

            GetTestQuestions();
        }

        public void Save()
        {
            var sqlCmd = new SqlCommand("add_new_test", cnn) {CommandType = CommandType.StoredProcedure};
            sqlCmd.Parameters.AddWithValue("@name", Name);
            sqlCmd.Parameters.AddWithValue("@test_date", TestData);

            var retval = new SqlParameter
            {
                Direction = ParameterDirection.Output,
                ParameterName = "@id_test",
                SqlDbType = SqlDbType.Int
            };

            sqlCmd.Parameters.Add(retval);
            sqlCmd.ExecuteNonQuery();

            Id = (int)retval.Value;

            sqlCmd.ExecuteNonQuery();
        }

        public void Update()
        {
            var sqlCmd = new SqlCommand("update_test", cnn) {CommandType = CommandType.StoredProcedure};
            sqlCmd.Parameters.Clear();

            sqlCmd.Parameters.AddWithValue("@id_test", Id);
            sqlCmd.Parameters.AddWithValue("@name", Name);
            sqlCmd.Parameters.AddWithValue("@test_date", TestData);

            sqlCmd.ExecuteNonQuery();
        }

        public static List<Test> GetAll()
        {
            var sqlCmd = new SqlCommand("get_all_test", cnn) {CommandType = CommandType.StoredProcedure};
            var dataReader = sqlCmd.ExecuteReader();
            var list = new List<Test>();

            while (dataReader.Read())
            {
                var test = new Test
                {
                    Id = (int) dataReader.GetValue(0),
                    Name = dataReader.GetValue(1).ToString(),
                    TestData = (DateTime) dataReader.GetValue(3)
                };
                list.Add(test);
            }

            dataReader.Close();

            list.ForEach(x => x.GetTestQuestions());

            return list;
        }

        private void GetTestQuestions()
        {
            var testQuestion = new TestQuestion();
            TestQuestions = testQuestion.GetAll().Where(x => x.IdTest == Id).ToList();
        }
    }
}
