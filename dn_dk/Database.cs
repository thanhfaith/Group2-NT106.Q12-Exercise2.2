using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace signin_signup
{
    internal class Database
    {
        private static string connectionString = "Server=YENVY;Database=UserDATABASE;Integrated Security=True;";

        public static SqlConnection GetConnection()
            {
                return new SqlConnection(connectionString);
            }
        }
}
