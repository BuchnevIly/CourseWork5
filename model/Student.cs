using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace Model
{
    public class Student : Entity, IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public Group Group { get; set; }

        public void Load()
        {
            if (Id == 0)
                return;

            var sqlCmd = new SqlCommand("load_student", Cnn) {CommandType = CommandType.StoredProcedure};
            sqlCmd.Parameters.AddWithValue("@id_student", Id);
            var dataReader = sqlCmd.ExecuteReader();

            dataReader.Read();

            Id = (int)dataReader.GetValue(0);
            Name = dataReader.GetValue(1).ToString();
            LastName = dataReader.GetValue(2).ToString();
            Group = new Group {Id = (int) dataReader.GetValue(4)};

            dataReader.Close();
            Group.Load();
        }

        public void Save()
        {
            var sqlCmd = new SqlCommand("add_new_student", Cnn) {CommandType = CommandType.StoredProcedure};

            sqlCmd.Parameters.AddWithValue("@id_student", Id);
            sqlCmd.Parameters.AddWithValue("@name", Name);
            sqlCmd.Parameters.AddWithValue("@last_name", LastName);
            sqlCmd.Parameters.AddWithValue("@id_group", Group.Id);

            sqlCmd.ExecuteNonQuery();
        }

        public void Update()
        {
            var sqlCmd = new SqlCommand("update_student", Cnn) {CommandType = CommandType.StoredProcedure};
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.AddWithValue("@name", Name);
            sqlCmd.Parameters.AddWithValue("@last_name", LastName);
            sqlCmd.Parameters.AddWithValue("@id_student", Id);
            sqlCmd.Parameters.AddWithValue("@id_group", Group.Id);
            sqlCmd.ExecuteNonQuery();
        }

        public void Delete()
        {
            var sqlCmd = new SqlCommand("delete_student", Cnn) { CommandType = CommandType.StoredProcedure };
            sqlCmd.Parameters.AddWithValue("@id_student", Id);
            sqlCmd.ExecuteNonQuery();
        }

        public static List<Student> GetAll()
        {
            var sqlCmd = new SqlCommand("get_all_student", Cnn) {CommandType = CommandType.StoredProcedure};
            var dataReader = sqlCmd.ExecuteReader();
            var list = new List<Student>();

            while (dataReader.Read())
            {
                var student = new Student
                {
                    Id = (int) dataReader.GetValue(0),
                    Name = dataReader.GetValue(1).ToString(),
                    LastName = dataReader.GetValue(2).ToString(),
                    Group = new Group { Id = (int)dataReader.GetValue(4)}
                };

                list.Add(student);
            }
            dataReader.Close();
            list.ForEach(x => x.Group.Load());
            return list;
        }

        public void ChangePassword(string newPassword, string oldPassword)
        {
            var sqlCmd = new SqlCommand("change_password_student", Cnn) {CommandType = CommandType.StoredProcedure};
            sqlCmd.Parameters.AddWithValue("@id_student", Id);
            sqlCmd.Parameters.AddWithValue("@old_password", oldPassword);
            sqlCmd.Parameters.AddWithValue("@new_password", newPassword);
            sqlCmd.ExecuteNonQuery();
        }

        public void ResetPassword()
        {
            var sqlCmd = new SqlCommand("reser_passwerd_student", Cnn) { CommandType = CommandType.StoredProcedure };
            sqlCmd.Parameters.AddWithValue("@id_student", Id);
            sqlCmd.ExecuteNonQuery();
        }

        public void Login()
        {
            var sqlCmd = new SqlCommand("login_student", Cnn) { CommandType = CommandType.StoredProcedure };
            sqlCmd.Parameters.AddWithValue("@id_student", Id);
            sqlCmd.Parameters.AddWithValue("@password", Password);
            sqlCmd.ExecuteNonQuery();
        }

        public List<Test> GetTest()
        {
            return Test.GetAll().Where(x => x.Group.Id == Group.Id).ToList();
        }
    }
}
