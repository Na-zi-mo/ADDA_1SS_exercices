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
using test.ViewModels;

namespace test.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            //DataContext = new MainViewModel(AfficherMessageErreur, PoserQuestion);
        }

        //public void AfficherMessageErreur(string message)
        //{
        //    MessageBox.Show(message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
        //}

        //public bool PoserQuestion(string message)
        //{
        //    var result = MessageBox.Show(message, "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
        //    return result == MessageBoxResult.Yes;
        //}
    }
}
