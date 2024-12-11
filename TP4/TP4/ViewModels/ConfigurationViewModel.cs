using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP4.ViewModels.Commands;
using TP4.ViewModels.Interfaces;

namespace TP4.ViewModels
{
    public class ConfigurationViewModel : BaseViewModel
    {

        private string _selectedLanguage;
        public string SelectedLanguage
        {
            get { return _selectedLanguage; }
            set
            {
                _selectedLanguage = value;
                OnPropertyChanged(nameof(SelectedLanguage));
            }
        }

        private string _token;

        public string Token
        {
            get { return _token; }
            set
            {
                _token = value;
                OnPropertyChanged();
            }
        }

        public ConfigurationViewModel(IInteractionUtilisateur interaction) : base(interaction) 
        {
            Token = TP4.Properties.Settings.Default.token;
            SelectedLanguage = TP4.Properties.Settings.Default.langue == "en-US" ? "en-US" : "fr-CA";
            SaveConfigurationCmd = new RelayCommand(SaveConfiguration, (object? parameter) =>
            {
                return SelectedLanguage != null;
            });
            CancelConfigurationCmd = new RelayCommand(CancelConfiguration, null);
        }

        public void SaveConfiguration(object? parameter)
        {
            TP4.Properties.Settings.Default.langue = SelectedLanguage;
            TP4.Properties.Settings.Default.token = Token;
            TP4.Properties.Settings.Default.Save();
            _interaction.CloseConfigurationWindow();

        }
        public void CancelConfiguration(object? obj)
        {
            _interaction.CloseConfigurationWindow();
        }

        public RelayCommand SaveConfigurationCmd { get; set; }
        public RelayCommand CancelConfigurationCmd { get; set; }
    }
}
