
using ExerciceAsynchrone.ViewModels.Commands;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using static ExerciceAsynchrone.ViewModels.Delegates.ViewModelDelegates;

namespace ExerciceAsynchrone.ViewModels
{
    public class ScanneurViewModel : BaseViewModel
    {
        private string? _dossierSelectionne;
        private int _nbFichiers;
        private int _nbDossiers;
        private bool _enExecution;


        public ScanneurViewModel(Info info, Erreur erreur, ChoisirDossier choisirDossier) : base(info, erreur, choisirDossier)
        {
            _dossierSelectionne = null;
            _nbFichiers = 0;
            _nbDossiers = 0;
            ItemsScannes = new ObservableCollection<string>();

            CmdChoisirDossier = new RelayCommand(ChoisirDossier, null);
            CmdScanner = new AsyncCommand(Scanner, CanExecuteScanner);
            CmdAnnuler = new RelayCommand(Annuler, CanExecuteAnnuler);
        }

        private void ChoisirDossier(object? obj)
        {
            string? chemin = _choisirDossier();
            if (chemin != null)
            {
                InitInfoScan();
                DossierSelectionne = chemin;
            }
        }

        private async Task Scanner(object? obj)
        {
            InitInfoScan();

            if (DossierSelectionne == null) return;

            EnExecution = true;

            // À compléter...

            EnExecution = false;
        }

        public void Annuler(object? obj)
        {
            // À compléter...
        }

        private bool CanExecuteScanner(object? obj)
        {
            return !string.IsNullOrEmpty(DossierSelectionne) && !EnExecution;
        }

        private bool CanExecuteAnnuler(object? obj)
        {
            return EnExecution;
        }

        private void InitInfoScan()
        {
            ItemsScannes.Clear();
            NbFichiers = 0;
            NbDossiers = 0;
        }

        public RelayCommand CmdChoisirDossier { get; private set; }
        public AsyncCommand CmdScanner { get; private set; }
        public RelayCommand CmdAnnuler { get; private set; }


        public ObservableCollection<string> ItemsScannes { get; private set; }

        public string? DossierSelectionne
        {
            get { return _dossierSelectionne; }
            set
            {
                _dossierSelectionne = value;
                OnPropertyChanged();
            }
        }

        public int NbFichiers
        {
            get { return _nbFichiers; }
            set
            {
                _nbFichiers = value;
                OnPropertyChanged();
            }
        }

        public int NbDossiers
        {
            get { return _nbDossiers; }
            set
            {
                _nbDossiers = value;
                OnPropertyChanged();
            }
        }


        public bool EnExecution
        {
            get { return _enExecution; }
            set { _enExecution = value; }
        }

    }
}
