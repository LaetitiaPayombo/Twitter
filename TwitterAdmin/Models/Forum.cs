using TwitterAdmin.DAO;
using TwitterAdmin.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Text;

namespace TwitterAdmin.Models
{
    public class Forum
    {
        private int id;
        private int id_user;
        private int id_thematique;

        public int Id { get => id; set => id = value; }
        public int Id_user { get => id_user; set => id_user = value; }
        public int Id_thematique { get => id_thematique; set => id_thematique = value; }






    }
}
