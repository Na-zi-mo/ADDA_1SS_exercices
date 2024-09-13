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
        private ElectionViewModel _electionViewModel;
        private BaseViewModel _viewModelActuel;

        public MainViewModel(MessageErreur erreur, Question question) : base(erreur, question) 
        {
            _electionViewModel = new ElectionViewModel(erreur, question);
            ViewModelActuel = _electionViewModel;
            //GoToPersonneCmd = new RelayCommand(GoToPersonne, null);
            //GoToAccueilCmd = new RelayCommand(GoToAccueil, null);
            //DisplayConfigurationCmd = new RelayCommand(DisplayConfiguration, null);

        }

        //public void GoToAccueil(object? parameter)
        //{
        //    ViewModelActuel = _accueilViewModel;
        //}

        //public void GoToPersonne(object? parameter)
        //{
        //    ViewModelActuel = _personneViewModel;
        //}

        //public void DisplayConfiguration(object? parameter)
        //{
        //    ViewModelActuel = _personneViewModel;
        //}

        public BaseViewModel ViewModelActuel
        {
            get { return _viewModelActuel; }
            set { 
                _viewModelActuel = value;
                OnPropertyChanged();
            }
        }
        //public RelayCommand GoToPersonneCmd { get; set; }

        //public RelayCommand GoToAccueilCmd { get; set; }

        //public RelayCommand DisplayConfigurationCmd { get; set; }   
    }
}
