using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Group : Entity, IEntity
    {
        public int Id { get; set; } = 0;

        public string Name { get; set; }

        public List<Student> students;

        public void Load()
        {
            if (Id != 0)
                return;
            var sqlCmd = new SqlCommand("load_group", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.AddWithValue("@id_group", Id);
            SqlDataReader dataReader = sqlCmd.ExecuteReader();

            dataReader.Read();

            Id = (int)dataReader.GetValue(0);
            Name = dataReader.GetValue(1).ToString();

            dataReader.Close();

            GetStudents();
        }

        public void Save()
        {
            var sqlCmd = new SqlCommand("add_new_group", cnn) {CommandType = CommandType.StoredProcedure};
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
            sqlCmd.ExecuteNonQuery();
        }

        public void Update()
        {
            var sqlCmd = new SqlCommand("update_group", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.AddWithValue("@id_group", Id);
            sqlCmd.Parameters.AddWithValue("@name", Name);
            sqlCmd.ExecuteNonQuery();
        }

        public List<Group> GetAll()
        {
            var sqlCmd = new SqlCommand("get_all_group", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dataReader = sqlCmd.ExecuteReader();

            List<Group> list = new List<Group>();

            while (dataReader.Read())
            {
                Group group = new Group();
                group.Id = (int)dataReader.GetValue(0);
                group.Name = dataReader.GetValue(1).ToString();

                list.Add(group);
            }
            dataReader.Close();
            return list;
        }

        private void GetStudents()
        {
            Student student = new Student();
            students = student.GetAll().Where(x => x.Group.Id == Id).ToList();
        }
    }
}
