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
            DataContext = new ConfigurationViewModel(AfficherMessageErreur, PoserQuestion, OpenFileDialog, CloseWindow);
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

        public void CloseWindow()
        {
            this.Close();
        }
    }
}
