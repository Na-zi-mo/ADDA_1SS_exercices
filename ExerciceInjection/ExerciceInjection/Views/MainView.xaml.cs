using ExerciceInjection.ViewModels;
using System.Windows;

namespace ExerciceInjection.Views
{
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        } 
    }
}
