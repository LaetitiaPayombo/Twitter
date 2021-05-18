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
using System.Windows.Controls;

namespace TwitterAdmin.ViewModels
{
    class ForumViewModel : ViewModelBase
    {

       
        public ICommand UtilisateursCommand { get; set; }
        public ICommand ThematiquesCommand { get; set; }

        public ICommand CommentairesCommand { get; set; }

       
        public ForumViewModel()
        {
            
            UtilisateursCommand = new RelayCommand(ActionUtilisateurCommand);
            ThematiquesCommand = new RelayCommand(ActionThematiquesCommand);
            CommentairesCommand = new RelayCommand(ActionCommentairesCommand);

        }

        //private void ActionUtilisateurCommand(StackPanel result)
        //{
        //    result.Children.Clear();
        //    result.Children.Add(new UtilisateursWindow());

        //}

        //private void ActionThematiquesCommand(StackPanel result)
        //{
        //    result.Children.Clear();
        //    result.Children.Add(new ThematiquesWindow());

        //}



        //private void ActionCommentairesCommand(StackPanel result)
        //{
        //    result.Children.Clear();
        //    result.Children.Add(new CommentairesWindow());

        //}


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
