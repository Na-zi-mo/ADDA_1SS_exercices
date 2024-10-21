using ExerciceInjection.ViewModels.Commands;
using System;
using System.Windows;

namespace ExerciceInjection.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _viewModelActuel;
        private AccueilViewModel _accueilViewModel;
        private PersonneViewModel _personneViewModel;

        public MainViewModel()
        {
            _accueilViewModel = new AccueilViewModel();
            _personneViewModel = new PersonneViewModel();
            _viewModelActuel = _personneViewModel;
            CmdGotoAccueil = new RelayCommand(GotoAccueil, null);
            CmdGotoPersonne = new RelayCommand(GotoPersonne, null);
            CmdChangerLangue = new RelayCommand(ChangerLangue, null);
        }

        private void ChangerLangue(object? obj)
        {
            ExerciceInjection.Properties.Settings.Default.langue = obj as string;
            ExerciceInjection.Properties.Settings.Default.Save();

            var resultat = MessageBox.Show(ExerciceInjection.Properties.traduction.msg_confirmation_redemarrage, ExerciceInjection.Properties.traduction.titre_question, MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultat == MessageBoxResult.Yes)
            {
                //System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                System.Diagnostics.Process.Start(fileName: Environment.ProcessPath);
                Application.Current.Shutdown();
            }
        }

        private void GotoAccueil(object? obj)
        {
            ViewModelActuel = _accueilViewModel;
        }

        private void GotoPersonne(object? obj)
        {
            ViewModelActuel = _personneViewModel;
        }

        public RelayCommand CmdGotoAccueil { get; private set; }

        public RelayCommand CmdGotoPersonne { get; private set; }

        public RelayCommand CmdChangerLangue { get; private set; }

        public BaseViewModel ViewModelActuel
        {
            get { return _viewModelActuel; }
            set
            {
                _viewModelActuel = value;
                OnPropertyChanged();
            }
        }
    }
}
