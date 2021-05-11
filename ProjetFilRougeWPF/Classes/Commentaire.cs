using ProjetFilRouge.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ProjetFilRouge.Classes
{
    class Commentaire
    {
        private string dateCommentaire;
        private string commentaire;

        public string DateCommentaire { get => dateCommentaire; set => dateCommentaire = value; }
        public string Comment { get => commentaire; set => commentaire = value; }
        public int Id { get; internal set; }

        public Commentaire()
        {

        }

        public Commentaire(string dateCommentaire, string commentaire)
        {
            DateCommentaire = dateCommentaire;
            Comment = commentaire;
        }

        public override string ToString()
        {
            return DateCommentaire + " " + Comment + " ";
        }

        public void Add()
        {
            if (DataBase.AjouterCommentaire(this))
            {
                MessageBox.Show($"Commentaire Ajouté", "Nouveau commentaire", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Erreur lors de l'ajout d'un nouveau commentaire...", "Erreur d'ajout d'un commentaire ", MessageBoxButton.OK, MessageBoxImage.Warning);

        }

        public static Commentaire Get(string Pseudo, string Email)
        {
            Commentaire c = DataBase.TrouverCommentaire(Pseudo, Email);
            if (c != null)
                MessageBox.Show("Commentaire Trouvé ", "Recherche Commentaire", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("Le commentaire n'existe pas ", "Recherche Commentaire", MessageBoxButton.OK, MessageBoxImage.Information);
            return c;
        }

        public void Delete()
        {
            MessageBoxResult result = MessageBox.Show("Etes-vous sur de vouloir supprimer ce commentaire ?", "Confirmation de modification", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    if (DataBase.SupprimerCommentaire(this))
                        MessageBox.Show("Commentaire Supprimé..", "Confirmation de suppression", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                        MessageBox.Show("Erreur lors de la suppression du commentaire", "Erreur de modification", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            MessageBoxResult result = MessageBox.Show("Etes-vous sur de vouloir modifier ce commentaire ?", "Confirmation de modification", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    if (DataBase.UpdateCommentaire(this))
                        MessageBox.Show("Commentaire modifié : \n" + this.ToString(), "Confirmation de modification", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                        MessageBox.Show("Erreur lors de la modification du commentaire", "Erreur de modification", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("Modification refusée", "Information de modification", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                case MessageBoxResult.Cancel:
                    MessageBox.Show("Modification annulée", "Information de modification", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
            }
        }

        public static List<Commentaire> GetList()
        {
            List<Commentaire> liste = DataBase.AvoirListeCommentaire();
            return liste;
        }

    }
}
