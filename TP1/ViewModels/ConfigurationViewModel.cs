using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using TP1.ViewModels.Commands;
using static TP1.ViewModels.Delegates.ViewModelDelegates;

namespace TP1.ViewModels
{
    public class ConfigurationViewModel : BaseViewModel
    {

        private bool _isRestartChecked;
        public bool IsRestartChecked
        {
            get { return _isRestartChecked; } 
            set {
                _isRestartChecked = value;
                OnPropertyChanged();
            }
        }

        private string _selectedLanguage;
        protected CloseConfigurationWIndow _closeWindow;
        protected ShowInformationDialog _showInformation;

        public string SelectedLanguage
        {
            get { return _selectedLanguage; }
            set {
                _selectedLanguage = value;
            } 
        }
        public ConfigurationViewModel(MessageErreur erreur, Question question, OpenFileDialogInput openFileDialog, CloseConfigurationWIndow closeWindow, ShowInformationDialog showInformation) : base(erreur, question, openFileDialog)
        {
            _closeWindow = closeWindow;
            _showInformation = showInformation;

            SaveConfigurationCmd = new RelayCommand(SaveConfiguration, (object? parameter) =>
            {
                return SelectedLanguage != null;
            });
            CancelConfigurationCmd = new RelayCommand(CancelConfiguration, null);
            
        }

        public void SaveConfiguration(object? parameter)
        {
            TP1.Properties.Settings.Default.langue = SelectedLanguage;
            TP1.Properties.Settings.Default.Save();

            if (IsRestartChecked) {
                _showInformation(TP1.Properties.traduction.information_dialog_msg);
                System.Diagnostics.Process.Start(fileName: Environment.ProcessPath);
                Application.Current.Shutdown();
            }
            _closeWindow();

        }
        public void CancelConfiguration(object? parameter)
        {
            _closeWindow();
        }

        public RelayCommand SaveConfigurationCmd { get; set; }
        public RelayCommand CancelConfigurationCmd { get; set; }
    }
}
