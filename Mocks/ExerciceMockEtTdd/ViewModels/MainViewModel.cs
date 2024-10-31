using ExerciceMockEtTdd.ViewModels.Commands;
using ExerciceMockEtTdd.ViewModels.Interfaces;
using System;
using System.Windows;

namespace ExerciceMockEtTdd.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _viewModelActuel;
        private AccueilViewModel _accueilViewModel;
        private PersonneViewModel _personneViewModel;

        public MainViewModel(IInteractionUtilisateur interaction, PersonneViewModel personneViewModel) : base(interaction)
        {
            _accueilViewModel = new AccueilViewModel(interaction);
            _personneViewModel = personneViewModel;
            _viewModelActuel = _personneViewModel;
            CmdGotoAccueil = new RelayCommand(GotoAccueil, null);
            CmdGotoPersonne = new RelayCommand(GotoPersonne, null);
            CmdChangerLangue = new RelayCommand(ChangerLangue, null);
        }

        private void ChangerLangue(object? obj)
        {
            ExerciceMockEtTdd.Properties.Settings.Default.langue = obj as string;
            ExerciceMockEtTdd.Properties.Settings.Default.Save();

            if (_interaction.PoserQuestion(ExerciceMockEtTdd.Properties.traduction.msg_confirmation_redemarrage))
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
