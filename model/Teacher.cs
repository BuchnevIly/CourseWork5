using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Model
{
    public class Teacher : Entity, IEntity
    {
        public int Id { get; set; } 

        public string LoginName { get; set; }
        
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public void Load()
        {
            if (Id == 0)
                return;

            var sqlCmd = new SqlCommand("load_teacher", Cnn) {CommandType = CommandType.StoredProcedure};
            var dataReader = sqlCmd.ExecuteReader();

            dataReader.Read();

            Id = (int)dataReader.GetValue(0);
            LoginName = dataReader.GetValue(1).ToString();
            Name = dataReader.GetValue(2).ToString();
            LastName = dataReader.GetValue(3).ToString();

            dataReader.Close();
        }

        public void Save()
        {
            var sqlCmd = new SqlCommand("add_new_teacher", Cnn) {CommandType = CommandType.StoredProcedure};

            sqlCmd.Parameters.AddWithValue("@name", Name);
            sqlCmd.Parameters.AddWithValue("@login", LoginName);
            sqlCmd.Parameters.AddWithValue("@last_name", LastName);
            sqlCmd.Parameters.AddWithValue("@password", Password);


            var retval = new SqlParameter
            {
                Direction = ParameterDirection.Output,
                ParameterName = "@id_teacher",
                SqlDbType = SqlDbType.Int
            };
            sqlCmd.Parameters.Add(retval);
            sqlCmd.ExecuteNonQuery();

            Id = (int)retval.Value;
        }

        public void Update()
        {
            var sqlCmd = new SqlCommand("update_teacher", Cnn) {CommandType = CommandType.StoredProcedure};
            sqlCmd.Parameters.AddWithValue("@name", Name);
            sqlCmd.Parameters.AddWithValue("@login", LoginName);
            sqlCmd.Parameters.AddWithValue("@last_name", LastName);
            sqlCmd.Parameters.AddWithValue("@id_teacher", Id);
            sqlCmd.ExecuteNonQuery();
        }

        public void Delete()
        {
            var sqlCmd = new SqlCommand("delete_teacher", Cnn) { CommandType = CommandType.StoredProcedure };
            sqlCmd.Parameters.AddWithValue("@id_teacher", Id);
            sqlCmd.ExecuteNonQuery();
        }

        public static List<Teacher> GetAll()
        {
            var sqlCmd = new SqlCommand("get_all_teacher", Cnn) {CommandType = CommandType.StoredProcedure};
            var dataReader = sqlCmd.ExecuteReader();
            var list = new List<Teacher>();

            while (dataReader.Read())
            {
                var teacher = new Teacher
                {
                    Id = (int) dataReader.GetValue(0),
                    Name = dataReader.GetValue(2).ToString(),
                    LastName = dataReader.GetValue(3).ToString(),
                    LoginName = dataReader.GetValue(1).ToString()
                };
                list.Add(teacher);
            }
            dataReader.Close();
            return list;
        }

        public void Login()
        {
            var sqlCmd = new SqlCommand("login_teacher", Cnn) {CommandType = CommandType.StoredProcedure};
            sqlCmd.Parameters.AddWithValue("@login", LoginName);
            sqlCmd.Parameters.AddWithValue("@password", Password);
            sqlCmd.ExecuteNonQuery();
        }

        public void ResetPassword()
        {
            var sqlCmd = new SqlCommand("reser_password_teacher", Cnn) { CommandType = CommandType.StoredProcedure };
            sqlCmd.Parameters.AddWithValue("@login", LoginName);
            sqlCmd.ExecuteNonQuery();
        }

        public void ChangePassword(string newPassword, string oldPassword)
        {
            var sqlCmd = new SqlCommand("change_password", Cnn) {CommandType = CommandType.StoredProcedure};
            sqlCmd.Parameters.AddWithValue("@id_teacher", Id);
            sqlCmd.Parameters.AddWithValue("@old_password", oldPassword);
            sqlCmd.Parameters.AddWithValue("@new_password", newPassword);
            sqlCmd.ExecuteNonQuery();
        }
    }
}
