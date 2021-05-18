using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Twitter.Models
{
    public class ModelBase
    {
        protected static string request;
        protected static SqlConnection connection;
        protected static SqlCommand command;
        protected static SqlDataReader reader;

    }
}
