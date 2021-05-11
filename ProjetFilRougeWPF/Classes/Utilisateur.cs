using ProjetFilRouge.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ProjetFilRouge.Classes
{
    class Utilisateur
    {
        private string pseudo;
        private string email;

        public string Pseudo { get => pseudo; set => pseudo = value; }
        public string Email { get => email; set => email = value; }
        public int Id { get; internal set; }

        public Utilisateur()
        {

        }

        public Utilisateur(string pseudo, string email)
        {
            Pseudo = pseudo;
            Email = email;
        }

        public override string ToString()
        {
            return Pseudo + " " + Email + " ";
        }

        public void Add()
        {
            if (DataBase.AjouterUtilisateur(this))
            {
                MessageBox.Show($"Utilisateur Ajouté", "Nouvel utilisateur", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Erreur lors de l'ajout d'un nouvel utilisateur...", "Erreur d'ajout d'un utilisateur ", MessageBoxButton.OK, MessageBoxImage.Warning);

        }

        public static Utilisateur Get(string Pseudo, string Email)
        {
            Utilisateur u = DataBase.TrouverUtilisateur(Pseudo, Email);
            if (u != null)
                MessageBox.Show("Utilisateur Trouvé ", "Recherche Utilisateur", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("L'utilisateur n'existe pas ", "Recherche Utilisateur", MessageBoxButton.OK, MessageBoxImage.Information);
            return u;
        }

        public void Delete()
        {
            MessageBoxResult result = MessageBox.Show("Etes-vous sur de vouloir supprimer cet utilisateur ?", "Confirmation de modification", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    if (DataBase.SupprimerUtilisateur(this))
                        MessageBox.Show("Utilisateur Supprimé..", "Confirmation de suppression", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                        MessageBox.Show("Erreur lors de la suppression de l'utilisateur", "Erreur de modification", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("Suppression refusée", "Information de modification", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                case MessageBoxResult.Cancel:
                    MessageBox.Show("Suppression annulée", "Information de modification", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
            }
        }

        public void Update()
        {
            MessageBoxResult result = MessageBox.Show("Etes-vous sur de vouloir modifier l'utilisateur ?", "Confirmation de modification", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    if (DataBase.UpdateUtilisateur(this))
                        MessageBox.Show("Utilisateur modifié : \n" + this.ToString(), "Confirmation de modification", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                        MessageBox.Show("Erreur lors de la modification de l'utilisateur", "Erreur de modification", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("Modification refusée", "Information de modification", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                case MessageBoxResult.Cancel:
                    MessageBox.Show("Modification annulée", "Information de modification", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
            }
        }

        public static List<Utilisateur> GetList()
        {
            List<Utilisateur> liste = DataBase.AvoirListeUtilisateur();
            return liste;
        }
    }
}
