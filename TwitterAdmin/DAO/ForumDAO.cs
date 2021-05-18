using TwitterAdmin.Models;
using TwitterAdmin.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace TwitterAdmin.DAO
{
    class ForumDAO : AbstractDAO<Forum>
    {
        public override bool Create(Forum element)
        {
            request = "INSERT INTO forum (id_user,id_thematique)" +
                "OUTPUT INSERTED.ID values (@id_user, @id_thematique)";


            connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id_user", element.Id_user));
            command.Parameters.Add(new SqlParameter("@id_thematique", element.Id_thematique));
            connection.Open();
            element.Id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return element.Id > 0;
        }

        public override bool Delete(Forum element)
        {
            throw new NotImplementedException();
        }

        public override Forum Find(int index)
        {
            throw new NotImplementedException();
        }

        public override List<Forum> Find(Func<Forum, bool> criteria)
        {
            throw new NotImplementedException();
        }

        public override List<Forum> FindAll()
        {
            throw new NotImplementedException();
        }

        public override bool Update(Forum element)
        {
            throw new NotImplementedException();
        }
    }
}
