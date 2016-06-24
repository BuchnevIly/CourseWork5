using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace model
{
    public class Admin : Entity
    {      

        public static void Login(string password)
        {
            var sqlCmd = new SqlCommand("change_password_admin", Cnn) { CommandType = CommandType.StoredProcedure };
            sqlCmd.Parameters.AddWithValue("@new_password", password);
            sqlCmd.ExecuteNonQuery();
        }

        public static void ChangePassword(string newPassword, string oldPassword)
        {
            var sqlCmd = new SqlCommand("change_password_admin", Cnn) { CommandType = CommandType.StoredProcedure };
            sqlCmd.Parameters.AddWithValue("@old_password", oldPassword);
            sqlCmd.Parameters.AddWithValue("@new_password", newPassword);
            sqlCmd.ExecuteNonQuery();
        }
    }
}
