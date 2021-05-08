using TwitterAdmin.DAO;
using TwitterAdmin.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Text;

namespace TwitterAdmin.Models
{
    public class Utilisateur
    {
        private int id;
        private string pseudo;
        private string email;

        public int Id { get => id; set => id = value; }
        public string Pseudo { get => pseudo; set => pseudo = value; }
        public string Email { get => email; set => email = value; }

        public bool Save()
        {
            AbstractDAO<Utilisateur> dao = new UtilisateurDAO();
            return dao.Create(this);
        }

        public bool Update()
        {
            AbstractDAO<Utilisateur> dao = new UtilisateurDAO();
            return dao.Update(this);

        }

        public static Utilisateur GetContactById(int id)

        {
            AbstractDAO<Utilisateur> dao = new UtilisateurDAO();
            return dao.Find(id);
        }



        public bool Delete()
        {
            AbstractDAO<Utilisateur> dao = new UtilisateurDAO();
            return dao.Delete(this);
        }


        public static List<Utilisateur> GetAll()
        {
            AbstractDAO<Utilisateur> dao = new UtilisateurDAO();
            return dao.FindAll();
        }


        public static List<Utilisateur> SearchUser(string search)
        {
            AbstractDAO<Utilisateur> dao = new UtilisateurDAO();
            return dao.Find(u => u.Pseudo.Contains(search));
        }












    }
}


