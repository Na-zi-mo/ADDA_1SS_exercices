using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using test.Models;
using test.ViewModels.Commands;
using static test.ViewModels.Delegates.ViewModelDelegates;

namespace test.ViewModels
{
    //public class PersonneViewModel : BaseViewModel
    //{
    //    public PersonneViewModel(MessageErreur erreur, Question question) : base(erreur, question) 
    //    {

    //    }
    //}
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
            
            List<string> lines = new List<string>(test.Properties.AutresRessources.contacts.Split('\n'));

            foreach (string line in lines)
            {
                List<string> data = new List<string>(line.Split(';'));
                this.Personnes.Add(new Personne(data[0], data[1], data[2]));
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
        }

        private void AjouterPersonne(object obj)
        {
            try
            {
                this.Personnes.Add(new Personne(Nom, Prenom, Telephone));
                InitAjoutModif();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SupprimerTout(object obj)
        {
            this.Personnes.Clear();
            InitAjoutModif();
        }

        private void SupprimerPersonne(object obj)
        {
            if (PersonneSelectionnee != null)
            {
                this.Personnes.Remove(PersonneSelectionnee);
            }
            InitAjoutModif();
        }

        private void ModifierPersonne(object obj)
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
                    MessageBox.Show(ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Annuler(object obj)
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
