using Autofac;
using GestionBanque.ViewModels;
using System.Windows.Controls;


namespace GestionBanque.Views
{
    public partial class BanqueView : UserControl
    {
        public BanqueView()
        {
            InitializeComponent();
            DataContext = FournisseurDI.Container.Resolve<BanqueViewModel>();
        }
    }
}
