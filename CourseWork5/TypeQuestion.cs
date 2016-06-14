using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork5
{
    class TypeQuestion : Entity, IEntity
    {
        public int id { get; set; } = 0;

        public string name { get; set; }

        public void Load()
        {
            if (id != 0)
                return;
            var sqlCmd = new SqlCommand("load_type_question", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.AddWithValue("@id", id);
            sqlCmd.Parameters.AddWithValue("@name", id);
            sqlCmd.ExecuteNonQuery();
        }

        public List<TypeQuestion> GetAll()
        {
            var sqlCmd = new SqlCommand("get_all_type_question", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dataReader = sqlCmd.ExecuteReader();

            List<TypeQuestion> list = new List<TypeQuestion>();

            while (dataReader.Read())
            {
                TypeQuestion typeQuestion = new TypeQuestion();
                typeQuestion.id = (int)dataReader.GetValue(0);
                typeQuestion.name = dataReader.GetValue(1).ToString();
                list.Add(typeQuestion);
            }

            dataReader.Close();
            return list;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
