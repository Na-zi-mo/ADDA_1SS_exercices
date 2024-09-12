using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using test.ViewModels.Commands;
using static test.ViewModels.Delegates.ViewModelDelegates;

namespace test.ViewModels
{
    //public class MainViewModel : BaseViewModel
    //{
    //    private AccueilViewModel _accueilViewModel;
    //    private PersonneViewModel _personneViewModel;
    //    private BaseViewModel _viewModelActuel;
    //    public MainViewModel(MessageErreur erreur, Question question) : base(erreur, question) 
    //    {
    //        _accueilViewModel = new AccueilViewModel(erreur, question);
    //        _personneViewModel = new PersonneViewModel(erreur, question);
    //        ViewModelActuel = _accueilViewModel;
    //        GoToPersonneCmd = new RelayCommand(GoToPersonne, null);
    //        GoToAccueilCmd = new RelayCommand(GoToAccueil, null);

    //    }

    //    public void GoToAccueil(object? parameter)
    //    {
    //        ViewModelActuel = _accueilViewModel;
    //    }

    //    public void GoToPersonne(object? parameter)
    //    {
    //        ViewModelActuel = _personneViewModel;
    //    }

    //    public BaseViewModel ViewModelActuel
    //    {
    //        get { return _viewModelActuel; }
    //        set { 
    //            _viewModelActuel = value;
    //            OnPropertyChanged();
    //        }
    //    }
    //    public RelayCommand GoToPersonneCmd { get; set; }

    //    public RelayCommand GoToAccueilCmd { get; set; }
    //}
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _viewModelActuel;
        private AccueilViewModel _accueilViewModel;
        private PersonneViewModel _personneViewModel;

        public MainViewModel()
        {
            _accueilViewModel = new AccueilViewModel();
            _personneViewModel = new PersonneViewModel();
            ViewModelActuel = _personneViewModel;
            CmdGotoAccueil = new RelayCommand(GotoAccueil, null);
            CmdGotoPersonne = new RelayCommand(GotoPersonne, null);
            CmdSetFrench = new RelayCommand(SetFrench, null);
            CmdSetEnglish = new RelayCommand(SetEnglish, null);
        }

        private void GotoAccueil(object obj)
        {
            ViewModelActuel = _accueilViewModel;
        }

        private void GotoPersonne(object obj)
        {
            ViewModelActuel = _personneViewModel;
        }

        private void SetFrench(object obj)
        {
            if (test.Properties.Settings.Default.langue != "fr-CA")
            {
                var result = MessageBox.Show(test.Properties.traduction.confirmation, "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    test.Properties.Settings.Default.langue = "fr-CA";
                    test.Properties.Settings.Default.Save();
                    string langue = test.Properties.Settings.Default.langue;
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(langue);

                    System.Diagnostics.Process.Start(fileName: Environment.ProcessPath);
                    //System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                    Application.Current.Shutdown();
                }
            }
        }

        private void SetEnglish(object obj)
        {
            if (test.Properties.Settings.Default.langue != "en-US")
            {
                var result = MessageBox.Show(test.Properties.traduction.confirmation, "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    test.Properties.Settings.Default.langue = "en-US";
                    test.Properties.Settings.Default.Save();
                    string langue = test.Properties.Settings.Default.langue;
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(langue);

                    System.Diagnostics.Process.Start(fileName: Environment.ProcessPath);
                    //System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                    Application.Current.Shutdown();
                }
            }
        }

        public RelayCommand CmdGotoAccueil { get; private set; }

        public RelayCommand CmdGotoPersonne { get; private set; }

        public RelayCommand CmdSetFrench { get; private set; }

        public RelayCommand CmdSetEnglish { get; private set; }

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
