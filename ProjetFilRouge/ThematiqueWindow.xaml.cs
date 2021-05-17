using ProjetFilRouge.Classes;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ProjetFilRouge
{
    /// <summary>
    /// Logique d'interaction pour ThematiqueWindow.xaml
    /// </summary>
    public partial class ThematiqueWindow : Window
    {
        Thematique t;
        private List<Thematique> thematiques;

        public ThematiqueWindow()
        {
            InitializeComponent();
            AfficherListeThematique();

        }

        private void AfficherListeThematique()
        {
            thematiques = Thematique.GetList();
            ListeViewThematique.ItemsSource = thematiques;
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
            if (ChampsSujet_EntreesAdministrateur.Text != "")
            {
                Thematique t = new Thematique(ChampsSujet_EntreesAdministrateur.Text);
                t.Add();
                AfficherListeThematique();
                ChampsSujet_EntreesAdministrateur.Text = "";
            }
            else
                MessageBox.Show("Veuillez remplir le champs avant de valider", "Erreur de saisie...", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            if (ListeViewThematique.SelectedItem != null)
            {
                Thematique t = (Thematique)ListeViewThematique.SelectedItem;
                IdMod.Text = t.Id.ToString();
                ChampsSujet_ModificationAdministrateur.Text = t.Sujet;
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
            Thematique t = new Thematique(ChampsSujet_ModificationAdministrateur.Text);
            t.Id = id;
            t.Update();
            AfficherListeThematique();
            ChampsSujet_ModificationAdministrateur.Text = "";
            EntreesAdministrateur.Visibility = Visibility.Visible;
            ModificationAdministrateur.Visibility = Visibility.Collapsed;
        }

        private void Supprimer_ModificationAdministrateur_Click(object sender, RoutedEventArgs e)
        {
            if (ListeViewThematique.SelectedItem != null)
            {
                Thematique t = (Thematique)ListeViewThematique.SelectedItem;
                t.Delete();
                AfficherListeThematique();
                EntreesAdministrateur.Visibility = Visibility.Visible;
                ModificationAdministrateur.Visibility = Visibility.Collapsed;
            }
            else
                MessageBox.Show("Merci de sélectionner une thématique !", "Aucune thématique sélectionnée", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void Retour_ModificationAdministrateur_Click(object sender, RoutedEventArgs e)
        {
            EntreesAdministrateur.Visibility = Visibility.Visible;
            ModificationAdministrateur.Visibility = Visibility.Collapsed;
        }

        private void BtnRechercher_RechercherUtilisateur_Click(object sender, RoutedEventArgs e)
        {
            if (ChampsId_RechercherThematique.Text != "" || ChampsSujet_RechercherThematique.Text != "")
            {
                if (ChampsId_RechercherThematique.Text != "")
                {
                    //Commande rechercher par ID
                    RechercherParID(Convert.ToInt32(ChampsId_RechercherThematique.Text));
                }
                else if (ChampsSujet_RechercherThematique.Text != "")
                {
                    //Commande rechercher par Email
                    RechercherParSujet(ChampsSujet_RechercherThematique.Text);
                }
            }
            else
                MessageBox.Show("Veuillez remplir au moins l'un des champs", "Aucune information de recherche", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void RechercherParID(int Id)
        {
            t = Thematique.GetbyId(Id);
            if (t != null)
            {
                RetourRecherche_RechercherThematique.Visibility = Visibility.Visible;
                RetourId_RechercherThematique.Text = t.Id.ToString();
                RetourSujet_RechercherThematique.Text = t.Sujet;
                ChampsId_RechercherThematique.Text = "";
                ChampsSujet_RechercherThematique.Text = "";
            }
            else
                MessageBox.Show("Aucun utilisateur trouvé avec cet Id", "Erreur utilisateur introuvable", MessageBoxButton.OK, MessageBoxImage.Warning);

        }

        private void RechercherParSujet(string sujet)
        {
            t = Thematique.Get(sujet);
            if (t != null)
            {
                RetourRecherche_RechercherThematique.Visibility = Visibility.Visible;
                RetourId_RechercherThematique.Text = t.Id.ToString();
                RetourSujet_RechercherThematique.Text = t.Sujet;
                ChampsId_RechercherThematique.Text = "";
                ChampsSujet_RechercherThematique.Text = "";
            }
            else
                MessageBox.Show("Aucune thématique trouvée", "Erreur thématique introuvable", MessageBoxButton.OK, MessageBoxImage.Warning);

        }

    }
}
