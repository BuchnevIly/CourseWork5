using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace CourseWork5
{
    class Unit : Entity, IEntity
    {
        public int Id { get; set; } = 0;

        public string Name { get; set; }

        public void Load()
        {
            if (Id == 0)
                return;

            var sqlCmd = new SqlCommand("load_unit", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.AddWithValue("@id", Id);

            SqlDataReader dataReader = sqlCmd.ExecuteReader();
            dataReader.Read();
            Name = dataReader.GetValue(1).ToString();
            dataReader.Close();

        }

        public void Save()
        {
            var sqlCmd = new SqlCommand("add_new_unit", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.AddWithValue("@name", Name);
            sqlCmd.ExecuteNonQuery();
        }

        public void Update()
        {
            var sqlCmd = new SqlCommand("update_unit", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.AddWithValue("@id", Id);
            sqlCmd.Parameters.AddWithValue("@name", Name);
            sqlCmd.ExecuteNonQuery();
        }

        public static List<Unit> GetAll()
        {
            var sqlCmd = new SqlCommand("get_all_unit", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dataReader = sqlCmd.ExecuteReader();

            List<Unit> list = new List<Unit>();

            while (dataReader.Read())
            {
                Unit unit = new Unit();
                unit.Id = (int)dataReader.GetValue(0);
                unit.Name = dataReader.GetValue(1).ToString();
                list.Add(unit);
            }

            dataReader.Close();
            return list;
        }
    }
}
