using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace Model
{
    public class Question : Entity, IEntity
    {
        public int Id { get; set; }

        public TypeQuestion Type { get; set; }

        public Unit Unit { get; set; }

        public int IdTeacher { get; set; }

        public string TextQuestion { get; set; }

        public byte[] Image { get; set; }

        public List<Answer> Answers { get; set; }

        public Question()
        {
            Initialize();
            Answers = new List<Answer>();
        }

        public void Load()
        {
            if (Id == 0)
                return;

            var sqlCmd = new SqlCommand("load_question", cnn) {CommandType = CommandType.StoredProcedure};
            sqlCmd.Parameters.AddWithValue("@id_question", Id);
            var dataReader = sqlCmd.ExecuteReader();

            dataReader.Read();

            Type = new TypeQuestion { Id = (int)dataReader.GetValue(1) };
            Unit = new Unit { Id = (int)dataReader.GetValue(2) };
            IdTeacher = (int)dataReader.GetValue(3);
            TextQuestion = dataReader.GetValue(4).ToString();
            Image = (byte[])dataReader.GetValue(5);

            dataReader.Close();

            Type.Load();
            Unit.Load();

            GetAllAnswer();
        }

        public void Save()
        {
            var sqlCmd = new SqlCommand("add_new_question", cnn) {CommandType = CommandType.StoredProcedure};
            sqlCmd.Parameters.AddWithValue("@id_type", Type.Id);
            sqlCmd.Parameters.AddWithValue("@id_unit", Unit.Id);
            sqlCmd.Parameters.AddWithValue("@id_teacher", IdTeacher);
            sqlCmd.Parameters.AddWithValue("@text_question", TextQuestion);
            sqlCmd.Parameters.AddWithValue("@image", Image);

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
            sqlCmd.Parameters.AddWithValue("@id_question", Id);
            sqlCmd.Parameters.AddWithValue("@id_type", Type.Id);
            sqlCmd.Parameters.AddWithValue("@id_unit", Unit.Id);
            sqlCmd.Parameters.AddWithValue("@id_teacher", IdTeacher);
            sqlCmd.Parameters.AddWithValue("@text_question", TextQuestion);
            sqlCmd.Parameters.AddWithValue("@image", Image);
            sqlCmd.ExecuteNonQuery();
        }

        public void Delete()
        {
            var sqlCmd = new SqlCommand("delete_question", cnn) { CommandType = CommandType.StoredProcedure };
            sqlCmd.Parameters.AddWithValue("@id_question", Id);
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
                    Unit = new Unit { Id = (int)dataReader.GetValue(2)},
                    Type = new TypeQuestion { Id = (int)dataReader.GetValue(1) },
                    Image = (byte[])dataReader.GetValue(5)
                };
                list.Add(question);
            }
            dataReader.Close();

            list.ForEach(x =>
            {
                x.Type.Load();
                x.Unit.Load();
                x.GetAllAnswer();
            });
            return list;
        }

        private void GetAllAnswer()
        {
            Answers = Answer.GetAll().Where(x => x.IdQuestion == Id).ToList();
        }
    }
}
