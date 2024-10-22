using ExerciceInjection.ViewModels.Interfaces;
using System.Windows;

namespace ExerciceInjection.Views
{
    public class InteractionUtilisateurGui : IInteractionUtilisateur
    {
        public void AfficherMessageErreur(string message)
        {
            MessageBox.Show(message, "Erreur!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
