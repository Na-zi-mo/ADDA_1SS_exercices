namespace ExerciceInjection.ViewModels.Interfaces
{
    public interface IInteractionUtilisateur
    {
        public void AfficherMessageErreur(string message);
        public bool PoserQuestion(string question, string titreQuestion);
    }
}