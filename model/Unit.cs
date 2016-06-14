using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace Model
{
    public class Unit : Entity, IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Question> Questions;

        public void Load()
        {
            if (Id == 0)
                return;

            var sqlCmd = new SqlCommand("load_unit", cnn) {CommandType = CommandType.StoredProcedure};
            sqlCmd.Parameters.AddWithValue("@id", Id);

            var dataReader = sqlCmd.ExecuteReader();
            dataReader.Read();
            Name = dataReader.GetValue(1).ToString();
            dataReader.Close();

            GetQuestion();

        }

        public void Save()
        {
            var sqlCmd = new SqlCommand("add_new_unit", cnn) {CommandType = CommandType.StoredProcedure};
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.AddWithValue("@name", Name);
            sqlCmd.ExecuteNonQuery();
        }

        public void Update()
        {
            var sqlCmd = new SqlCommand("update_unit", cnn) {CommandType = CommandType.StoredProcedure};
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.AddWithValue("@id", Id);
            sqlCmd.Parameters.AddWithValue("@name", Name);
            sqlCmd.ExecuteNonQuery();
        }

        public static List<Unit> GetAll()
        {
            var sqlCmd = new SqlCommand("get_all_unit", cnn) {CommandType = CommandType.StoredProcedure};
            var dataReader = sqlCmd.ExecuteReader();

            var list = new List<Unit>();

            while (dataReader.Read())
            {
                var unit = new Unit
                {
                    Id = (int) dataReader.GetValue(0),
                    Name = dataReader.GetValue(1).ToString()
                };
                list.Add(unit);
            }

            dataReader.Close();

            list.ForEach(x => x.GetQuestion());
            return list;
        }

        private void GetQuestion()
        {
            Questions = Question.GetAll().Where(x => x.IdUnit == Id).ToList();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
