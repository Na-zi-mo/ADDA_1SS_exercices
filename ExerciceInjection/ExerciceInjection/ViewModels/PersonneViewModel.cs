﻿using ExerciceInjection.Models;
using ExerciceInjection.ViewModels.Commands;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace ExerciceInjection.ViewModels
{
    public class PersonneViewModel : BaseViewModel
    {
        private Personne? _personneSelectionnee = null;
        private string _nom;
        private string _prenom;
        private string _telephone;
        private bool _modeAjout;


        public PersonneViewModel()
        {
            this.Personnes = new ObservableCollection<Personne>();

            Nom = string.Empty;
            Prenom = string.Empty;
            Telephone = string.Empty;
            ModeAjout = true;

            CmdAjouterPersonne = new RelayCommand(AjouterPersonne, null);
            CmdModifierPersonne = new RelayCommand(ModifierPersonne, null);
            CmdAnnuler = new RelayCommand(Annuler, null);
            CmdSupprimerPersonne = new RelayCommand(SupprimerPersonne, null);
            CmdSupprimerTout = new RelayCommand(SupprimerTout, null);
        }

        private void AjouterPersonne(object? obj)
        {
            try
            {
                Personne personne = new Personne(0, Nom, Prenom, Telephone);
                this.Personnes.Add(personne);
                InitAjoutModif();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ExerciceInjection.Properties.traduction.titre_erreur, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SupprimerTout(object? obj)
        {
            this.Personnes.Clear();
            InitAjoutModif();
        }

        private void SupprimerPersonne(object? obj)
        {
            if (PersonneSelectionnee != null)
            {
                this.Personnes.Remove(PersonneSelectionnee);
            }
            InitAjoutModif();
        }

        private void ModifierPersonne(object? obj)
        {
            if (PersonneSelectionnee != null)
            {
                try
                {
                    this.PersonneSelectionnee.Nom = Nom;
                    this.PersonneSelectionnee.Prenom = Prenom;
                    this.PersonneSelectionnee.Telephone = Telephone;
                    InitAjoutModif();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ExerciceInjection.Properties.traduction.titre_erreur, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Annuler(object? obj)
        {
            InitAjoutModif();
        }

        private void InitAjoutModif()
        {
            Nom = string.Empty;
            Prenom = string.Empty;
            Telephone = string.Empty;
            ModeAjout = true;
        }

        public RelayCommand CmdAjouterPersonne { get; private set; }

        public RelayCommand CmdModifierPersonne { get; private set; }

        public RelayCommand CmdAnnuler { get; private set; }

        public RelayCommand CmdSupprimerPersonne { get; private set; }

        public RelayCommand CmdSupprimerTout { get; private set; }

        public ObservableCollection<Personne> Personnes { get; set; }

        public Personne? PersonneSelectionnee
        {
            get { return _personneSelectionnee; }
            set
            {
                if (value != null)
                {
                    _personneSelectionnee = value;
                    Nom = _personneSelectionnee.Nom;
                    Prenom = _personneSelectionnee.Prenom;
                    Telephone = _personneSelectionnee.Telephone;
                    ModeAjout = false;
                    OnPropertyChanged();
                }
            }
        }

        public string Nom
        {
            get { return _nom; }
            set
            {
                _nom = value;
                OnPropertyChanged();
            }
        }

        public string Prenom
        {
            get { return _prenom; }
            set
            {
                _prenom = value;
                OnPropertyChanged();
            }
        }

        public string Telephone
        {
            get { return _telephone; }
            set
            {
                _telephone = value;
                OnPropertyChanged();
            }
        }

        public bool ModeAjout
        {
            get { return _modeAjout; }
            set
            {
                _modeAjout = value;
                OnPropertyChanged();
            }
        }
    }
}
