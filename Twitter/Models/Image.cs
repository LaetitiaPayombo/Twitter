using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Twitter.Tools;

namespace Twitter.Models
{
    public class Image : ModelBase
    {
        private int id;
        private string url;

        public int Id { get => id; set => id = value; }
        public string Url { get => url; set => url = value; }

        public bool Save(int tweetoId)
        {
            request = "INSERT INTO image(url, tweeto_id) OUTPUT INSERTED.ID values (@url,@tweeto_id)";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@url", Url));
            command.Parameters.Add(new SqlParameter("@tweeto_id", tweetoId));
            connection.Open();
            Id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return Id > 0;
        }

        public static List<Image> GetImagesByTweeto(int tweetoId)
        {
            List<Image> liste = new List<Image>();
            request = "SELECT id, url from image where tweeto_id=@tweeto_id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@tweeto_id", tweetoId));
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Image c = new Image() { Id = reader.GetInt32(0), url = reader.GetString(1) };
                liste.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return liste;
        }






    }
}
