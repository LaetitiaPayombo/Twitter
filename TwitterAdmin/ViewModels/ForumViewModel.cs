using TwitterAdmin.Views;
using TwitterAdmin.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace TwitterAdmin.ViewModels
{
    class ForumViewModel : ViewModelBase
    {

        private Forum forum;
        public ICommand UtilisateursCommand { get; set; }
        public ICommand ThematiquesCommand { get; set; }

        public ICommand CommentairesCommand { get; set; }

        public Forum Forum 
        { 
            get => forum; set
            {
               forum = value;
                if(forum != null)
                {
                    RaisePropertyChanged("Gestion Utilisateurs");
                    RaisePropertyChanged("Gestion Thématiques");
                    RaisePropertyChanged("Gestion Commentaires");
                }

            }
        }
        public ForumViewModel()
        {
            Forum = new Forum();
            UtilisateursCommand = new RelayCommand(ActionUtilisateurCommand);
            ThematiquesCommand = new RelayCommand(ActionThematiquesCommand);
            CommentairesCommand = new RelayCommand(ActionCommentairesCommand);

        }

        private void ActionUtilisateurCommand()
        {

            UtilisateursWindow fenetre = new UtilisateursWindow();
            fenetre.Show();
        }

        private void ActionThematiquesCommand()
        {

           ThematiquesWindow fenetre = new ThematiquesWindow();
            fenetre.Show();
        }



        private void ActionCommentairesCommand()
        {

           CommentairesWindow fenetre = new CommentairesWindow();
            fenetre.Show();
        }




    }
}
