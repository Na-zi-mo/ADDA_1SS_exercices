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
using static TP1.ViewModels.Delegates.ViewModelDelegates;
using TP1.ViewModels;
using TP1.Models;

namespace TP1.Views
{
    /// <summary>
    /// Interaction logic for ConfigurationView.xaml
    /// </summary>
    public partial class ConfigurationView : Window
    {
        public ConfigurationView()
        {
            InitializeComponent();
            DataContext = new ConfigurationViewModel(CloseWindow, ShowInformation);
        }

        public void CloseWindow()
        {
            this.Close();
        }

        public void ShowInformation(string message)
        {
            MessageBox.Show(message, TP1.Properties.traduction.information_caption, MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
