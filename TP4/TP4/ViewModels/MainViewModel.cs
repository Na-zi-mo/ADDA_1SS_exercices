using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP4.ViewModels.Commands;
using TP4.ViewModels.Interfaces;

namespace TP4.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _viewModelActuel;
        private MeteoViewModel _meteoViewModel;



        public MainViewModel(IInteractionUtilisateur interaction, MeteoViewModel meteoViewModel) : base(interaction)
        {
            _meteoViewModel = meteoViewModel;
            _viewModelActuel = _meteoViewModel;
            OpenConfigurationWindowCmd = new RelayCommand(OpenConfiguration, null);
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

        private void OpenConfiguration(object? obj)
        {
            _interaction.OpenConfigurationWindow();   
        }

        public RelayCommand OpenConfigurationWindowCmd { get; private set; }

    }
}
