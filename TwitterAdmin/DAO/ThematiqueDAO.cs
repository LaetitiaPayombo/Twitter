using TwitterAdmin.Models;
using TwitterAdmin.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace TwitterAdmin.DAO
{
   public  class ThematiqueDAO : AbstractDAO<Thematique>
    {

        public override bool Create(Thematique element)
        {
            request = "INSERT INTO thematique(sujet)" +
                 "OUTPUT INSERTED.ID values (@sujet)";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@pseudo", element.Sujet));
            connection.Open();
            element.Id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return element.Id > 0;
        }



        public override bool Delete(Thematique element)
        {
            request = "delete from thematique where where id=@id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", element.Id));
            connection.Open();
            int nbrLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbrLigne > 0;
        }


        public override Thematique Find(int index)
        {
            Thematique thematique = null;
            request = "SELECT id, sujet from thematique where where id=@id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", index));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                thematique = new Thematique
                {
                    Id = index,
                    Sujet = reader.GetString(1),
                };
            }

            reader.Close();
            command.Dispose();
            connection.Close();
            return thematique;
        }

        public override List<Thematique> Find(Func<Thematique>, bool>criteria)
        {
            List<Thematique> thematiques = new List<Thematique>();
            FindAll().ForEach(u =>
            {
                if (criteria(u))
                {
                    thematique.Add(u);
                }
            });
            return thematique;
        }

        public override List<Thematique> FindAll()
        {
            List<Thematique> thematiques = new List<Thematique>();
            request = "SELECT id, sujet from thematique where where id=@id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Thematique c = new Thematique
                {
                    Id = reader.GetInt32(0),
                    Sujet = reader.GetString(1),

                };
                thematiques.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return thematiques;
        }


        public override bool Update(Thematique element)
        {
            request = "UPDATE thematique set sujet = @sujet,  where id=@id";
            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@sujet", element.Sujet));
            command.Parameters.Add(new SqlParameter("@id", element.Id));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }









    }
}
