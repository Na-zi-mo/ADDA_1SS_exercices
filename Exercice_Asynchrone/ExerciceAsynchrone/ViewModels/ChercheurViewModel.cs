using ExerciceAsynchrone.ViewModels.Commands;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using static ExerciceAsynchrone.ViewModels.Delegates.ViewModelDelegates;

namespace ExerciceAsynchrone.ViewModels
{
    public class ChercheurViewModel : BaseViewModel
    {
        private string? _dossierSelectionne;
        private string _chaineRecherche;
        private int _nbResultatsPositifs;
        private int _nbFichiers;
        private int _progression;
        private bool _enExecution;

        public ChercheurViewModel(Info info, Erreur erreur, ChoisirDossier choisirDossier) : base(info, erreur, choisirDossier)
        {
            _dossierSelectionne = null;
            _nbResultatsPositifs = 0;
            _nbFichiers = 0;
            _chaineRecherche = "";
            Resultats = new ObservableCollection<string>();

            CmdChoisirDossier = new RelayCommand(ChoisirDossier, null);
            CmdChercher = new AsyncCommand(Chercher, CanExecuteChercher);
            CmdAnnuler = new RelayCommand(Annuler, CanExecuteAnnuler);
        }

        private async Task Chercher(object? obj)
        {
            InitInfoRecherche();

            if (DossierSelectionne == null) return;
            
            EnExecution = true;
            
            // À compléter...

            EnExecution = false;
        }

        private void Annuler(object? obj)
        {
            // À compléter...
        }

        private bool CanExecuteChercher(object? obj)
        {
            return !string.IsNullOrEmpty(DossierSelectionne) && ! EnExecution;
        }

        private bool CanExecuteAnnuler(object? obj)
        {
            return EnExecution;
        }

        private void ChoisirDossier(object? obj)
        {
            string? chemin = _choisirDossier();
            if (chemin != null)
            {
                InitInfoRecherche();
                ChaineRecherche = "";
                DossierSelectionne = chemin;
            }
        }

        private void InitInfoRecherche()
        {
            Resultats.Clear();
            NbResultatsPositifs = 0;
            NbFichiersTraites = 0;
            Progression = 0;
        }

        public RelayCommand CmdChoisirDossier { get; private set; }
        public AsyncCommand CmdChercher { get; private set; }
        public RelayCommand CmdAnnuler { get; private set; }

        public ObservableCollection<string> Resultats { get; private set; }

        public string? DossierSelectionne
        {
            get { return _dossierSelectionne; }
            set
            {
                _dossierSelectionne = value;
                OnPropertyChanged();
            }
        }

        public string ChaineRecherche
        {
            get { return _chaineRecherche; }
            set
            {
                _chaineRecherche = value;
                OnPropertyChanged();
            }
        }

        public int NbResultatsPositifs
        {
            get { return _nbResultatsPositifs; }
            set
            {
                _nbResultatsPositifs = value;
                OnPropertyChanged();
            }
        }

        public int NbFichiersTraites
        {
            get { return _nbFichiers; }
            set
            {
                _nbFichiers = value;
                OnPropertyChanged();
            }
        }

        public int Progression
        {
            get { return _progression; }
            set 
            { 
                _progression = value; 
                OnPropertyChanged(); 
            }
        }

        public bool EnExecution
        {
            get { return _enExecution; }
            set 
            { 
                _enExecution = value;
                OnPropertyChanged();
            }
        }
    }
}
