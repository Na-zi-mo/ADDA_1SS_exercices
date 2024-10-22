using Autofac;
using ExerciceInjection.ViewModels;
using System.Windows.Controls;


namespace ExerciceInjection.Views
{
    public partial class PersonneView : UserControl
    {
        public PersonneView()
        {
            InitializeComponent();
            DataContext = FournisseurDI.Container.Resolve<PersonneViewModel>();
        }
    }
}
