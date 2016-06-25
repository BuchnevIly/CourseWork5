using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Model
{
    public class Test : Entity , IEntity
    {


        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime TestDataStart { get; set; }

        public DateTime TestDataEnd { get; set; }

        public Group Group { get; set; }


        public void Load()
        {
            if (Id == 0)
                return;

            var sqlCmd = new SqlCommand("load_test", Cnn) {CommandType = CommandType.StoredProcedure};
            var dataReader = sqlCmd.ExecuteReader();

            dataReader.Read();

            Id = (int)dataReader.GetValue(0);
            Name = dataReader.GetValue(1).ToString();
            TestDataStart = (DateTime)dataReader.GetValue(3);
            TestDataEnd = (DateTime)dataReader.GetValue(4);
            Group = new Group {Id = (int)dataReader.GetValue(5)};
            dataReader.Close();

            Group.Load();
        }

        public void Save()
        {
            var sqlCmd = new SqlCommand("add_new_test", Cnn) {CommandType = CommandType.StoredProcedure};
            sqlCmd.Parameters.AddWithValue("@name", Name);
            sqlCmd.Parameters.AddWithValue("@test_date_start", TestDataStart);
            sqlCmd.Parameters.AddWithValue("@test_date_end", TestDataEnd);
            sqlCmd.Parameters.AddWithValue("@id_group", Group.Id);

            var retval = new SqlParameter
            {
                Direction = ParameterDirection.Output,
                ParameterName = "@id_test",
                SqlDbType = SqlDbType.Int
            };

            sqlCmd.Parameters.Add(retval);
            sqlCmd.ExecuteNonQuery();

            Id = (int)retval.Value;
        }

        public void Update()
        {
            var sqlCmd = new SqlCommand("update_test", Cnn) {CommandType = CommandType.StoredProcedure};
            sqlCmd.Parameters.Clear();

            sqlCmd.Parameters.AddWithValue("@id_test", Id);
            sqlCmd.Parameters.AddWithValue("@name", Name);
            sqlCmd.Parameters.AddWithValue("@test_date_start", TestDataStart);
            sqlCmd.Parameters.AddWithValue("@test_date_end", TestDataEnd);
            sqlCmd.Parameters.AddWithValue("@id_group", Group.Id);

            sqlCmd.ExecuteNonQuery();
        }

        public void Delete()
        {
            var sqlCmd = new SqlCommand("delete_test", Cnn) { CommandType = CommandType.StoredProcedure };
            sqlCmd.Parameters.AddWithValue("@id_test", Id);
            sqlCmd.ExecuteNonQuery();
        }

        public static List<Test> GetAll()
        {
            var sqlCmd = new SqlCommand("get_all_test", Cnn) {CommandType = CommandType.StoredProcedure};
            var dataReader = sqlCmd.ExecuteReader();
            var list = new List<Test>();

            while (dataReader.Read())
            {
                var test = new Test
                {
                    Id = (int) dataReader.GetValue(0),
                    Name = dataReader.GetValue(1).ToString(),
                    TestDataStart = (DateTime) dataReader.GetValue(2),
                    TestDataEnd = (DateTime) dataReader.GetValue(3),
                    Group = new Group { Id = (int)dataReader.GetValue(4) }
                };
                list.Add(test);
            }

            dataReader.Close();

            
            list.ForEach(x =>
            {
                x.Group.Load();
                x.GetTestQuestions();
            });

            return list;
        }

        public List<TestQuestion> GetTestQuestions()
        {
            return TestQuestion.GetAll().Where(x => x.IdTest == Id).ToList();
        }
    }
}
