using TwitterAdmin.Models;
using TwitterAdmin.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace TwitterAdmin.DAO
{
    class UtilisateurDAO : AbstractDAO<Utilisateur>
    {

        public override bool Create(Utilisateur element)
        {
            request = "INSERT INTO Utilisateur(pseudo, email) " +
                "OUTPUT INSERTED.ID values (@pseudo, @email)";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@pseudo", element.Pseudo));
            command.Parameters.Add(new SqlParameter("@email", element.Email));
            connection.Open();
            element.Id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return element.Id > 0;
        }
        public override bool Delete(Utilisateur element)
        {
            request = "delete from Utilisateur where id=@id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", element.Id));
            connection.Open();
            int nbrLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbrLigne > 0;
        }
        public override Utilisateur Find(int index)
        {
            Utilisateur utilisateur = null;
            request = "SELECT id, pseudo, email from Utilisateur where id=@id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", index));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                utilisateur = new Utilisateur
                {
                    Id = index,
                    Pseudo = reader.GetString(1),
                    Email = reader.GetString(2),

                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return utilisateur;
        }


        public override List<Utilisateur> Find(Func<Utilisateur, bool> criteria)
        {
            List<Utilisateur> utilisateurs = new List<Utilisateur>();
            FindAll().ForEach(u =>
            {
                if (criteria(u))
                {
                    utilisateurs.Add(u);
                }
            });
            return utilisateurs;
        }




        public override List<Utilisateur> FindAll()
        {
            List<Utilisateur> utilisateurs = new List<Utilisateur>();
            request = "SELECT id, pseudo, email from Utilisateur";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Utilisateur c = new Utilisateur
                {
                    Id = reader.GetInt32(0),
                    Pseudo = reader.GetString(1),
                    Email = reader.GetString(2),

                };
                utilisateurs.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return utilisateurs;
        }


        public override bool Update(Utilisateur element)
        {
            request = "UPDATE Utilisateur set pseudo = @pseudo, email = @email where id=@id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@pseudo", element.Pseudo));
            command.Parameters.Add(new SqlParameter("@email", element.Email));
            command.Parameters.Add(new SqlParameter("@id", element.Id));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }


    }
}
