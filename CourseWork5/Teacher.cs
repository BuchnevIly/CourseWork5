using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork5
{
    class Teacher : Entity, IEntity
    {
        public int Id { get; set; } = 0;
        
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public void Load()
        {
            if (Id != 0)
            {
                var sqlCmd = new SqlCommand("load_teacher", cnn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dataReader = sqlCmd.ExecuteReader();

                dataReader.Read();

                Id = (int)dataReader.GetValue(0);
                Name = dataReader.GetValue(1).ToString();
                LastName = dataReader.GetValue(2).ToString();

                dataReader.Close();
            }
        }

        public void Save()
        {
            var sqlCmd = new SqlCommand("add_new_teacher", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Clear();

            sqlCmd.Parameters.AddWithValue("@name", Name);
            sqlCmd.Parameters.AddWithValue("@last_name", LastName);
            sqlCmd.Parameters.AddWithValue("@password", Password);


            SqlParameter retval = new SqlParameter();
            retval.Direction = ParameterDirection.Output;
            retval.ParameterName = "@id_teacher";
            retval.SqlDbType = SqlDbType.Int;
            sqlCmd.Parameters.Add(retval);
            sqlCmd.ExecuteNonQuery();

            Id = (int)retval.Value;
            sqlCmd.ExecuteNonQuery();
        }

        public void Update()
        {
            var sqlCmd = new SqlCommand("update_teacher", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.AddWithValue("@name", Name);
            sqlCmd.Parameters.AddWithValue("@last_name", LastName);
            sqlCmd.Parameters.AddWithValue("@id_teacher", Id);
            sqlCmd.ExecuteNonQuery();
        }

        public List<Teacher> GetAll()
        {
            var sqlCmd = new SqlCommand("get_all_teacher", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dataReader = sqlCmd.ExecuteReader();

            List<Teacher> list = new List<Teacher>();

            while (dataReader.Read())
            {
                Teacher teacher = new Teacher();
                teacher.Id = (int)dataReader.GetValue(0);
                teacher.Name = dataReader.GetValue(1).ToString();
                teacher.LastName = dataReader.GetValue(2).ToString();

                list.Add(teacher);
            }
            dataReader.Close();
            return list;
        }

        public void ChangePassword(string newPassword, string oldPassword)
        {
            var sqlCmd = new SqlCommand("change_password", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.AddWithValue("@id_teacher", Id);
            sqlCmd.Parameters.AddWithValue("@old_password", oldPassword);
            sqlCmd.Parameters.AddWithValue("@new_password", newPassword);
            sqlCmd.ExecuteNonQuery();
        }
    }
}
