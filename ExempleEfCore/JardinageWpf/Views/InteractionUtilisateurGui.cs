using JardinageWpf.ViewModels.Interfaces;
using System.Windows;

namespace JardinageWpf.Views
{
    public class InteractionUtilisateurGui : IInteractionUtilisateur
    {
        public void AfficherMessageErreur(string msg)
        {
            MessageBox.Show(msg, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void AfficherMessageInfo(string msg)
        {
            MessageBox.Show(msg, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public bool PoserQuestion(string question)
        {
            var resultat = MessageBox.Show(question, "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            return resultat == MessageBoxResult.Yes;
        }
    }
}
