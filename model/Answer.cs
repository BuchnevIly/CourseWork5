using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Model
{
    public class Answer : Entity , IEntity
    {
        public int Id { get; set; }

        public int IdQuestion { get; set; }

        public string TextAnswer { get; set; }

        public bool TrueAnswer { get; set; }

        public void Load()
        {
            if (Id == 0)
                return;

            var sqlCmd = new SqlCommand("load_answer", Cnn) {CommandType = CommandType.StoredProcedure};
            var dataReader = sqlCmd.ExecuteReader();

            dataReader.Read();

            IdQuestion = (int)dataReader.GetValue(1);
            TextAnswer = dataReader.GetValue(2).ToString();
            TrueAnswer = (bool)dataReader.GetValue(3);

            dataReader.Close();
        }

        public void Save()
        {
            var sqlCmd = new SqlCommand("add_new_answer", Cnn) {CommandType = CommandType.StoredProcedure};
            sqlCmd.Parameters.AddWithValue("@id_question", IdQuestion);
            sqlCmd.Parameters.AddWithValue("@text_answer", TextAnswer);
            sqlCmd.Parameters.AddWithValue("@true_answer", TrueAnswer);

            var retval = new SqlParameter
            {
                Direction = ParameterDirection.Output,
                ParameterName = "@id_answer",
                SqlDbType = SqlDbType.Int
            };

            sqlCmd.Parameters.Add(retval);
            sqlCmd.ExecuteNonQuery();

            Id = (int)retval.Value;
        }

        public void Update()
        {
            var sqlCmd = new SqlCommand("update_answer", Cnn) {CommandType = CommandType.StoredProcedure};
            sqlCmd.Parameters.AddWithValue("@id_answer", Id);
            sqlCmd.Parameters.AddWithValue("@id_question", IdQuestion);
            sqlCmd.Parameters.AddWithValue("@text_answer", TextAnswer);
            sqlCmd.Parameters.AddWithValue("@true_answer", TrueAnswer);
            sqlCmd.ExecuteNonQuery();
        }

        public void Delete()
        {
            var sqlCmd = new SqlCommand("delete_answer", Cnn) { CommandType = CommandType.StoredProcedure };
            sqlCmd.Parameters.AddWithValue("@id_answer", Id);
            sqlCmd.ExecuteNonQuery();
        }

        public static List<Answer> GetAll()
        {
            var sqlCmd = new SqlCommand("get_all_answer", Cnn) {CommandType = CommandType.StoredProcedure};
            var dataReader = sqlCmd.ExecuteReader();
            var list = new List<Answer>();

            while (dataReader.Read())
            {
                var answer = new Answer
                {
                    Id = (int) dataReader.GetValue(0),
                    IdQuestion = (int) dataReader.GetValue(1),
                    TextAnswer = dataReader.GetValue(2).ToString(),
                    TrueAnswer = (bool) dataReader.GetValue(3)
                };
                list.Add(answer);
            }
            dataReader.Close();
            return list;
        }
    }
}
