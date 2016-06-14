using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Entity
    {
        protected static SqlConnection cnn;

        public static void Initialize()
        {
            if (cnn != null && cnn.State == ConnectionState.Open)
                return;

            Connect();
        }

        protected Entity()
        {
            Initialize();
        }

        public static void Connect()
        {
            const string connetionString = "Data Source=DESKTOP-RD3DFVB;Initial Catalog=TestSystem;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
        }
    }
}
