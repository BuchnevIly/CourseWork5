using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork5
{
    class Student : Teacher, IEntity
    {

        public Group Group { get; set; }

        public new void Load()
        {
            if (Id != 0)
            {
                var sqlCmd = new SqlCommand("load_student", cnn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dataReader = sqlCmd.ExecuteReader();

                dataReader.Read();

                Id = (int)dataReader.GetValue(0);
                Name = dataReader.GetValue(1).ToString();
                LastName = dataReader.GetValue(2).ToString();
                Group group = new Group();
                group.Id = (int)dataReader.GetValue(3);
                group.Load();
                Group = group;

                dataReader.Close();
            }
        }

        public new void Save()
        {
            var sqlCmd = new SqlCommand("add_new_student", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Clear();

            sqlCmd.Parameters.AddWithValue("@id_student", Id);
            sqlCmd.Parameters.AddWithValue("@name", Name);
            sqlCmd.Parameters.AddWithValue("@last_name", LastName);
            sqlCmd.Parameters.AddWithValue("@id_group", Group.Id);

            sqlCmd.ExecuteNonQuery();
        }

        public new void Update()
        {
            var sqlCmd = new SqlCommand("update_test_question", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.AddWithValue("@name", Name);
            sqlCmd.Parameters.AddWithValue("@last_name", LastName);
            sqlCmd.Parameters.AddWithValue("@id_student", Id);
            sqlCmd.Parameters.AddWithValue("@id_group", Group.Id);
            sqlCmd.ExecuteNonQuery();
        }


        public new List<Student> GetAll()
        {
            var sqlCmd = new SqlCommand("get_all_student", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dataReader = sqlCmd.ExecuteReader();

            List<Student> list = new List<Student>();

            while (dataReader.Read())
            {
                Student student = new Student();
                student.Id = (int)dataReader.GetValue(0);
                student.Name = dataReader.GetValue(1).ToString();
                student.LastName = dataReader.GetValue(2).ToString();

                list.Add(student);
            }
            dataReader.Close();
            return list;
        }

        public new void ChangePassword(string newPassword, string oldPassword)
        {
            var sqlCmd = new SqlCommand("change_password_student", cnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Clear();
            sqlCmd.Parameters.AddWithValue("@id_teacher", Id);
            sqlCmd.Parameters.AddWithValue("@old_password", oldPassword);
            sqlCmd.Parameters.AddWithValue("@new_password", newPassword);
            sqlCmd.ExecuteNonQuery();
        }
    }
}
