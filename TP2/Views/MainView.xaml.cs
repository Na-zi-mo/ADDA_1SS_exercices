using Microsoft.Win32;
using System;
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
using static TP2.ViewModels.Delegates.ViewModelDelegate;
using TP2.ViewModels;

namespace TP2.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewModel(OpenConfigurationWindow, DisplayMessageError);
        }

        public void OpenConfigurationWindow()
        {
            ConfigurationView configView = new ConfigurationView();
            configView.ShowDialog();
        }
        public void DisplayMessageError(string message)
        {
            MessageBox.Show(message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
