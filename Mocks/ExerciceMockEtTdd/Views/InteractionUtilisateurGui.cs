using ExerciceMockEtTdd.ViewModels.Interfaces;
using System.Windows;

namespace ExerciceMockEtTdd.Views
{
    public class InteractionUtilisateurGui : IInteractionUtilisateur
    {
        public void AfficherMessageErreur(string msg)
        {
            MessageBox.Show(msg, ExerciceMockEtTdd.Properties.traduction.titre_erreur, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public bool PoserQuestion(string question)
        {
            var resultat = MessageBox.Show(question, ExerciceMockEtTdd.Properties.traduction.titre_question, MessageBoxButton.YesNo, MessageBoxImage.Question);
            return resultat == MessageBoxResult.Yes;
        }
    }
}
