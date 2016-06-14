using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Model
{
    public class Question : Entity, IEntity
    {
        public int Id { get; set; } = 0;

        public TypeQuestion Type { get; set; }

        public int IdUnit { get; set; }

        public int IdTeacher { get; set; }

        public string TextQuestion { get; set; }

        public List<Answer> Answers { get; set; }

        public Question()
        {
            Initialize();
            Answers = new List<Answer>();
        }


        public void Load()
        {
            if (Id != 0)
                return;

            var sqlCmd = new SqlCommand("get_question", cnn) {CommandType = CommandType.StoredProcedure};
            var dataReader = sqlCmd.ExecuteReader();

            dataReader.Read();

            var typeQuestion = new TypeQuestion {Id = (int) dataReader.GetValue(1)};
            typeQuestion.Load();
            Type = typeQuestion;

            IdUnit = (int)dataReader.GetValue(2);

            IdTeacher = (int)dataReader.GetValue(3);

            TextQuestion = dataReader.GetValue(4).ToString();

            dataReader.Close();

            GetAllAnswer();
        }

        public void Save()
        {
            var sqlCmd = new SqlCommand("add_new_question", cnn) {CommandType = CommandType.StoredProcedure};
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.AddWithValue("@id_type", Type.Id);
            sqlCmd.Parameters.AddWithValue("@id_unit", IdUnit);
            sqlCmd.Parameters.AddWithValue("@id_teacher", IdTeacher);
            sqlCmd.Parameters.AddWithValue("@text_question", TextQuestion);

            var retval = new SqlParameter
            {
                Direction = ParameterDirection.Output,
                ParameterName = "@id_question",
                SqlDbType = SqlDbType.Int
            };
            sqlCmd.Parameters.Add(retval);
            sqlCmd.ExecuteNonQuery();

            Id = (int)retval.Value;
            
        }

        public void Update()
        {
            var sqlCmd = new SqlCommand("update_question", cnn) {CommandType = CommandType.StoredProcedure};
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.AddWithValue("@id_question", Id);
            sqlCmd.Parameters.AddWithValue("@id_type", Type.Id);
            sqlCmd.Parameters.AddWithValue("@id_unit", IdUnit);
            sqlCmd.Parameters.AddWithValue("@id_teacher", IdTeacher);
            sqlCmd.Parameters.AddWithValue("@text_question", TextQuestion);
            sqlCmd.ExecuteNonQuery();
        }

        public static List<Question> GetAll()
        {
            var sqlCmd = new SqlCommand("get_all_question", cnn) {CommandType = CommandType.StoredProcedure};
            sqlCmd.Parameters.Clear();
            var dataReader = sqlCmd.ExecuteReader();

            var list = new List<Question>();

            while ( dataReader.Read() )
            {
                var question = new Question
                {
                    Id = (int)dataReader.GetValue(0),
                    IdTeacher = (int)dataReader.GetValue(3),
                    TextQuestion = dataReader.GetValue(4).ToString(),
                    IdUnit = (int)dataReader.GetValue(2),
                    Type = new TypeQuestion { Id = (int)dataReader.GetValue(1) }
                };
                list.Add(question);
            }
            dataReader.Close();

            list.ForEach(x => x.Type.Load());
            list.ForEach(x => x.GetAllAnswer());
            return list;
        }

        private void GetAllAnswer()
        {
            Answers = Answer.GetAll().Where(x => x.IdQuestion == Id).ToList();
        }
    }
}
