using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1.ViewModels.Commands;
using static TP1.ViewModels.Delegates.ViewModelDelegates;

namespace TP1.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        protected OpenFileDialogInput _openFileDialog;
        private ElectionViewModel _electionViewModel;
        private BaseViewModel _viewModelActuel;
        protected OpenConfigurationWindow _openConfigurationWindow;

        public MainViewModel(MessageErreur erreur, OpenFileDialogInput openFileDialog, OpenConfigurationWindow openConfigurationWindow)
        {
            _openConfigurationWindow = openConfigurationWindow;
            _openFileDialog = openFileDialog;
            _electionViewModel = new ElectionViewModel(erreur, openFileDialog);
            ViewModelActuel = _electionViewModel;
            OpenConfigurationWindowCmd = new RelayCommand(DisplayConfiguration, null);
        }

        public void DisplayConfiguration(object? parameter)
        {
            _openConfigurationWindow();
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

        public RelayCommand OpenConfigurationWindowCmd { get; set; }
    }
}
