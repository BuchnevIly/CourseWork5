using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CourseWork5
{
    class Question : Entity, IEntity
    {
        public int id { get; set; } = 0;

        public TypeQuestion type { get; set; }

        public Unit unit { get; set; }

        public int id_teacher { get; set; }

        public string text_question { get; set; }

        public List<Answer> answers { get; set; }


        public void Load()
        {
            if (id != 0)
            {
                var sqlCmd = new SqlCommand("get_question", cnn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dataReader = sqlCmd.ExecuteReader();

                dataReader.Read();

                TypeQuestion typeQuestion = new TypeQuestion();
                typeQuestion.id = (int)dataReader.GetValue(1);
                typeQuestion.Load();
                type = typeQuestion;

                Unit mUnit = new Unit();
                mUnit.Id = (int)dataReader.GetValue(2);
                mUnit.Load();
                unit = mUnit;

                id_teacher = (int)dataReader.GetValue(3);

                text_question = dataReader.GetValue(4).ToString();

                dataReader.Close();

                GetAllAnswer();
            }
        }

        public void Save()
        {
            var sqlCmd = new SqlCommand("add_new_question", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.AddWithValue("@id_question", id);
            sqlCmd.Parameters.AddWithValue("@id_type", type.id);
            sqlCmd.Parameters.AddWithValue("@id_unit", unit.Id);
            sqlCmd.Parameters.AddWithValue("@id_teacher", id_teacher);
            sqlCmd.Parameters.AddWithValue("@text_question", text_question);
            sqlCmd.ExecuteNonQuery();
        }

        public void Update()
        {
            var sqlCmd = new SqlCommand("update_question", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.AddWithValue("@id_question", id);
            sqlCmd.Parameters.AddWithValue("@id_type", type.id);
            sqlCmd.Parameters.AddWithValue("@id_unit", unit.Id);
            sqlCmd.Parameters.AddWithValue("@id_teacher", id_teacher);
            sqlCmd.Parameters.AddWithValue("@text_question", text_question);
            sqlCmd.ExecuteNonQuery();
        }

        public List<Question> GetAll()
        {
            var sqlCmd = new SqlCommand("get_question", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dataReader = sqlCmd.ExecuteReader();

            List<Question> list = new List<Question>();

            while ( dataReader.Read() )
            {
                Question question = new Question();
                
                TypeQuestion typeQuestion = new TypeQuestion();
                typeQuestion.id = (int)dataReader.GetValue(1);
                typeQuestion.Load();
                question.type = typeQuestion;

                Unit mUnit = new Unit();
                mUnit.Id = (int)dataReader.GetValue(2);
                mUnit.Load();
                question.unit = mUnit;

                question.id_teacher = (int)dataReader.GetValue(3);
                question.text_question = dataReader.GetValue(4).ToString();

                list.Add(question);
            }
            dataReader.Close();
            return list;
        }

        private void GetAllAnswer()
        {
            Answer answer = new Answer();
            answers = answer.GetAll().Where(x => x.id_question == id).ToList();
        }
    }
}
