using ProjetFilRouge.Classes;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ProjetFilRouge
{
    /// <summary>
    /// Logique d'interaction pour CommentaireWindow.xaml
    /// </summary>
    public partial class CommentaireWindow : Window
    {
        Commentaire c;
        private List<Commentaire> commentaires;

        public CommentaireWindow()
        {
            InitializeComponent();
            AfficherListeCommentaire();

        }

        private void AfficherListeCommentaire()
        {
            commentaires = Commentaire.GetList();
            ListeViewCommentaire.ItemsSource = commentaires;
        }

        private void ChoixMenu_Utilisateur_Click(object sender, RoutedEventArgs e)
        {
            UtilisateurWindow fenetre = new UtilisateurWindow();
            fenetre.Show();
            this.Close();
        }

        private void ChoixMenu_Thematique_Click(object sender, RoutedEventArgs e)
        {
            ThematiqueWindow fenetre = new ThematiqueWindow();
            fenetre.Show();
            this.Close();

        }

        private void ChoixMenu_Commentaire_Click(object sender, RoutedEventArgs e)
        {
            CommentaireWindow fenetre = new CommentaireWindow();
            fenetre.Show();
            this.Close();

        }

        private void ChoixMenu_Retour_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow fenetre = new MenuWindow();
            fenetre.Show();
            this.Close();

        }

        private void ChoixMenu_Quitter_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();

        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            if (ChampsDate_EntreesAdministrateur.Text != "" && ChampsCommentaire_EntreesAdministrateur.Text != "")
            {
                Commentaire c = new Commentaire(Convert.ToDateTime(ChampsDate_EntreesAdministrateur.Text), ChampsCommentaire_EntreesAdministrateur.Text);
                c.Add();
                AfficherListeCommentaire();
                ChampsDate_EntreesAdministrateur.Text = "";
                ChampsCommentaire_EntreesAdministrateur.Text = "";
            }
            else
                MessageBox.Show("Veuillez remplir les champs avant de valider", "Erreur de saisie...", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            if (ListeViewCommentaire.SelectedItem != null)
            {
                Commentaire c = (Commentaire)ListeViewCommentaire.SelectedItem;
                IdMod.Text = c.Id.ToString();
                ChampsDate_ModificationAdministrateur.Text = c.DateCommentaire.ToString();
                ChampsCommentaire_ModificationAdministrateur.Text = c.Comment;
                EntreesAdministrateur.Visibility = Visibility.Collapsed;
                ModificationAdministrateur.Visibility = Visibility.Visible;
                Modifier_ModificationAdministrateur.IsEnabled = false;
                Supprimer_ModificationAdministrateur.IsEnabled = true;
            }
            else
                MessageBox.Show("Veuillez sélectionner une entrée de la liste", "Erreur de sélection...", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void TextChangedEventHandler(object sender, TextChangedEventArgs args)
        {
            Modifier_ModificationAdministrateur.IsEnabled = true;
        }

        private void Modifier_ModificationAdministrateur_Click(object sender, RoutedEventArgs e)
        {
            int id;
            id = Convert.ToInt32(IdMod.Text);
            Commentaire c = new Commentaire(Convert.ToDateTime(ChampsDate_ModificationAdministrateur.Text), ChampsCommentaire_ModificationAdministrateur.Text);
            c.Id = id;
            c.Update();
            AfficherListeCommentaire();
            ChampsDate_ModificationAdministrateur.Text = "";
            ChampsCommentaire_ModificationAdministrateur.Text = "";
            EntreesAdministrateur.Visibility = Visibility.Visible;
            ModificationAdministrateur.Visibility = Visibility.Collapsed;
        }

        private void Supprimer_ModificationAdministrateur_Click(object sender, RoutedEventArgs e)
        {
            if (ListeViewCommentaire.SelectedItem != null)
            {
                Commentaire c = (Commentaire)ListeViewCommentaire.SelectedItem;
                c.Delete();
                AfficherListeCommentaire();
                EntreesAdministrateur.Visibility = Visibility.Visible;
                ModificationAdministrateur.Visibility = Visibility.Collapsed;
            }
            else
                MessageBox.Show("Merci de sélectionner un commentaire !", "Aucun commentaire sélectionné", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void Retour_ModificationAdministrateur_Click(object sender, RoutedEventArgs e)
        {
            EntreesAdministrateur.Visibility = Visibility.Visible;
            ModificationAdministrateur.Visibility = Visibility.Collapsed;
        }

        private void BtnRechercher_RechercherCommentaire_Click(object sender, RoutedEventArgs e)
        {
            if (ChampsId_RechercherCommentaire.Text != "" || ChampsDate_RechercherCommentaire.Text != "" || ChampsCommentaire_RechercherCommentaire.Text != "")
            {
                if (ChampsId_RechercherCommentaire.Text != "")
                {
                    //Commande rechercher par ID
                    RechercherParID(Convert.ToInt32(ChampsId_RechercherCommentaire.Text));
                }
                else if (ChampsDate_RechercherCommentaire.Text != "")
                {
                    //Commande rechercher par Date
                    RechercherParDate(ChampsDate_RechercherCommentaire.Text);
                }
                else if (ChampsCommentaire_RechercherCommentaire.Text != "")
                {
                    //Commande rechercher par commentaire
                    RechercherParCommentaire(ChampsCommentaire_RechercherCommentaire.Text);

                }
            }
            else
                MessageBox.Show("Veuillez remplir au moins l'un des champs", "Aucune information de recherche", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void RechercherParID(int Id)
        {
            c = Commentaire.GetbyId(Id);
            if (c != null)
            {
                RetourRecherche_RechercherCommentaire.Visibility = Visibility.Visible;
                RetourId_RechercherCommentaire.Text = Id.ToString();
                RetourDate_RechercherCommentaire.Text = c.DateCommentaire.ToString();
                RetourCommentaire_RechercherCommentaire.Text = c.Comment;
                ChampsId_RechercherCommentaire.Text = "";
                ChampsDate_RechercherCommentaire.Text = "";
                ChampsCommentaire_RechercherCommentaire.Text = "";
            }
            else
                MessageBox.Show("Aucun commentaire trouvé avec cet Id", "Erreur commentaire introuvable", MessageBoxButton.OK, MessageBoxImage.Warning);

        }

        private void RechercherParDate(string date)
        {
            c = Commentaire.GetbyDate(date);
            if (c != null)
            {
                RetourRecherche_RechercherCommentaire.Visibility = Visibility.Visible;
                RetourId_RechercherCommentaire.Text = c.Id.ToString();
                RetourDate_RechercherCommentaire.Text = c.DateCommentaire.ToString();
                RetourCommentaire_RechercherCommentaire.Text = c.Comment;
                ChampsId_RechercherCommentaire.Text = "";
                ChampsDate_RechercherCommentaire.Text = "";
                ChampsCommentaire_RechercherCommentaire.Text = "";
            }
            else
                MessageBox.Show("Aucun commentaire trouvé à cette date", "Erreur commentaire introuvable", MessageBoxButton.OK, MessageBoxImage.Warning);

        }

        private void RechercherParCommentaire(string commentaire)
        {
            c = Commentaire.GetbyCommentaire(commentaire);
            if (c != null)
            {
                RetourRecherche_RechercherCommentaire.Visibility = Visibility.Visible;
                RetourId_RechercherCommentaire.Text = c.Id.ToString();
                RetourDate_RechercherCommentaire.Text = c.DateCommentaire.ToString();
                RetourCommentaire_RechercherCommentaire.Text = c.Comment;
                ChampsId_RechercherCommentaire.Text = "";
                ChampsDate_RechercherCommentaire.Text = "";
                ChampsCommentaire_RechercherCommentaire.Text = "";
            }
            else
                MessageBox.Show("Aucun commentaire trouvé", "Erreur commentaire introuvable", MessageBoxButton.OK, MessageBoxImage.Warning);

        }

    }
}
