using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using TP1.Models;
using TP1.ViewModels.Commands;
using static System.Net.Mime.MediaTypeNames;
using static TP1.ViewModels.Delegates.ViewModelDelegates;

namespace TP1.ViewModels
{
    public class ElectionViewModel : BaseViewModel
    {
        private ObservableCollection<Contribution> _contributions;

        private bool _isChecked;

        public bool IsChecked
        {
            get { return _isChecked; }
            set { 
                _isChecked = value;
                OnPropertyChanged(nameof(IsChecked));
            }
        }

        public ElectionViewModel(MessageErreur erreur, Question question, OpenFileDialogInput openFileDialog) : base(erreur, question, openFileDialog) 
        {
            this.Contributions = new ObservableCollection<Contribution>();
            this.AnalyseurContributions = new AnalyseurContributions();
            this.IsChecked = false;

            DeleteContributionsCmd = new RelayCommand(DeleteContributions, (object? parameter) =>
            {
                if (this.Contributions.Count > 0) return true;
                return false;
            });
            AddContributionsCmd = new RelayCommand(AddContributions, null);
            FilterContributionsCmd = new RelayCommand(FilterContributions, (object? parameter) =>
            {
                return this.Contributions.Count > 0;
            });
        }

        public ObservableCollection<Contribution> Contributions
        {
            get { return _contributions; }
            set {
                if (_contributions != value)
                {
                    _contributions = value;
                    OnPropertyChanged(nameof(Contributions));
                }
            }
        }

        private List<Contribution> OnlyIllegalContributions { get; set; }
        
        private AnalyseurContributions _analyseurContributions;

        public AnalyseurContributions AnalyseurContributions
        {
            get { return _analyseurContributions; }
            set { 
                _analyseurContributions = value;
                OnPropertyChanged();
            }
        }



        public void AddContributions(object? parameter)
        {
            string path = _openFileDialog();
            try
            {
                AnalyseurContributions NewAnalyseurContributions = new AnalyseurContributions(path);
                this.AnalyseurContributions.Contributions.AddRange(NewAnalyseurContributions.Contributions);
                ObservableCollection<Contribution> NewContributions = new ObservableCollection<Contribution>(NewAnalyseurContributions.Contributions);
                foreach (var item in NewContributions)
                {
                    this.Contributions.Add(item);
                }
            }
            catch (Exception)
            {
                _erreur(TP1.Properties.traduction.error_msg_csv);
            }
        }
        public void DeleteContributions(object? parameter)
        {
            this.IsChecked = false;
            this.Contributions.Clear();
            this.AnalyseurContributions.Contributions.Clear();
        }

        public void FilterContributions(object? parameter)
        {
            if (IsChecked)
            {
                this.Contributions = new ObservableCollection<Contribution>(AnalyseurContributions.RechercherContributionsPossiblementIllegales());
            }
            else
            {
                this.Contributions = new ObservableCollection<Contribution>(AnalyseurContributions.Contributions);
            }
        }

        public RelayCommand AddContributionsCmd { get; set; }
        public RelayCommand DeleteContributionsCmd { get; set; }
        public RelayCommand FilterContributionsCmd { get; set; }

    }
}
