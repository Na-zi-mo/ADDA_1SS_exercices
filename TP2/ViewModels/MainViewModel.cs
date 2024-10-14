using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.ViewModels.Commands;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static TP2.ViewModels.Delegates.ViewModelDelegate;

namespace TP2.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private LanguageDetectorViewModel _languageDetectorViewModel;
        private BaseViewModel _viewModelActuel;

        protected OpenConfigurationWindow _openConfigurationWindow;

        public MainViewModel(OpenConfigurationWindow openConfigurationWindow, ErrorDialog errorDialog)
        {
            _openConfigurationWindow = openConfigurationWindow;
            _languageDetectorViewModel = new LanguageDetectorViewModel(errorDialog);
            ViewModelActuel = _languageDetectorViewModel;
            OpenConfigurationWindowCmd = new RelayCommand(DisplayConfiguration, null);
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

        public void DisplayConfiguration(object? parameter)
        {
            _openConfigurationWindow();
        }

        public RelayCommand OpenConfigurationWindowCmd { get; set; }
    }
}
