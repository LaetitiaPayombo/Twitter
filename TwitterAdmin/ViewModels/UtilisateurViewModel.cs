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
    class UtilisateurViewModel : ViewModelBase
    {

        private Utilisateur utilisateur;
        private string contentButton;

        public string Pseudo { get => Utilisateur.Pseudo; set => Utilisateur.Pseudo = value; }

        public string Email { get => Utilisateur.Email; set => Utilisateur.Email = value; }

        public ICommand ConfirmCommand { get; set; }

        public ObservableCollection<Utilisateur> Utilisateurs { get; set; }



        public Utilisateur Utilisateur
        {
            get => utilisateur; set
            {
                utilisateur = value;
                if (utilisateur != null)
                {
                    RaisePropertyChanged("Pseudo");
                    RaisePropertyChanged("Email");
                    RaisePropertyChanged("ContentButton");
                }
            }
        }

        public string ContentButton { get => Utilisateur.Id > 0 ? "Modifier" : "Ajouter"; }



    }
}
