using ProjetFilRouge.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ProjetFilRouge.Classes
{
    class Thematique
    {
        private string sujet;

        public string Sujet { get => sujet; set => sujet = value; }
        public int Id { get; internal set; }

        public Thematique()
        {

        }
        public Thematique(string sujet)
        {
            Sujet = sujet;
        }
        public override string ToString()
        {
            return Sujet;
        }

        public void Add()
        {
            if (DataBase.AjouterThematique(this))
            {
                MessageBox.Show($"Thématique Ajoutée", "Nouvelle thématique", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Erreur lors de l'ajout d'une nouvelle thématique...", "Erreur d'ajout d'une thématique ", MessageBoxButton.OK, MessageBoxImage.Warning);

        }

        public static Thematique Get(string sujet)
        {
            Thematique t = DataBase.TrouverThematique(sujet);
            if (t != null)
                MessageBox.Show("Thématique Trouvée ", "Recherche Thématique", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("La thématique n'existe pas ", "Recherche Thématique", MessageBoxButton.OK, MessageBoxImage.Information);
            return t;
        }

        public static Thematique GetbyId(int Id)
        {
            Thematique t = DataBase.TrouverThematiqueParID(Id);
            if (t != null)
                ;
            else
                MessageBox.Show("La thématique recherchée n'existe pas ", "Recherche Thématique", MessageBoxButton.OK, MessageBoxImage.Information);
            return t;
        }

        public void Delete()
        {
            MessageBoxResult result = MessageBox.Show("Etes-vous sur de vouloir supprimer cet thématique ?", "Confirmation de modification", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    if (DataBase.SupprimerThematique(this))
                        MessageBox.Show("Thématique Supprimée..", "Confirmation de suppression", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                        MessageBox.Show("Erreur lors de la suppression de la thématique", "Erreur de modification", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            MessageBoxResult result = MessageBox.Show("Etes-vous sur de vouloir modifier la thématique ?", "Confirmation de modification", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    if (DataBase.UpdateThematique(this))
                        MessageBox.Show("Thématique modifiée : \n" + this.ToString(), "Confirmation de modification", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                        MessageBox.Show("Erreur lors de la modification de la thématique", "Erreur de modification", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("Modification refusée", "Information de modification", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                case MessageBoxResult.Cancel:
                    MessageBox.Show("Modification annulée", "Information de modification", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
            }
        }


        public static List<Thematique> GetList()
        {
            List<Thematique> liste = DataBase.AvoirListeThematique();
            return liste;
        }
    }
}

