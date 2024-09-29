using ExerciceAsynchrone.ViewModels.Commands;
using static ExerciceAsynchrone.ViewModels.Delegates.ViewModelDelegates;

namespace ExerciceAsynchrone.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _viewModelActuel;
        private ChercheurViewModel _chercheurViewModel;
        private ScanneurViewModel _scanneurViewModel;

        public MainViewModel(Info info, Erreur erreur, ChoisirDossier choisirDossier): base(info, erreur, choisirDossier)
        {
            _chercheurViewModel = new ChercheurViewModel(info, erreur, choisirDossier);
            _scanneurViewModel = new ScanneurViewModel(info, erreur, choisirDossier);
            _viewModelActuel = _chercheurViewModel;

            CmdGoToChercheur = new RelayCommand(GoToChercheur, null);
            CmdGoToScanneur = new RelayCommand(GoToScanneur, null);
        }

        private void GoToChercheur(object? obj)
        {
            ViewModelActuel = _chercheurViewModel;
        }

        private void GoToScanneur(object? obj)
        {
            ViewModelActuel = _scanneurViewModel;
        }        

        public BaseViewModel ViewModelActuel
        {
            get { return _viewModelActuel; }
            set
            {
                _viewModelActuel = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand CmdGoToChercheur { get; set; }
        public RelayCommand CmdGoToScanneur { get; set; }
    }
}
