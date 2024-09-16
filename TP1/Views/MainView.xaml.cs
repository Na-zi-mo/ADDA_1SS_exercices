﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TP1.ViewModels;

namespace TP1.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewModel(AfficherMessageErreur, PoserQuestion, OpenFileDialog, OpenConfigurationWindow);
        }

        public string OpenFileDialog()
        {
            var file = new Microsoft.Win32.OpenFileDialog();
            file.ShowDialog();
            return file.FileName;
        }

        public void AfficherMessageErreur(string message)
        {
            MessageBox.Show(message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public bool PoserQuestion(string message)
        {
            var result = MessageBox.Show(message, "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            return result == MessageBoxResult.Yes;
        }
        public void OpenConfigurationWindow()
        {
            ConfigurationView configView = new ConfigurationView();
            configView.ShowDialog();
        }
    }
}