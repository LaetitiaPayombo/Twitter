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
    /// Logique d'interaction pour CommentaireWindow.xaml
    /// </summary>
    public partial class CommentaireWindow : Window
    {
        public CommentaireWindow()
        {
            InitializeComponent();
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
