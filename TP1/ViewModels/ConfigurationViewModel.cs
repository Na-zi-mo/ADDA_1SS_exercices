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

        private string _selectedLanguage;
        protected CloseConfigurationWIndow _closeWindow;

        public string SelectedLanguage
        {
            get { return _selectedLanguage; }
            set {
                _selectedLanguage = value;
            } 
        }
        public ConfigurationViewModel(MessageErreur erreur, Question question, OpenFileDialogInput openFileDialog, CloseConfigurationWIndow closeWindow) : base(erreur, question, openFileDialog)
        {
            _closeWindow = closeWindow;

            SaveConfigurationCmd = new RelayCommand(SaveConfiguration, (object? parameter) =>
            {
                return SelectedLanguage != null;
            });
        }

        public void SaveConfiguration(object? parameter)
        {
            TP1.Properties.Settings.Default.langue = SelectedLanguage;
            TP1.Properties.Settings.Default.Save();
            _closeWindow();

        }

        public RelayCommand SaveConfigurationCmd { get; set; }
    }
}
