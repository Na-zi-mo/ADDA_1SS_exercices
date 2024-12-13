using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using TP4.ViewModels.Interfaces;

namespace TP4.Views
{
    public class InteractionUtilisateurGui : IInteractionUtilisateur
    {
        public void OpenConfigurationWindow()
        {
            ConfigurationView configView = new ConfigurationView();
            configView.ShowDialog();
        }

        public void CloseConfigurationWindow()
        {
            Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.Title == TP4.Properties.traduction.menu_configuration)?.Close();
        }

        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void ShowInformationMessage(string message)
        {
            MessageBox.Show(message, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
