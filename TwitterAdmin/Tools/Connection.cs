using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace TwitterAdmin.Tools
{
    public class Connection
    {
        static string connectionString = @"Data Source=(LocalDB)\ForumAdoNET;Integrated Security=True";
        public static SqlConnection New { get => new SqlConnection(connectionString); }
    }
}
