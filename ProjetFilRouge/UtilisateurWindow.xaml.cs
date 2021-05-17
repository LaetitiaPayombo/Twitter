using ProjetFilRouge.Classes;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ProjetFilRouge
{
    /// <summary>
    /// Logique d'interaction pour UtilisateurWindow.xaml
    /// </summary>
    public partial class UtilisateurWindow : Window
    {
        Utilisateur u;
        private static List<Utilisateur> utilisateurs;

        public UtilisateurWindow()
        {
            InitializeComponent();
            AfficherListeUtilisateur();

        }

        private void AfficherListeUtilisateur()
        {
            utilisateurs = Utilisateur.GetList();
            ListeViewUtilisateur.ItemsSource = utilisateurs;
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            if (ChampsPseudo_EntreesAdministrateur.Text != "" && ChampsEmail_EntreesAdministrateur.Text != "")
            {
                Utilisateur u = new Utilisateur(ChampsPseudo_EntreesAdministrateur.Text, ChampsEmail_EntreesAdministrateur.Text);
                u.Add();
                AfficherListeUtilisateur();
                ChampsPseudo_EntreesAdministrateur.Text = "";
                ChampsEmail_EntreesAdministrateur.Text = "";
            }
            else
                MessageBox.Show("Veuillez remplir tous les champs avant de valider", "Erreur de saisie...", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            if (ListeViewUtilisateur.SelectedItem != null)
            {
                Utilisateur u = (Utilisateur)ListeViewUtilisateur.SelectedItem;
                IdMod.Text = u.Id.ToString();
                ChampsPseudo_ModificationAdministrateur.Text = u.Pseudo;
                ChampsEmail_ModificationAdministrateur.Text = u.Email;
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

        private void Modifier_ModificationAdministrateur_Click(object sender, RoutedEventArgs e)
        {
            int id;
            id = Convert.ToInt32(IdMod.Text);
            Utilisateur u = new Utilisateur(ChampsPseudo_ModificationAdministrateur.Text, ChampsEmail_ModificationAdministrateur.Text);
            u.Id = id;
            u.Update();
            AfficherListeUtilisateur();
            ChampsPseudo_ModificationAdministrateur.Text = "";
            ChampsEmail_ModificationAdministrateur.Text = "";
            EntreesAdministrateur.Visibility = Visibility.Visible;
            ModificationAdministrateur.Visibility = Visibility.Collapsed;
        }

        private void Supprimer_ModificationAdministrateur_Click(object sender, RoutedEventArgs e)
        {
            if (ListeViewUtilisateur.SelectedItem != null)
            {
                Utilisateur u = (Utilisateur)ListeViewUtilisateur.SelectedItem;
                u.Delete();
                AfficherListeUtilisateur();
                EntreesAdministrateur.Visibility = Visibility.Visible;
                ModificationAdministrateur.Visibility = Visibility.Collapsed;
            }
            else
                MessageBox.Show("Merci de sélectionner un utilisateur !", "Aucun utilisateur sélectionné", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void Retour_ModificationAdministrateur_Click(object sender, RoutedEventArgs e)
        {
            EntreesAdministrateur.Visibility = Visibility.Visible;
            ModificationAdministrateur.Visibility = Visibility.Collapsed;
        }

        private void BtnRechercher_RechercherUtilisateur_Click(object sender, RoutedEventArgs e)
        {
            if (ChampsId_RechercherUtilisateur.Text != "" || ChampsEmail_RechercherUtilisateur.Text != "" || ChampsPseudo_RechercherUtilisateur.Text != "")
            {
                if (ChampsId_RechercherUtilisateur.Text != "")
                {
                    //Commande rechercher par ID
                    RechercherParID(Convert.ToInt32(ChampsId_RechercherUtilisateur.Text));
                }
                else if (ChampsEmail_RechercherUtilisateur.Text != "")
                {
                    //Commande rechercher par Email
                    RechercherParEmail(ChampsEmail_RechercherUtilisateur.Text);
                }
                else if (ChampsPseudo_RechercherUtilisateur.Text != "")
                {
                    //Commande rechercher par pseudo
                    RechercherParPseudo(ChampsPseudo_RechercherUtilisateur.Text);

                }
            }
            else
                MessageBox.Show("Veuillez remplir au moins l'un des champs", "Aucune information de recherche", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void RechercherParID(int Id)
        {
            u = Utilisateur.GetbyId(Id);
            if (u != null)
            {
                RetourRecherche_RechercherUtilisateur.Visibility = Visibility.Visible;
                RetourId_RechercherUtilisateur.Text = Id.ToString();
                RetourPseudo_RechercherUtilisateur.Text = u.Pseudo;
                RetourEmail_RechercherUtilisateur.Text = u.Email;
                ChampsId_RechercherUtilisateur.Text = "";
                ChampsPseudo_RechercherUtilisateur.Text = "";
                ChampsEmail_RechercherUtilisateur.Text = "";
            }
            else
                MessageBox.Show("Aucun utilisateur trouvé avec cet Id", "Erreur utilisateur introuvable", MessageBoxButton.OK, MessageBoxImage.Warning);

        }

        private void RechercherParPseudo(string pseudo)
        {
            u = Utilisateur.GetbyPseudo(pseudo);
            if (u != null)
            {
                RetourRecherche_RechercherUtilisateur.Visibility = Visibility.Visible;
                RetourId_RechercherUtilisateur.Text = u.Id.ToString();
                RetourPseudo_RechercherUtilisateur.Text = u.Pseudo;
                RetourEmail_RechercherUtilisateur.Text = u.Email;
                ChampsId_RechercherUtilisateur.Text = "";
                ChampsPseudo_RechercherUtilisateur.Text = "";
                ChampsEmail_RechercherUtilisateur.Text = "";
            }
            else
                MessageBox.Show("Aucun utilisateur trouvé sous ce pseudo", "Erreur utilisateur introuvable", MessageBoxButton.OK, MessageBoxImage.Warning);

        }

        private void RechercherParEmail(string email)
        {
            u = Utilisateur.GetbyEmail(email);
            if (u != null)
            {
                RetourRecherche_RechercherUtilisateur.Visibility = Visibility.Visible;
                RetourId_RechercherUtilisateur.Text = u.Id.ToString();
                RetourPseudo_RechercherUtilisateur.Text = u.Pseudo;
                RetourEmail_RechercherUtilisateur.Text = u.Email;
                ChampsId_RechercherUtilisateur.Text = "";
                ChampsPseudo_RechercherUtilisateur.Text = "";
                ChampsEmail_RechercherUtilisateur.Text = "";
            }
            else
                MessageBox.Show("Aucun utilisateur trouvé sous ce pseudo", "Erreur utilisateur introuvable", MessageBoxButton.OK, MessageBoxImage.Warning);

        }

    }


}
