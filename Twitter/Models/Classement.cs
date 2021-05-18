using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twitter.Tools;

namespace Twitter.Models
{
    public class Classement : ModelBase
    {

        private int id;
        private string title;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }



        public bool Save()
        {
            request = "INSERT INTO classement (title) OUTPUT INSERTED.ID values (@title)";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@title", title));
            connection.Open();
            Id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return Id > 0;
        }



        public static List<Classement> GetClassements()
        {
            List<Classement> liste = new List<Classement>();
            request = "SELECT id, title from classement";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Classement c = new Classement() { Id = reader.GetInt32(0), title = reader.GetString(1) };
                liste.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return liste;
        }


    }
}
