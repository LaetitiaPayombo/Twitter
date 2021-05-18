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
    class ThematiqueViewModel : ViewModelBase
    {

        private Thematique thematique;

        private string deleteButton;

        private string contentButtonThem;

        public string Sujet { get => Thematique.Sujet; set => Thematique.Sujet = value; }


        public ICommand ConfirmCommandThem { get; set; }

        public ICommand DeleteCommand { get; set; }

        public ObservableCollection<Thematique> Thematiques { get; set; }


        public Thematique Thematique
        {
            get => thematique; set
            {
                thematique = value;
                if (thematique != null)
                {
                    RaisePropertyChanged("Sujet");
                    RaisePropertyChanged("ContentButtonThem");
                    RaisePropertyChanged("DeleteButton");

                }
            }
        }

        public string ContentButtonThem { get => Thematique.Id > 0 ? "Modifier" : "Ajouter"; }

        public ThematiqueViewModel()
        {
            Thematique = new Thematique();
            ConfirmCommandThem = new RelayCommand(ActionConfirmCommandThem);
            DeleteCommand = new RelayCommand(ActionDeleteCommand);
            Thematiques = new ObservableCollection<Thematique>(Thematique.GetAll());
        }

        private void ActionConfirmCommandThem()
        {
            if (Thematique.Id > 0)
            {
                if (Thematique.Update())
                {
                    MessageBox.Show("Thématique mis à jour avec l'id " + Thematique.Id);
                    Thematiques = new ObservableCollection<Thematique>(Thematique.GetAll());
                    RaisePropertyChanged("Thematiques");
                    Thematique = new Thematique();
                }
            }
            else
            {
                if (Thematique.Save())
                {
                    MessageBox.Show("Thématique ajouté avec l'id " + Thematique.Id);
                    Thematiques.Add(Thematique);
                    Thematique = new Thematique();
                }
                else
                {
                    MessageBox.Show("Erreur ajout thématique");
                }
            }
        }


        private void ActionDeleteCommand()
        {
            if (Thematique.Id > 0)
            {


                if (Thematique.Delete())
                {
                    MessageBox.Show("Thématique supprimé avec l'id " + Thematique.Id);
                    Thematiques.Remove(Thematique);
                    Thematique = new Thematique();
                    //Clear();
                }
                else
                {
                    MessageBox.Show("Erreur suppression thématique");
                }

            }


        }


    }
}
