using JardinageWpf.ViewModels.Interfaces;

namespace JardinageWpf.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _viewModelActuel;
        private JardinageViewModel _jardinageViewModel;

        public MainViewModel(IInteractionUtilisateur interaction, JardinageViewModel jardinageViewModel) : base(interaction)
        {
            _jardinageViewModel = jardinageViewModel;
            _viewModelActuel = _jardinageViewModel;
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
    }
}
