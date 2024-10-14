using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.ViewModels.Commands;
using static TP2.ViewModels.Delegates.ViewModelDelegate;


namespace TP2.ViewModels
{
    public class ConfigurationViewModel : BaseViewModel
    {

        private string _token = TP2.Properties.Settings.Default.token;

        public string Token
        {
            get { return _token; }
            set { 
                _token = value;
                OnPropertyChanged();
            }
        }

        protected CloseConfigurationWIndow _closeWindow;
        public ConfigurationViewModel(CloseConfigurationWIndow closeWindow)
        {
            _closeWindow = closeWindow;

            SaveConfigurationCmd = new RelayCommand(SaveConfiguration, null);
            CancelConfigurationCmd = new RelayCommand(CancelConfiguration, null);
        }

        public void SaveConfiguration(object? parameter)
        {
            TP2.Properties.Settings.Default.token = Token;
            TP2.Properties.Settings.Default.Save();

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
