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

        public bool PoserQuestion(string question, string titreQuestion)
        {
            var result =  MessageBox.Show(question, titreQuestion,MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes) return true;
            else return false;        
        }
    }
}
