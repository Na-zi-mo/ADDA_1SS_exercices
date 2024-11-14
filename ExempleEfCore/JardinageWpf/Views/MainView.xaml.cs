using Autofac;
using JardinageWpf.ViewModels;
using System.Windows;

namespace JardinageWpf.Views
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
