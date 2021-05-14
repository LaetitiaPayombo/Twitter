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
    /// Logique d'interaction pour MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void Btn_GestionnaireUtilisateur_Click(object sender, RoutedEventArgs e)
        {
            UtilisateurWindow fenetre = new UtilisateurWindow();
            fenetre.Show();
            this.Close();

        }

        private void Btn_GestionnaireThématique_Click(object sender, RoutedEventArgs e)
        {
            ThematiqueWindow fenetre = new ThematiqueWindow();
            fenetre.Show();
            this.Close();

        }

        private void Btn_GestionnaireCommentaire_Click(object sender, RoutedEventArgs e)
        {
            CommentaireWindow fenetre = new CommentaireWindow();
            fenetre.Show();
            this.Close();

        }

        private void Btn_Quitter_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
