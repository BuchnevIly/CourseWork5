using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Model
{
    public class Group : Entity, IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void Load()
        {
            if (Id == 0)
                return;
            var sqlCmd = new SqlCommand("load_group", Cnn) {CommandType = CommandType.StoredProcedure};
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.AddWithValue("@id_group", Id);
            SqlDataReader dataReader = sqlCmd.ExecuteReader();

            dataReader.Read();

            Id = (int)dataReader.GetValue(0);
            Name = dataReader.GetValue(1).ToString();

            dataReader.Close();
        }

        public void Save()
        {
            var sqlCmd = new SqlCommand("add_new_group", Cnn) {CommandType = CommandType.StoredProcedure};
            sqlCmd.Parameters.Clear();

            sqlCmd.Parameters.AddWithValue("@name", Name);

            var retval = new SqlParameter
            {
                Direction = ParameterDirection.Output,
                ParameterName = "@id_group",
                SqlDbType = SqlDbType.Int
            };
            sqlCmd.Parameters.Add(retval);
            sqlCmd.ExecuteNonQuery();

            Id = (int)retval.Value;
        }

        public void Update()
        {
            var sqlCmd = new SqlCommand("update_group", Cnn) {CommandType = CommandType.StoredProcedure};
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.AddWithValue("@id_group", Id);
            sqlCmd.Parameters.AddWithValue("@name", Name);
            sqlCmd.ExecuteNonQuery();
        }

        public void Delete()
        {
            var sqlCmd = new SqlCommand("delete_group", Cnn) { CommandType = CommandType.StoredProcedure };
            sqlCmd.Parameters.AddWithValue("@id_group", Id);
            sqlCmd.ExecuteNonQuery();
        }

        public static List<Group> GetAll()
        {
            var sqlCmd = new SqlCommand("get_all_group", Cnn) {CommandType = CommandType.StoredProcedure};
            var dataReader = sqlCmd.ExecuteReader();
            var list = new List<Group>();

            while (dataReader.Read())
            {
                var group = new Group
                {
                    Id = (int) dataReader.GetValue(0),
                    Name = dataReader.GetValue(1).ToString()
                };
                list.Add(group);
            }
            dataReader.Close();
            return list;
        }

        public List<Student> GetStudents()
        {
            return Student.GetAll().Where(x => x.Group.Id == Id).ToList();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
