using ExerciceMockEtTdd.Models;
using ExerciceMockEtTdd.ViewModels.Commands;
using ExerciceMockEtTdd.ViewModels.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ExerciceMockEtTdd.ViewModels
{
    public class PersonneViewModel : BaseViewModel
    {
        private Personne? _personneSelectionnee = null;
        private string _nom;
        private string _prenom;
        private string _telephone;
        private bool _modeAjout;

        private IDataService<Personne> _dsPersonne;

        public PersonneViewModel(IInteractionUtilisateur interaction, IDataService<Personne> dsPersonne) : base(interaction)
        {
            _dsPersonne = dsPersonne;

            this.Personnes = new ObservableCollection<Personne>();
            foreach (Personne personne in _dsPersonne.GetAll())
            { 
                this.Personnes.Add(personne);
            }

            Nom = string.Empty;
            Prenom = string.Empty;
            Telephone = string.Empty;
            ModeAjout = true;

            CmdAjouterPersonne = new RelayCommand(AjouterPersonne, null);
            CmdModifierPersonne = new RelayCommand(ModifierPersonne, null);
            CmdAnnuler = new RelayCommand(Annuler, null);
            CmdSupprimerPersonne = new RelayCommand(SupprimerPersonne, null);
            CmdSupprimerTout = new RelayCommand(SupprimerTout, null);
            CmdCopierPersonne = new RelayCommand(CopierPersonne, null);
        }

        public void CopierPersonne(object? obj)
        {
            if (PersonneSelectionnee != null)
            {
                try
                {
                    Personne personne = new Personne(0, Nom, Prenom, Telephone);
                    _dsPersonne.Insert(personne);
                    this.Personnes.Add(personne);
                    PersonneSelectionnee = null;
                    InitAjoutModif();
                }
                catch (Exception ex)
                {
                    _interaction.AfficherMessageErreur(ex.Message);
                }
            }
        }

        public void AjouterPersonne(object? obj)
        {
            try
            {
                Personne personne = new Personne(0, Nom, Prenom, Telephone);
                _dsPersonne.Insert(personne);
                this.Personnes.Add(personne);
                InitAjoutModif();
            }
            catch (Exception ex)
            {
                _interaction.AfficherMessageErreur(ex.Message);
            }
        }

        public void SupprimerTout(object? obj)
        {
            foreach(Personne personne in _dsPersonne.GetAll().ToArray<Personne>()) 
            { 
                _dsPersonne.Delete(personne);   
            }
            this.Personnes.Clear();
            InitAjoutModif();
        }

        public void SupprimerPersonne(object? obj)
        {
            if (PersonneSelectionnee != null)
            {
                _dsPersonne.Delete(PersonneSelectionnee);
                this.Personnes.Remove(PersonneSelectionnee);
            }
            InitAjoutModif();
        }

        public void ModifierPersonne(object? obj)
        {
            if (PersonneSelectionnee != null)
            {
                try
                {
                    this.PersonneSelectionnee.Nom = Nom;
                    this.PersonneSelectionnee.Prenom = Prenom;
                    this.PersonneSelectionnee.Telephone = Telephone;
                    _dsPersonne.Update(this.PersonneSelectionnee);
                    InitAjoutModif();
                }
                catch (Exception ex)
                {
                    _interaction.AfficherMessageErreur(ex.Message);
                }
            }
        }

        public void Annuler(object? obj)
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

        public RelayCommand CmdCopierPersonne { get; private set; }

        public ObservableCollection<Personne> Personnes { get; set; }

        public Personne? PersonneSelectionnee
        {
            get { return _personneSelectionnee; }
            set
            {
                _personneSelectionnee = value;
                if (_personneSelectionnee != null)
                {
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
