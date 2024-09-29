namespace ExerciceAsynchrone.ViewModels.Delegates
{
    public class ViewModelDelegates
    {
        public delegate string? ChoisirDossier();
        public delegate void Info(string msg);
        public delegate void Erreur(string msg);
    }
}
