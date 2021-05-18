using TwitterAdmin.DAO;
using TwitterAdmin.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Text;

namespace TwitterAdmin.Models
{
    public class Thematique
    {
        private int id;
        private string sujet;

        public int Id { get => id; set => id = value; }
        public string Sujet { get => sujet; set => sujet = value; }


        public bool Save()
        {
            AbstractDAO<Thematique> dao = new ThematiqueDAO();
            return dao.Create(this);
        }


        public bool Update()
        {
            AbstractDAO<Thematique> dao = new ThematiqueDAO();
            return dao.Update(this);
        }


        public static Thematique GetThemById(int id)

        {
            AbstractDAO<Thematique> dao = new ThematiqueDAO();
            return dao.Find(id);
        }



        public bool Delete()
        {
            AbstractDAO<Thematique> dao = new ThematiqueDAO();
            return dao.Delete(this);
        }


        public static List<Thematique> GetAll()
        {
            AbstractDAO<Thematique> dao = new ThematiqueDAO();
            return dao.FindAll();
        }


        public static List<Thematique> SearchThem(string search)
        {
            AbstractDAO<Thematique> dao = new ThematiqueDAO();
            return dao.Find(t => t.Sujet.Contains(search));
        }






















    }
}
