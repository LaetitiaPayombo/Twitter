using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Twitter.Tools
{
    public class Connection
    {
        private static string connectionString = @"Data Source=(LocalDB)\ForumAdoNET;Integrated Security=True";
        public static SqlConnection New { get => new SqlConnection(connectionString); }
    }
}
