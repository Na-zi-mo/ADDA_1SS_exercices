﻿using System;
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

        public ElectionViewModel(MessageErreur erreur, Question question) : base(erreur, question) 
        {
            this.Contributions = new ObservableCollection<Contribution>();

            //List<string> lines = new List<string>(TP1.Properties.AutresRessources.contributions.Split('\n'));

            //foreach (string line in lines)
            //{
            //    //this.Contributions.Add(new Contribution(line));
            //}

            //for (int i = 1; i < 3; i++)
            //{
            //    this.Contributions.Add(new Contribution(lines[i]));
            //}

            DeleteContributionsCmd = new RelayCommand(DeleteContributions, null /*(object? parameter) =>
            {
                if (this.Contributions.Count > 0) return true;
                return false;
            }*/);
            AddContributionsCmd = new RelayCommand(AddContributions, null);
        }

        public ObservableCollection<Contribution> Contributions { get; set; }
        
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
            var file = new Microsoft.Win32.OpenFileDialog();

            file.ShowDialog();

            this.AnalyseurContributions = new AnalyseurContributions(file.FileName);

            ObservableCollection<Contribution> NewContributions = new ObservableCollection<Contribution>(AnalyseurContributions.Contributions);
            foreach (var item in NewContributions)
            {
                this.Contributions.Add(item);
            }
        }
        public void DeleteContributions(object? parameter)
        {
            this.Contributions.Clear();
        }

        public RelayCommand AddContributionsCmd { get; set; }
        public RelayCommand DeleteContributionsCmd { get; set; }

    }
}
