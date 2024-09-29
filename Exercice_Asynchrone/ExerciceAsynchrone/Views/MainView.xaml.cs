using ExerciceAsynchrone.ViewModels;
using System.Windows;
using System.Windows.Forms;

namespace ExerciceAsynchrone.Views
{
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewModel(Info, Erreur, ChoisirDossier);
        }


        public void Info(string message)
        {
            System.Windows.MessageBox.Show(message, "Information", 
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void Erreur(string message)
        {
            System.Windows.MessageBox.Show(message, "Erreur", 
                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public string? ChoisirDossier()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    return fbd.SelectedPath;
                }
            }

            return null;
        }
    }
}
