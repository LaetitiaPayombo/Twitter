using ProjetFilRouge.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjetFilRouge
{
    /// <summary>
    /// Logique d'interaction pour UtilisateurWindow.xaml
    /// </summary>
    public partial class UtilisateurWindow : Window
    {
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
                ChampsPseudo_EntreesAdministrateur.Text = u.Pseudo;
                ChampsEmail_EntreesAdministrateur.Text = u.Email;
            }
            else
                MessageBox.Show("Veuillez séléctionner une entrée de la liste", "Erreur de séléction...", MessageBoxButton.OK, MessageBoxImage.Warning);
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
    }
}
