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

        private string deleteButton;

        private string contentButton;
        public string Pseudo { get => Utilisateur.Pseudo; set => Utilisateur.Pseudo = value; }

        public string Email { get => Utilisateur.Email; set => Utilisateur.Email = value; }

        public string Avatar { get => Utilisateur.Avatar; set => Utilisateur.Avatar = value; }

        public ICommand ConfirmCommand { get; set; }

        public ICommand DeleteCommand { get; set; }



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
                    RaisePropertyChanged("Avatar");
                    RaisePropertyChanged("ContentButton");
                    RaisePropertyChanged("DeleteButton");


                }
            }
        }

        
        public string ContentButton { get => Utilisateur.Id > 0 ? "Modifier" : "Ajouter"; }

        public string DeleteButton { get => Utilisateur.Id > 0 ?  "Supprimer" : " "; }


        public UtilisateurViewModel()
        {
            Utilisateur = new Utilisateur();
            ConfirmCommand = new RelayCommand(ActionConfirmCommand);
            DeleteCommand = new RelayCommand(ActionDeleteCommand);
            Utilisateurs = new ObservableCollection<Utilisateur>(Utilisateur.GetAll());
        }

        private void ActionConfirmCommand()
        {
            if (Utilisateur.Id > 0)
            {
                if (Utilisateur.Update())
                {
                    MessageBox.Show("Utilisateur mis à jour avec l'id " + Utilisateur.Id);
                    Utilisateurs = new ObservableCollection<Utilisateur>(Utilisateur.GetAll());
                    RaisePropertyChanged("Utilisateurs");
                    Utilisateur = new Utilisateur();
                }
            }
            else
            {
                if (Utilisateur.Save())
                {
                    MessageBox.Show("Utilisateur ajouté avec l'id " + Utilisateur.Id);
                    Utilisateurs.Add(Utilisateur);
                    Utilisateur = new Utilisateur();
                    //Clear();
                }
                else
                {
                    MessageBox.Show("Erreur ajout utilisateur");
                }
            }
        }


        private void ActionDeleteCommand()
        {
            if (Utilisateur.Id > 0)
            {


                if (Utilisateur.Delete())
                {
                    MessageBox.Show("Utilisateur supprimé avec l'id " + Utilisateur.Id);
                    Utilisateurs.Remove(Utilisateur);
                    Utilisateur = new Utilisateur();
                    //Clear();
                }
                else
                {
                    MessageBox.Show("Erreur supprssion utilisateur");
                }
             
            }


        }

       

    }
}
