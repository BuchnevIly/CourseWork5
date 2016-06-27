using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace model
{
    public class SqlQuesyion : Entity
    {
        private static List<List<object>> Load(string sql)
        {
            var result = new List<List<object>>();

            var sqlCmd = new SqlCommand("get_result", Cnn) { CommandType = CommandType.StoredProcedure };
            sqlCmd.Parameters.AddWithValue("@sql", sql);
            var dataReader = sqlCmd.ExecuteReader();

            var i = 0;
            while (dataReader.Read())
            {
                result.Add(new List<object>());
                for (var j = 0; j < dataReader.FieldCount; j++)
                    result[i].Add(dataReader.GetValue(j));
                i++;
            }

            dataReader.Close();

            return result;
        }


        public static bool IsTrue(string sqlUser, string sqlTrue)
        {
            var result1 = Load(sqlTrue);
            var result2 = Load(sqlUser);

            if (result1.Count != result2.Count)
                return false;

            if (result1[0].Count != result2[0].Count)
                return false;

            for (var i = 0; i < result1.Count; i++)
                for (var j = 0; j < result1[0].Count; j++)
                {
                    var a = result1[i][j].GetHashCode();
                    var b = result2[i][j].GetHashCode();
                    if (result1[i][j].GetHashCode() != result2[i][j].GetHashCode()  )
                        return false;
                }
                    

            return true;
        }

    }
}
