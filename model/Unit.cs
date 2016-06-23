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

        public List<Question> GetQuestions()
        {
            return Question.GetAll().Where(x => x.Unit.Id == Id).ToList();
        }

        public void Load()
        {
            if (Id == 0)
                return;

            var sqlCmd = new SqlCommand("load_unit", Cnn) {CommandType = CommandType.StoredProcedure};
            sqlCmd.Parameters.AddWithValue("@id_unit", Id);

            var dataReader = sqlCmd.ExecuteReader();
            dataReader.Read();
            Name = dataReader.GetValue(1).ToString();
            dataReader.Close();
        }

        public void Save()
        {
            var sqlCmd = new SqlCommand("add_new_unit", Cnn) {CommandType = CommandType.StoredProcedure};
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.AddWithValue("@name", Name);
            var retval = new SqlParameter
            {
                Direction = ParameterDirection.Output,
                ParameterName = "@id_unit",
                SqlDbType = SqlDbType.Int
            };
            sqlCmd.Parameters.Add(retval);
            sqlCmd.ExecuteNonQuery();

            Id = (int)retval.Value;
        }

        public void Update()
        {
            var sqlCmd = new SqlCommand("update_unit", Cnn) {CommandType = CommandType.StoredProcedure};
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.AddWithValue("@id_unit", Id);
            sqlCmd.Parameters.AddWithValue("@name", Name);
            sqlCmd.ExecuteNonQuery();
        }

        public void Delete()
        {
            var sqlCmd = new SqlCommand("delete_unit", Cnn) { CommandType = CommandType.StoredProcedure };
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.AddWithValue("@id_unit", Id);
            sqlCmd.ExecuteNonQuery();
        }

        public static List<Unit> GetAll()
        {
            var sqlCmd = new SqlCommand("get_all_unit", Cnn) {CommandType = CommandType.StoredProcedure};
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
            return list;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
