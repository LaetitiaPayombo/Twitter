using TwitterAdmin.DAO;
using TwitterAdmin.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Text;

namespace TwitterAdmin.Models
{
   public class Commentaire
    {
        private int id;
        private DateTime dateCommentaire;
        private string com;
        private string image;
        private static int compteur = 0;

        public int Id { get => id; set => id = value; }
        
        public string Com { get => com; set => com = value; }
        public string Image { get => image; set => image = value; }
        public DateTime DateCommentaire { get => dateCommentaire; set => dateCommentaire = value; }

        

        public bool Save()
        {
            AbstractDAO<Commentaire> dao = new CommentaireDAO();
            return dao.Create(this);
        }

        public bool Update()
        {
            AbstractDAO<Commentaire> dao = new CommentaireDAO();
            return dao.Update(this);

        }

        public static Commentaire GetContactById(int id)

        {
            AbstractDAO<Commentaire> dao = new CommentaireDAO();
            return dao.Find(id);
        }



        public bool Delete()
        {
            AbstractDAO<Commentaire> dao = new CommentaireDAO();
            return dao.Delete(this);
        }


        public static List<Commentaire> GetAll()
        {
            AbstractDAO<Commentaire> dao = new CommentaireDAO();
            return dao.FindAll();
        }


        public static List<Commentaire> SearchCom(string search)
        {
            AbstractDAO<Commentaire> dao = new CommentaireDAO();
            return dao.Find(C => C.Com.Contains(search));
        }












    }
}
