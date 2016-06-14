using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CourseWork5
{
    class Answer : Entity , IEntity
    {
        public int id_answer { get; set; } = 0;

        public int id_question { get; set; } = 0;

        public string text_answer { get; set; }

        public bool true_answer { get; set; }

        public void Load()
        {
            if (id_answer != 0)
                return;

            var sqlCmd = new SqlCommand("load_answer", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dataReader = sqlCmd.ExecuteReader();

            dataReader.Read();

            id_answer = (int)dataReader.GetValue(0);
            id_question = (int)dataReader.GetValue(1);
            text_answer = dataReader.GetValue(2).ToString();
            true_answer = (bool)dataReader.GetValue(3);

            dataReader.Close();
        }

        public void Save()
        {
            var sqlCmd = new SqlCommand("add_new_question", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.AddWithValue("@id_answer", id_answer);
            sqlCmd.Parameters.AddWithValue("@id_question", id_question);
            sqlCmd.Parameters.AddWithValue("@text_answer", text_answer);
            sqlCmd.Parameters.AddWithValue("@true_answer", true_answer);
            sqlCmd.ExecuteNonQuery();
        }

        public void Update()
        {
            var sqlCmd = new SqlCommand("update_question", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.AddWithValue("@id_answer", id_answer);
            sqlCmd.Parameters.AddWithValue("@id_question", id_question);
            sqlCmd.Parameters.AddWithValue("@text_answer", text_answer);
            sqlCmd.Parameters.AddWithValue("@true_answer", true_answer);
            sqlCmd.ExecuteNonQuery();
        }

        public List<Answer> GetAll()
        {
            var sqlCmd = new SqlCommand("get_all_answer", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dataReader = sqlCmd.ExecuteReader();

            List<Answer> list = new List<Answer>();

            while (dataReader.Read())
            {
                Answer answer = new Answer();

                id_answer = (int)dataReader.GetValue(0);
                id_question = (int)dataReader.GetValue(1);
                text_answer = dataReader.GetValue(2).ToString();
                true_answer = (bool)dataReader.GetValue(3);

                list.Add(answer);
            }
            dataReader.Close();
            return list;
        }
    }
}
