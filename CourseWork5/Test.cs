using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork5
{
    class Test : Entity , IEntity
    {
        public int Id { get; set; } = 0;

        public string Name { get; set; }

        public DateTime TestData { get; set; }

        public List<TestQuestion> TestQuestions { get; set; }

        public void Load()
        {
            if (Id != 0)
            {
                var sqlCmd = new SqlCommand("load_test", cnn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dataReader = sqlCmd.ExecuteReader();

                dataReader.Read();

                Id = (int)dataReader.GetValue(0);
                Name = dataReader.GetValue(1).ToString();
                TestData = (DateTime)dataReader.GetValue(3);
                dataReader.Close();

                GetTestQuestions();
            }
        }

        public void Save()
        {
            var sqlCmd = new SqlCommand("add_new_test", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Clear();

            sqlCmd.Parameters.AddWithValue("@name", Name);
            sqlCmd.Parameters.AddWithValue("@test_date", TestData);

            SqlParameter retval = new SqlParameter();
            retval.Direction = ParameterDirection.Output;
            retval.ParameterName = "@id_test";
            retval.SqlDbType = SqlDbType.Int;
            sqlCmd.Parameters.Add(retval);
            sqlCmd.ExecuteNonQuery();

            Id = (int)retval.Value;

            sqlCmd.ExecuteNonQuery();
        }

        public void Update()
        {
            var sqlCmd = new SqlCommand("update_test", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Clear();

            sqlCmd.Parameters.AddWithValue("@id_test", Id);
            sqlCmd.Parameters.AddWithValue("@name", Name);
            sqlCmd.Parameters.AddWithValue("@test_date", TestData);

            sqlCmd.ExecuteNonQuery();
        }

        public List<Test> GetAll()
        {
            var sqlCmd = new SqlCommand("get_all_test", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dataReader = sqlCmd.ExecuteReader();

            List<Test> list = new List<Test>();

            while (dataReader.Read())
            {
                Test test = new Test();

                test.Id = (int)dataReader.GetValue(0);
                test.Name = dataReader.GetValue(1).ToString();
                test.TestData = (DateTime)dataReader.GetValue(3);

                list.Add(test);
            }

            dataReader.Close();
            return list;
        }

        private void GetTestQuestions()
        {
            TestQuestion testQuestion = new TestQuestion();
            TestQuestions = testQuestion.GetAll().Where(x => x.IdTest == Id).ToList();
        }
    }
}
