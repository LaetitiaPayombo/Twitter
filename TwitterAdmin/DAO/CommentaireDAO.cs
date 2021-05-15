using TwitterAdmin.Models;
using TwitterAdmin.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace TwitterAdmin.DAO
{
    class CommentaireDAO : AbstractDAO<Commentaire>
    {


        public override bool Create(Commentaire element)
        {
            request = "INSERT INTO commentaire ( date_commentaire, com, image) " +
                "values (@date_commentaire, @com, @image)";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@date_commentaire", element.Com));
            command.Parameters.Add(new SqlParameter("@com", element.Com));
            command.Parameters.Add(new SqlParameter("@image", element.Image));
            connection.Open();
            int ajoutLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return ajoutLigne == 1;
        }
        public override bool Delete(Commentaire element)
        {
            request = "delete from commentaire where id=@id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", element.Id));
            connection.Open();
            int nbrLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbrLigne > 0;
        }
        public override Commentaire Find(int index)
        {
            Commentaire commentaire = null;
            request = "SELECT id, date_commentaire, com, image from commentaire where id=@id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", index));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                commentaire = new Commentaire
                {
                    Id = index,
                    DateCommentaire = reader.GetDateTime(1),
                    Com = reader.GetString(2),
                    Image = reader.GetString(3),

                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return commentaire;
        }


        public override List<Commentaire> Find(Func<Commentaire, bool> criteria)
        {
            List<Commentaire> commentaires = new List<Commentaire>();
            FindAll().ForEach(c =>
            {
                if (criteria(c))
                {
                    commentaires.Add(c);
                }
            });
            return commentaires;
        }




        public override List<Commentaire> FindAll()
        {
            List<Commentaire> commentaires = new List<Commentaire>();
            request = "SELECT id, date_commentaire, com, image from commentaire";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Commentaire c = new Commentaire
                {
                    Id = reader.GetInt32(0),
                    DateCommentaire = reader.GetDateTime(1),
                    Com = reader.GetString(2),
                    Image = reader.GetString(3),

                };
                commentaires.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return commentaires;
        }


        public override bool Update(Commentaire element)
        {
            request = "UPDATE commentaire set date_commentaire = @date_commentaire, com = @com, image = @image where id=@id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@date_commentaire", element.DateCommentaire));
            command.Parameters.Add(new SqlParameter("com", element.Com));
            command.Parameters.Add(new SqlParameter("@id", element.Id));
            command.Parameters.Add(new SqlParameter("@image", element.Image));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }




    }
}
