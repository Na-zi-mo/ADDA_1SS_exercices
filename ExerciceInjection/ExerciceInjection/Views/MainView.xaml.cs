using Autofac;
using ExerciceInjection.ViewModels;
using System.Windows;

namespace ExerciceInjection.Views
{
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = FournisseurDI.Container.Resolve<MainViewModel>();
        } 
    }
}
