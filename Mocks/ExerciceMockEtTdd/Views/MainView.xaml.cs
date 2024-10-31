using Autofac;
using ExerciceMockEtTdd.ViewModels;
using System.Windows;

namespace ExerciceMockEtTdd.Views
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
