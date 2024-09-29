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
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _viewModelActuel;
        private AccueilViewModel _accueilViewModel;
        private PersonneViewModel _personneViewModel;

        public MainViewModel(MessageErreur erreur, Question question) : base(erreur, question) 
        {
            _accueilViewModel = new AccueilViewModel(erreur, question);
            _personneViewModel = new PersonneViewModel(erreur, question);
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
                var result = _question(test.Properties.traduction.confirmation);
                if (result)
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
                var result = _question(test.Properties.traduction.confirmation);
                if (result)
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
