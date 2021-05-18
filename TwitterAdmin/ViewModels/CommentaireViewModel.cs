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
    class CommentaireViewModel : ViewModelBase
    {

        private Commentaire commentaire;
        
        public DateTime DateCommentaire { get => Commentaire.DateCommentaire; set => Commentaire.DateCommentaire = value; }

        public string Com { get => Commentaire.Com; set => Commentaire.Com = value; }

        public string Image { get => Commentaire.Image; set => Commentaire.Image = value; }




        public ICommand ConfirmCommandCom { get; set; }


        public ObservableCollection<Commentaire> Commentaires { get; set; }



        public Commentaire Commentaire
        {
            get => commentaire; set
            {
                commentaire = value;
                if(commentaire != null)
                {
                    RaisePropertyChanged(" DateCommentaire");
                    RaisePropertyChanged("Com");
                    RaisePropertyChanged("Image");
                   
                }
            }
        }


       


        public CommentaireViewModel()
        {
            Commentaire = new Commentaire();
            ConfirmCommandCom = new RelayCommand(ActionConfirmCommandCom);
            Commentaires = new ObservableCollection<Commentaire>(Commentaire.GetAll());
        }

        private void ActionConfirmCommandCom()
        {
            if (Commentaire.Id > 0)
            {
                if (Commentaire.Update())
                {
                    MessageBox.Show("Commentaire mis à jour avec l'id " + Commentaire.Id);
                    Commentaires = new ObservableCollection<Commentaire>(Commentaire.GetAll());
                    RaisePropertyChanged("Commentaires");
                    Commentaire = new Commentaire();
                }
            }
            else
            {
                if (Commentaire.Save())
                {
                    MessageBox.Show("Commentaire ajouté avec l'id " + Commentaire.Id);
                    Commentaires.Add(Commentaire);
                    Commentaire = new Commentaire();
                }
                else
                {
                    MessageBox.Show("Erreur ajout Commentaire");
                }
            }
        }
    }
}
















