using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Twitter.Tools;

namespace Twitter.Models
{
    public class Tweeto : ModelBase
    {
        private int id;
        private string title;
        private string description;
        private int classementId;
        private List<Image> images;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public int ClassementId { get => classementId; set => classementId = value; }
        public List<Image> Images { get => images; set => images = value; }



        public Tweeto()
        {
            Images = new List<Image>();
        }


        public bool Save()
        {
            request = "INSERT INTO tweeto (title,  description, classement_id)" +
                "OUTPUT INSERTED.ID values" +
                "(@title, @description, @classement_id)";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@title", Title));
            command.Parameters.Add(new SqlParameter("@description", Description));
            command.Parameters.Add(new SqlParameter("@classement_id", classementId));
            connection.Open();
            Id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            if (Id > 0)
            {
                Images.ForEach(i => i.Save(Id));
                return true;
            }
            return false;

        }


        public static List<Tweeto> GetTweetos(int? classementId)
        {
            List<Tweeto> liste = new List<Tweeto>();
            request = "SELECT id, title, description from tweeto ";
            if(classementId != null)
            {
                request += "where classement_id=@classement_id";
            }
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            if (classementId != null)
            {
                command.Parameters.Add(new SqlParameter("@classement_id", (int)classementId));
            }
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Tweeto t = new Tweeto()
                {
                    Id = reader.GetInt32(0),
                    title = reader.GetString(1),
                    Description = reader.GetString(2)
                };
                liste.Add(t);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            liste.ForEach(t =>
            {
                t.Images = Image.GetImagesByTweeto(t.Id);
            });
            return liste;

        }


        public static Tweeto GetTweeto(int id)
        {
            Tweeto t = null;
            request = "SELECT id, title, description from tweeto WHERE id = @id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                t = new Tweeto()
                {
                    Id = reader.GetInt32(0),
                    title = reader.GetString(1),
                    Description = reader.GetString(2)
                };

            }
            reader.Close();
            command.Dispose();
            connection.Close();
            t.Images = Image.GetImagesByTweeto(t.Id);
            return t;
        }






    }
}
