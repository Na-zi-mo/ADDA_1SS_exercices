using ExerciceInjection.Models;
using ExerciceInjection.ViewModels.Commands;
using ExerciceInjection.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        protected IDataService<Personne> _dataService;
        public PersonneViewModel(IInteractionUtilisateur interaction, IDataService<Personne> dataService) : base(interaction)
        {
            _dataService = dataService;

            this.Personnes = new ObservableCollection<Personne>(_dataService.GetAll());

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
                
                _dataService.Insert(personne);

                //this.Personnes.Add(personne);

                InitAjoutModif();
            }
            catch (Exception ex)
            {
                _interaction.AfficherMessageErreur(ex.Message);
            }
        }

        private void SupprimerTout(object? obj)
        {
            foreach (var personne in this.Personnes)
            {
                _dataService.Delete(personne);
            }

            //this.Personnes.Clear();
            InitAjoutModif();
        }

        private void SupprimerPersonne(object? obj)
        {
            if (PersonneSelectionnee != null)
            {
                _dataService.Delete(PersonneSelectionnee);
                //this.Personnes.Remove(PersonneSelectionnee);
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

                    this._dataService.Update(PersonneSelectionnee);

                    InitAjoutModif();
                }
                catch (Exception ex)
                {
                    _interaction.AfficherMessageErreur(ex.Message);
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

            this.Personnes = new ObservableCollection<Personne>(_dataService.GetAll());

        }

        public RelayCommand CmdAjouterPersonne { get; private set; }

        public RelayCommand CmdModifierPersonne { get; private set; }

        public RelayCommand CmdAnnuler { get; private set; }

        public RelayCommand CmdSupprimerPersonne { get; private set; }

        public RelayCommand CmdSupprimerTout { get; private set; }

        private ObservableCollection<Personne> _personnes;

        public ObservableCollection<Personne> Personnes
        {
            get => _personnes;
            set
            {
                _personnes = value;
                OnPropertyChanged(); 
            }
        }

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
