using ProjetFilRouge.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ProjetFilRouge.Data
{
    class DataBase
    {
        private static string chaine = @"Data Source=(localdb)\ProjetFilRouge;Integrated Security=True";

        public static SqlConnection Connection { get => new SqlConnection(chaine); }

        //Gestion des utilisateurs

        public static bool AjouterUtilisateur(Utilisateur u)
        {
            SqlConnection connection = Connection;
            SqlCommand command = new SqlCommand("INSERT INTO utilisateur (pseudo, email) VALUES (@pseudo, @email)", connection);
            command.Parameters.Add(new SqlParameter("@pseudo", u.Pseudo));
            command.Parameters.Add(new SqlParameter("@email", u.Email));

            connection.Open();
            int nbLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            if (nbLigne > 0)
                return true;
            else
                return false;
        }

        internal static Utilisateur TrouverUtilisateurParID(int Id)
        {
            SqlConnection connection = Connection;
            Utilisateur u = null;
            SqlCommand command = new SqlCommand("SELECT * FROM utilisateur WHERE Id = @Id", connection);
            command.Parameters.Add(new SqlParameter("@Id", Id));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                u = new Utilisateur()
                {
                    Id = reader.GetInt32(0),
                    Pseudo = reader.GetString(1),
                    Email = reader.GetString(2),
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return u;
        }

        internal static Utilisateur TrouverUtilisateurParPseudo(string pseudo)
        {
            SqlConnection connection = Connection;
            Utilisateur u = null;
            SqlCommand command = new SqlCommand("SELECT * FROM utilisateur WHERE Pseudo = @Pseudo", connection);
            command.Parameters.Add(new SqlParameter("@Pseudo", pseudo));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                u = new Utilisateur()
                {
                    Id = reader.GetInt32(0),
                    Pseudo = reader.GetString(1),
                    Email = reader.GetString(2),
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return u;
        }

        internal static Utilisateur TrouverUtilisateurParEmail(string email)
        {
            SqlConnection connection = Connection;
            Utilisateur u = null;
            SqlCommand command = new SqlCommand("SELECT * FROM utilisateur WHERE Email = @Email", connection);
            command.Parameters.Add(new SqlParameter("@Email", email));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                u = new Utilisateur()
                {
                    Id = reader.GetInt32(0),
                    Pseudo = reader.GetString(1),
                    Email = reader.GetString(2),
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return u;
        }

        public static bool UpdateUtilisateur(Utilisateur u)
        {
            SqlConnection connection = Connection;
            SqlCommand command = new SqlCommand("UPDATE utilisateur SET pseudo = @Pseudo, email = @Email WHERE id = @Id", connection);
            command.Parameters.Add(new SqlParameter("@Id", u.Id));
            command.Parameters.Add(new SqlParameter("@Pseudo", u.Pseudo));
            command.Parameters.Add(new SqlParameter("@Email", u.Email));
            connection.Open();
            int nbLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            if (nbLigne > 0)
                return true;
            else
                return false;
        }

        public static bool SupprimerUtilisateur(Utilisateur u)
        {
            SqlConnection connection = Connection;
            SqlCommand command = new SqlCommand("DELETE FROM utilisateur WHERE id = @Id", connection);
            command.Parameters.Add(new SqlParameter("@Id", u.Id));
            connection.Open();
            int nbLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            if (nbLigne > 0)
                return true;
            else
                return false;
        }

        public static List<Utilisateur> AvoirListeUtilisateur()
        {
            SqlConnection connection = Connection;
            List<Utilisateur> liste = new List<Utilisateur>();
            SqlCommand command = new SqlCommand("SELECT * FROM utilisateur ORDER BY pseudo ASC", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Utilisateur u = new Utilisateur()
                {
                    Id = reader.GetInt32(0),
                    Pseudo = reader.GetString(1),
                    Email = reader.GetString(2),

                };
                liste.Add(u);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return liste;
        }


        //Gestion des thématiques


        public static bool AjouterThematique(Thematique t)
        {
            SqlConnection connection = Connection;
            SqlCommand command = new SqlCommand("INSERT INTO thematique (sujet) VALUES (@sujet)", connection);
            command.Parameters.Add(new SqlParameter("@sujet", t.Sujet));

            connection.Open();
            int nbLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            if (nbLigne > 0)
                return true;
            else
                return false;
        }

        internal static Thematique TrouverThematique(string sujet)
        {
            SqlConnection connection = Connection;
            Thematique t = null;
            SqlCommand command = new SqlCommand("SELECT * FROM Thematique WHERE sujet = @sujet", connection);
            command.Parameters.Add(new SqlParameter("@sujet", sujet));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                t = new Thematique()
                {
                    Id = reader.GetInt32(0),
                    Sujet = reader.GetString(1),
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return t;
        }

        internal static Thematique TrouverThematiqueParID(int id)
        {
            SqlConnection connection = Connection;
            Thematique t = null;
            SqlCommand command = new SqlCommand("SELECT * FROM Thematique WHERE id = @id", connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                t = new Thematique()
                {
                    Id = reader.GetInt32(0),
                    Sujet = reader.GetString(1),
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return t;
        }

        public static bool UpdateThematique(Thematique t)
        {
            SqlConnection connection = Connection;
            SqlCommand command = new SqlCommand("UPDATE Thematique SET sujet = @Sujet WHERE id = @Id", connection);
            command.Parameters.Add(new SqlParameter("@Id", t.Id));
            command.Parameters.Add(new SqlParameter("@Sujet", t.Sujet));
            connection.Open();
            int nbLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            if (nbLigne > 0)
                return true;
            else
                return false;
        }

        public static bool SupprimerThematique(Thematique t)
        {
            SqlConnection connection = Connection;
            SqlCommand command = new SqlCommand("DELETE FROM Thematique WHERE id = @Id", connection);
            command.Parameters.Add(new SqlParameter("@Id", t.Id));
            connection.Open();
            int nbLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            if (nbLigne > 0)
                return true;
            else
                return false;
        }

        public static List<Thematique> AvoirListeThematique()
        {
            SqlConnection connection = Connection;
            List<Thematique> liste = new List<Thematique>();
            SqlCommand command = new SqlCommand("SELECT * FROM Thematique ORDER BY sujet ASC", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Thematique t = new Thematique()
                {
                    Id = reader.GetInt32(0),
                    Sujet = reader.GetString(1),

                };
                liste.Add(t);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return liste;
        }

        //Gestion des commentaires

        public static bool AjouterCommentaire(Commentaire c)
        {
            SqlConnection connection = Connection;
            SqlCommand command = new SqlCommand("INSERT INTO commentaire (dateCommentaire, commentaire) VALUES (@dateCommentaire, @commentaire)", connection);
            command.Parameters.Add(new SqlParameter("@dateCommentaire", c.DateCommentaire));
            command.Parameters.Add(new SqlParameter("@Commentaire", c.Comment));

            connection.Open();
            int nbLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            if (nbLigne > 0)
                return true;
            else
                return false;
        }

        internal static Commentaire TrouverCommentaireParID(int id)
        {
            SqlConnection connection = Connection;
            Commentaire c = null;
            SqlCommand command = new SqlCommand("SELECT * FROM commentaire WHERE id = @id", connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                c = new Commentaire()
                {
                    Id = reader.GetInt32(0),
                    DateCommentaire = reader.GetDateTime(1),
                    Comment = reader.GetString(2),
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return c;
        }

        internal static Commentaire TrouverCommentaireParDate(string date)
        {
            SqlConnection connection = Connection;
            Commentaire c = null;
            SqlCommand command = new SqlCommand("SELECT * FROM commentaire WHERE date = @date", connection);
            command.Parameters.Add(new SqlParameter("@date", date));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                c = new Commentaire()
                {
                    Id = reader.GetInt32(0),
                    DateCommentaire = reader.GetDateTime(1),
                    Comment = reader.GetString(2),
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return c;
        }

        internal static Commentaire TrouverCommentaireParCommentaire(string commentaire)
        {
            SqlConnection connection = Connection;
            Commentaire c = null;
            SqlCommand command = new SqlCommand("SELECT * FROM commentaire WHERE commentaire = @commentaire", connection);
            command.Parameters.Add(new SqlParameter("@commentaire", commentaire));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                c = new Commentaire()
                {
                    Id = reader.GetInt32(0),
                    DateCommentaire = reader.GetDateTime(1),
                    Comment = reader.GetString(2),
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return c;
        }

        public static bool UpdateCommentaire(Commentaire c)
        {
            SqlConnection connection = Connection;
            SqlCommand command = new SqlCommand("UPDATE commentaire SET dateCommentaire = @dateCommentaire, commentaire = @commentaire WHERE id = @Id", connection);
            command.Parameters.Add(new SqlParameter("@Id", c.Id));
            command.Parameters.Add(new SqlParameter("@dateCommentaire", c.DateCommentaire));
            command.Parameters.Add(new SqlParameter("@commentaire", c.Comment));
            connection.Open();
            int nbLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            if (nbLigne > 0)
                return true;
            else
                return false;
        }

        public static bool SupprimerCommentaire(Commentaire c)
        {
            SqlConnection connection = Connection;
            SqlCommand command = new SqlCommand("DELETE FROM commentaire WHERE id = @Id", connection);
            command.Parameters.Add(new SqlParameter("@Id", c.Id));
            connection.Open();
            int nbLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            if (nbLigne > 0)
                return true;
            else
                return false;
        }

        public static List<Commentaire> AvoirListeCommentaire()
        {
            SqlConnection connection = Connection;
            List<Commentaire> liste = new List<Commentaire>();
            SqlCommand command = new SqlCommand("SELECT * FROM Commentaire ORDER BY dateCommentaire ASC", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Commentaire c = new Commentaire()
                {
                    Id = reader.GetInt32(0),
                    DateCommentaire = reader.GetDateTime(1),
                    Comment = reader.GetString(2),

                };
                liste.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return liste;
        }
    }
}
