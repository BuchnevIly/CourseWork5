using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork5
{
    class Entity
    {
        protected static SqlConnection cnn;

        protected Entity()
        {
            if (cnn != null && cnn.State == ConnectionState.Open)
                return;

            Connect();
        }

        public static void Connect()
        {
            string connetionString = "Data Source=DESKTOP-RD3DFVB;Initial Catalog=TestSystem;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
        }
    }
}
